using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace FileUploaderClient
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<FileUploadItem> uploadItems = new ObservableCollection<FileUploadItem>();
        private readonly HttpClient httpClient = new HttpClient();
        private CancellationTokenSource cancelTokenSource;
        private bool isUploading = false;

        public MainWindow()
        {
            InitializeComponent();
            FileListView.ItemsSource = uploadItems;
        }

        private void SelectFiles_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Select Files"
            };

            if (dialog.ShowDialog() == true)
            {
                uploadItems.Clear();
                foreach (var path in dialog.FileNames)
                    uploadItems.Add(new FileUploadItem { FilePath = path });
            }
        }

        private async void UploadFiles_Click(object sender, RoutedEventArgs e)
        {
            if (isUploading) return;

            isUploading = true;
            CancelButton.IsEnabled = true;
            cancelTokenSource = new CancellationTokenSource();

            foreach (var item in uploadItems)
            {
                if (cancelTokenSource.IsCancellationRequested) break;
                await UploadSingleFile(item, cancelTokenSource.Token);
            }

            isUploading = false;
            CancelButton.IsEnabled = false;
            StatusText.Text += "\nUpload process completed or canceled.";
        }

        private async Task UploadSingleFile(FileUploadItem item, CancellationToken token)
        {
            try
            {
                using var fileStream = new FileStream(item.FilePath, FileMode.Open, FileAccess.Read);
                var content = new StreamContent(fileStream);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                var progressContent = new ProgressableStreamContent(content, 4096, (sent, total) =>
                {
                    int percent = (int)((sent * 100) / total);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        item.Progress = percent;
                        FileListView.Items.Refresh();
                    });
                });

                var multipart = new MultipartFormDataContent();
                multipart.Add(progressContent, "files", Path.GetFileName(item.FilePath));

                var response = await httpClient.PostAsync("https://localhost:5001/api/upload", multipart, token);
                

                if (!response.IsSuccessStatusCode)
                    StatusText.Text += $"\nFailed: {item.FileName}";
            }
            catch (OperationCanceledException)
            {
                StatusText.Text += $"\nUpload canceled: {item.FileName}";
            }
            catch
            {
                StatusText.Text += $"\nError uploading: {item.FileName}";
            }
        }

        private void CancelUpload_Click(object sender, RoutedEventArgs e)
        {
            if (cancelTokenSource != null && isUploading)
            {
                cancelTokenSource.Cancel();
                CancelButton.IsEnabled = false;
                StatusText.Text += "\nUpload canceled by user.";
            }
        }
    }
}

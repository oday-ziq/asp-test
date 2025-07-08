using System.IO;

namespace FileUploaderClient
{
    public class FileUploadItem
    {
        public string FilePath { get; set; }
        public string FileName => Path.GetFileName(FilePath);
        public int Progress { get; set; }
    }
}
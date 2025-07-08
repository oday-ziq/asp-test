using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

public class ProgressableStreamContent : HttpContent
{
    private readonly HttpContent content;
    private readonly int bufferSize;
    private readonly Action<long, long> progress;

    public ProgressableStreamContent(HttpContent content, int bufferSize, Action<long, long> progress)
    {
        this.content = content ?? throw new ArgumentNullException(nameof(content));
        this.bufferSize = bufferSize;
        this.progress = progress ?? throw new ArgumentNullException(nameof(progress));

        foreach (var header in content.Headers)
            Headers.TryAddWithoutValidation(header.Key, header.Value);
    }

    protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
    {
        var buffer = new byte[bufferSize];
        TryComputeLength(out long size);
        long uploaded = 0;

        using var input = await content.ReadAsStreamAsync().ConfigureAwait(false);
        int read;
        while ((read = await input.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) > 0)
        {
            await stream.WriteAsync(buffer, 0, read).ConfigureAwait(false);
            uploaded += read;
            progress(uploaded, size);
        }
    }

    protected override bool TryComputeLength(out long length)
    {
        if (content.Headers.ContentLength.HasValue)
        {
            length = content.Headers.ContentLength.Value;
            return true;
        }
        length = -1;
        return false;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            content.Dispose();
        base.Dispose(disposing);
    }
}
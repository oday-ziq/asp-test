using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileUploadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadFiles([FromForm] List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return BadRequest("No files uploaded.");

            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var metadataList = new List<object>();

            foreach (var file in files)
            {
                string filePath = Path.Combine(uploadPath, file.FileName);
                using var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);

                metadataList.Add(new
                {
                    FileName = file.FileName,
                    Size = file.Length,
                    UploadedAt = DateTime.Now
                });
            }

            return Ok(metadataList);
        }
    }
}

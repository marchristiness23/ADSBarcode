using Microsoft.AspNetCore.Http;

namespace Kataandi.Models
{
    public class FileModel
    {
        public string FileName { get; set; }
        public IFormFile file { get; set; }

    }
}
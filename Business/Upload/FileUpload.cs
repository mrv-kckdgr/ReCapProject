using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Upload
{
    public class FileUpload
    {
        public IFormFile file { get; set; }
    }
}

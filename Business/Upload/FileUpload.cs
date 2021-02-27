using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Upload
{
    public class FileUpload
    {
        public IFormFile Files { get; set; }
    }
}

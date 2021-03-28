using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace Core.Utilities.FileUpload
{
    public class FileHelpers
    {
        public IDataResult<string[]> FileExtensionRotates(string FileType)
        {
            if (FileType.ToUpper() == "IMAGE")
            {
                string[] extensions = { "Images", ".jpg", ".tif", ".png", ".jpeg", ".bmp", "IMG" };
                return new SuccessDataResult<string[]>(extensions);
            }
            else if (FileType.ToUpper() == "TEXT")
            {
                string[] extensions = { "Texts", ".txt" };
                return new SuccessDataResult<string[]>(extensions);
            }
            return new ErrorDataResult<string[]>();
        }

        public IDataResult<string> FileControl(IFormFile file, string[] fileExtentions)
        {
            var getFileExtensions = Path.GetExtension(file.FileName).ToLower(new CultureInfo("en-US", false));
            for (int i = 1; i < fileExtentions.Length; i++)
            {
                if (fileExtentions[i].ToLower() == getFileExtensions)
                {
                    string fileName = "\\" + fileExtentions[0] + "\\" + Guid.NewGuid().ToString() + getFileExtensions;
                    return new SuccessDataResult<string>(fileName);
                }
            }
            return new ErrorDataResult<string>("Gönderilen dosya türü hatalı !");
        }

        public IDataResult<string> Upload(IFormFile file, string path, string fileType)
        {
            var resultFileRotates = FileExtensionRotates(fileType);

            if (resultFileRotates.Success)
            {
                var resultFileControl = FileControl(file, resultFileRotates.Data);
                if (resultFileControl.Success)
                {
                    string replaceFileName = resultFileControl.Data;
                    var files = System.IO.Path.Combine(path + replaceFileName);
                    using (var fileStream = new FileStream(files, FileMode.Create))
                    {
                        file.CopyToAsync(fileStream);
                    }
                    return new SuccessDataResult<string>(replaceFileName);
                }
                return new ErrorDataResult<string>(resultFileControl.Message);
            }
            return new ErrorDataResult<string>(resultFileRotates.Message);

        }
    }
}
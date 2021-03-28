using Business.Abstract;
using Business.Constants;
using Business.Upload;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.FileUpload;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        IWebHostEnvironment _webHostEnvironment;
        private FileHelpers _fileHelpers;

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment,  FileHelpers fileHelpers)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
            _fileHelpers = fileHelpers;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage, IFormFile file)
        {
            
                //Save image to wwwroot/image
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                //string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                //string extension = Path.GetExtension(file.FileName);
                 
                
                //string path = Path.Combine("/Images/", Guid.NewGuid().ToString()) ;
               
                //using (var fileStream = new FileStream(path+extension, FileMode.Create))
                //{
                //    carImage.ImagePath.CopyTo(fileStream);
                //}

            
            //var images =  _fileHelpers.Upload(file, wwwRootPath, "IMAGE");

           
                var result = _carImageService.Add(carImage, file,wwwRootPath,"IMAGE");
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
          



        }

        [HttpPost("update")]
        public IActionResult Update(CarImage carImage)
        {
            var result = _carImageService.Update(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        //private string UploadedFile(CarImage carImage)
        //{
        //    string uniqueFileName = null;

        //    if (carImage.ImagePath != null)
        //    {
        //        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + carImage.ImagePath.FileName ;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            carImage.ImagePath.CopyTo(fileStream);
        //        }
        //    }
        //    return uniqueFileName;
        //}
    }
}

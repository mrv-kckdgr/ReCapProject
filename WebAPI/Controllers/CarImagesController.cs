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
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            var result = _carImageService.Add(carImage, file,wwwRootPath,"IMAGE");
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImage carImage, IFormFile file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            var result = _carImageService.Update(carImage, file, wwwRootPath, "IMAGE");
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


        [HttpGet("getcarimagedetails")]
        public IActionResult GetCarImagesDetail()
        {
            var result = _carImageService.GetCarImageDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}

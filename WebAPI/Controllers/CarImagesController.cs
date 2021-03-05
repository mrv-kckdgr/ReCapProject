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

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        IWebHostEnvironment _webHostEnvironment;

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> Add([FromForm] CarImage carImage, [FromForm] byte[] fileName, IFormFile file)
        {


            // Full path to file in temp location
            //var filePath = Path.GetDirectoryName("~\\Images\\");
            var filePath = "~/Images";

            Guid guid = Guid.NewGuid();
            carImage.ImagePath = filePath + "\\" + guid + ".png";

            if (file.Length > 0)
                using (var stream = new FileStream(carImage.ImagePath, FileMode.Create))
                    await file.CopyToAsync(stream);

            // Process uploaded files
            carImage.Date = DateTime.Now;
            //Guid guid = Guid.NewGuid();
            //carImage.ImagePath = "\\Images\\" + guid + ".png" ;
            var result = _carImageService.Add(carImage);
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
    }
}

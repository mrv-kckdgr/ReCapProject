using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();

        IDataResult<CarImage> GetById(int carImageId);

        IResult Add(CarImage carImage, IFormFile file, string path, string fileType);

        IResult Update(CarImage carImage, IFormFile file, string path, string fileType);

        IResult Delete(CarImage carImage);

        IDataResult<List<CarImageDetailDto>> GetCarImageDetails();

    }
}

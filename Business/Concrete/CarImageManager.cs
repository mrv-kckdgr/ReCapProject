using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.FileUpload;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        private FileHelpers _fileHelpers;

        public CarImageManager(ICarImageDal carImageDal, FileHelpers fileHelpers)
        {
            _carImageDal = carImageDal;
            _fileHelpers = fileHelpers;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile file,string path,string fileType)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageCountOfCarCorrect(carImage.CarId), EmptyIfCarImages(carImage.CarId, carImage));

            if (result != null)
            {
                return result;
            }
            var images = _fileHelpers.Upload(file, path, fileType);
            if (images.Success)
            {
                carImage.ImagePath = images.Data.Remove(0,8);
                carImage.Date=DateTime.Now;
                _carImageDal.Add(carImage);

                return new SuccessResult(Messages.CarImageAdded);
            }

            return new ErrorResult(images.Message);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImageDetailDto>> GetCarImageDetails()
        {
            return new SuccessDataResult<List<CarImageDetailDto>>(_carImageDal.GetCarImageDetails(), Messages.CarImageDetailListed);

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            if (DateTime.Now.Hour==01)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == carImageId));
        }

        public IResult Update(CarImage carImage, IFormFile file, string path, string fileType)
        {
            var images = _fileHelpers.Upload(file, path, fileType);
            if (images.Success)
            {
                carImage.ImagePath = images.Data;
                carImage.Date=DateTime.Now;

                _carImageDal.Update(carImage);

                return new SuccessResult(Messages.CarImageUpdated);
            }

            return new ErrorResult(Messages.CarImageNotUpdated);

        }


        //Bir arabanın en fazla 5 resmi olabilir.
        private IResult CheckIfCarImageCountOfCarCorrect(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result>=5)
            {
                return new ErrorResult(Messages.CarImageCountOfCarError);
            }

            return new SuccessResult();
        }

        //Eğer bir arabaya ait resim yoksa, default bir resim gösteriniz.Bu resim şirket logonuz olabilir. Tek elemanlı liste
        private IResult EmptyIfCarImages(int carId, CarImage carImage)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result==0)
            {
                carImage.ImagePath = "~/Images/logo.jpg";
                
            }

            return new SuccessResult(Messages.EmptyIfCarImages);
        }


    }
}

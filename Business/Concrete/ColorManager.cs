using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color_ color)
        {
            if (color.ColorName.Length<2)
            {
                return new ErrorResult(Messages.ColorNameInvalid);
            }
            _colorDal.Add(color);

            return new SuccessResult(Messages.ColorAdded);
        }

        public IDataResult<List<Color_>> GetAll()
        {
            if (DateTime.Now.Hour==11)
            {
                return new ErrorDataResult<List<Color_>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Color_>>(_colorDal.GetAll(), Messages.ColorListed);
        }

        public IDataResult<Color_> GetById(int colorId)
        {
            return new SuccessDataResult<Color_>(_colorDal.Get(c => c.Id == colorId));
        }
    }
}

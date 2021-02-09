using Business.Abstract;
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

        public List<Color_> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color_ GetById(int colorId)
        {
            return _colorDal.Get(c => c.Id == colorId);
        }
    }
}

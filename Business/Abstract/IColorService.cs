using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color_> GetAll();

        Color_ GetById(int colorId);
    }
}

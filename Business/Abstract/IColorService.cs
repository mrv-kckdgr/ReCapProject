﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color_>> GetAll();

        IDataResult<Color_> GetById(int colorId);

        IResult Add(Color_ color);
    }
}

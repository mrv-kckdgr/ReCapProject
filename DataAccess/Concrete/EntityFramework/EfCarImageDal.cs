using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal:EfEntityRepositoryBase<CarImage, ReCapContext>, ICarImageDal
    {
        public List<CarImageDetailDto> GetCarImageDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from i in context.CarImages
                    join c in context.Cars 
                        on i.CarId equals c.Id
                    select new CarImageDetailDto
                    {
                        Id = i.Id,
                        CarId = c.Id,
                        ImagePath = i.ImagePath,
                        Date = i.Date

                    };
                return result.ToList();
            }
        }
    }
}

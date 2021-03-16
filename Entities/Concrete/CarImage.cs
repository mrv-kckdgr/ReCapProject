using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarImage:IEntity
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public IFormFile ImagePath { get; set; }

        public DateTime Date { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarImageDetailDto:IDto
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public string ImagePath { get; set; }

        public DateTime Date { get; set; }
    }
}

using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    class Brand:IEntity
    {
        public int Id { get; set; }

        public string BrandName { get; set; }
    }
}

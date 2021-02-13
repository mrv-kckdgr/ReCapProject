using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();       

            CarDetail();
        }

        private static void CarDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            Console.WriteLine("CarId BrandName ColorName ModelYear DailyPrice Description");
            foreach (var car in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", car.CarId, car.BrandName, car.ColorName, car.ModelYear, car.DailyPrice, car.Description);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            Console.WriteLine("\n************Renkler************");
            Console.WriteLine("ID RENK ");
            foreach (var color in result.Data)
            {
                Console.WriteLine("{0}  {1}", color.Id, color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            Console.WriteLine("************Markalar************");
            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description);
                }
            }

            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}

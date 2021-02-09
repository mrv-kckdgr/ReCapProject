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
            Console.WriteLine("CarId BrandName ColorName ModelYear DailyPrice Description");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", car.CarId, car.BrandName, car.ColorName, car.ModelYear, car.DailyPrice, car.Description);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("\n************Renkler************");
            Console.WriteLine("ID RENK ");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("{0}  {1}", color.Id, color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("************Markalar************");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GellAllByColorId(2))
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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
            //CarDetail();
            //UserTest();
            //AddUser();
            //UserTest();            
            //TestRental();
        }

        private static void CarDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal(), new BrandManager(new EfBrandDal()));
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
            CarManager carManager = new CarManager(new EfCarDal(), new BrandManager(new EfBrandDal()));

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

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            if (result.Success==true)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine(user.FirstName);
                }
               
            }
            Console.WriteLine(result.Message);

        }

        private static void AddUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User 
            { 
                FirstName="Mehmet", 
                LastName="AKDAĞ",
                Email="mehmet@gmail.com",
                Password_="789"
            });
            userManager.Add(new User
            {
                FirstName = "Coşkun", 
                LastName = "YILDIZ",
                Email = "yildiz@gmail.com",
                Password_ = "753"
            });

        }
        

        private static void TestRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            
            var result=rentalManager.GetAll();

            foreach (var rental in result.Data)
            {
                Console.WriteLine("{0} {1} {2}", rental.CarId, rental.CustomerId, rental.RentDate);
            }
            
        }
    }
}

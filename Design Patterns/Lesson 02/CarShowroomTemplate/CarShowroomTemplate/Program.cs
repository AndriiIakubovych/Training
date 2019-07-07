using System;

namespace CarShowroomTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarsInfo carsInfo = new ShowroomProxy();
            Car car;
            Console.Title = "Модель приложения \"Автосалон\"";
            car = carsInfo.GetCar("Brilliance V5 1.5T");
            Console.WriteLine("Название авто: " + car.CarName);
            Console.WriteLine("Тип двигателя: " + car.EngineType);
            Console.WriteLine("Объём двигателя: " + car.EngineVolume);
            Console.WriteLine("Мощность: " + car.Power + " л. с.");
            Console.WriteLine("Разгон до 100 км/ч: " + car.Acceleration + " с");
            Console.WriteLine("Максимальная скорость: " + car.MaxSpeed + " км/ч");
            Console.WriteLine("Объём топливного бака: " + car.FuelTankCapacity + " л");
            Console.WriteLine("Трансмиссия: " + car.Transmission);
            Console.WriteLine("Привод: " + car.Drive);
            Console.WriteLine("Масса: " + car.Weight + " кг");
            Console.WriteLine("Цена: " + car.Price + " грн.");
            Console.ReadKey();
        }
    }
}
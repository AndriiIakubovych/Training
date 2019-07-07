using System;
using System.Collections.Generic;

namespace CarShowroom
{
    interface ICarsInfo : IDisposable
    {
        List<Car> GetCars();
        Car GetCar(string carName);
        int GetMaxCarId();
        void AddCar(Car car);
        void EditCar(Car car);
        void DeleteCar(Car car);
        bool HasCarWithPhoto(string carPhoto);
    }
}
using System.Collections.Generic;
using System.Linq;

namespace CarShowroomTemplate
{
    class ShowroomProxy : ICarsInfo
    {
        private List<Car> carsList;
        private Showroom showroom;

        public ShowroomProxy()
        {
            carsList = new List<Car>();
        }

        public List<Car> GetCars()
        {
            if (showroom == null)
                showroom = new Showroom();
            return showroom.GetCars();
        }

        public Car GetCar(string carName)
        {
            Car car = carsList.Where(c => c.CarName == carName).FirstOrDefault();
            if (car == null)
            {
                if (showroom == null)
                    showroom = new Showroom();
                car = showroom.GetCar(carName);
                carsList.Add(car);
            }
            return car;
        }

        public int GetMaxCarId()
        {
            if (showroom == null)
                showroom = new Showroom();
            return showroom.GetMaxCarId();
        }

        public void AddCar(Car car)
        {
            if (showroom == null)
                showroom = new Showroom();
            showroom.AddCar(car);
        }

        public void EditCar(Car car)
        {
            if (showroom == null)
                showroom = new Showroom();
            showroom.EditCar(car);
        }

        public void DeleteCar(Car car)
        {
            if (showroom == null)
                showroom = new Showroom();
            showroom.DeleteCar(car);
        }

        public bool HasCarWithPhoto(string carPhoto)
        {
            if (showroom == null)
                showroom = new Showroom();
            return showroom.HasCarWithPhoto(carPhoto);
        }

        public void Dispose()
        {
            if (showroom != null)
                showroom.Dispose();
        }
    }
}
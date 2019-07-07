using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace CarShowroomTemplate
{
    class Showroom : ICarsInfo
    {
        private ShowroomContext context;

        public Showroom()
        {
            context = new ShowroomContext();
        }

        public List<Car> GetCars()
        {
            return context.Cars.ToList();
        }

        public Car GetCar(string carName)
        {
            return context.Cars.Where(c => c.CarName == carName).FirstOrDefault();
        }

        public int GetMaxCarId()
        {
            return context.Cars.Count() > 0 ? context.Cars.Select(c => c.CarId).Max() + 1 : 1;
        }

        public void AddCar(Car car)
        {
            context.Cars.Add(car);
            context.SaveChanges();
        }

        public void EditCar(Car car)
        {
            context.Entry(car).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteCar(Car car)
        {
            context.Entry(car).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public bool HasCarWithPhoto(string carPhoto)
        {
            return context.Cars.Where(c => c.CarPhoto == carPhoto).Any();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
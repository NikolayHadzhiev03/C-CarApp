using CarService.DataLayer.localdbbb;
using CarService.Models.DTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Object;

namespace CarService.DataLayer.Repositories
{
    internal class CarRepository : ICarRepository
    {
        public void Addcar(Car car)
        {
            StaticDB.Cars.Add(car);
        }
        public void Deletecar(int id)
        {
            var carToDelete = StaticDB.Cars.FirstOrDefault(c => c.Id == id);
            if (carToDelete != null)
            {
                StaticDB.Cars.Remove(carToDelete);
            }
        }
        public List<Car> GetAllcars()
        {
            return StaticDB.Cars;
        }

    }


}

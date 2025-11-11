using CarService.BL.interfaces;
using CarService.DataLayer.Repositories;
using CarService.Models.DTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.BL.services
{
    internal class CarService : ICarService
    {
        private readonly ICarRepository icarRepository;

        public CarService(ICarRepository carRepository)
        {
            this.icarRepository = icarRepository;
        }
        public CarService() {
            
        }

        public void Addcar(Car car)
        {
            throw new NotImplementedException();
        }

        public void Deletecar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllcars()
        {
            throw new NotImplementedException();
        }
    }
}

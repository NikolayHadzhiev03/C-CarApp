using CarService.BL.Interfaces;
using CarService.DL.Interfaces;
using CarService.Models.Dto;
using System;
using System.Collections.Generic;

namespace CarService.BL.Services
{
    internal class CarCrudService : ICarCrudService
    {
        private readonly ICarRepository _carRepository;

        public CarCrudService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public void AddCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car), "Car cannot be null");
            }
            _carRepository.AddCar(car);
        }

        public void DeleteCar(Guid id)
        {
            _carRepository.DeleteCar(id);
        }

        public List<Car> GetAllCars()
        {
            return _carRepository.GetAllCars();
        }       

        public Car? GetById(Guid id)
        {
            return _carRepository.GetById(id);
        }
    }
}

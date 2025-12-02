using CarService.DL.Interfaces;
using CarService.Models.Dto;
using System;
using System.Collections.Generic;

namespace CarService.DL.Repositories
{
    internal class CarLocalRepository : ICarRepository
    {
        private readonly List<Car> _cars = new();

        public void AddCar(Car car) => _cars.Add(car);

        public void DeleteCar(Guid id) => _cars.RemoveAll(c => c.Id == id);

        public List<Car> GetAllCars() => new List<Car>(_cars);

        public Car? GetById(Guid id) => _cars.Find(c => c.Id == id);
    }
}

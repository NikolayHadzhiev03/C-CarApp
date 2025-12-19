using CarService.Models.Dto;
using System;
using System.Collections.Generic;

namespace CarService.BL.Interfaces
{
    public interface ICarCrudService
    {
        void AddCar(Car car);
        void DeleteCar(Guid id);
        List<Car> GetAllCars();
        Car? GetById(Guid id);
    }
}

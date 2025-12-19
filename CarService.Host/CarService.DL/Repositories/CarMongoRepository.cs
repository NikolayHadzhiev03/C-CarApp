using CarService.DL.Interfaces;
using CarService.Models.Dto;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace CarService.DL.Repositories
{
    internal class CarMongoRepository : ICarRepository
    {
            private readonly ILogger<CarMongoRepository> _logger;
        private readonly IMongoCollection<Car> _carCollection;

        public CarMongoRepository(IMongoDatabase database, ILogger<CarMongoRepository> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            if (database == null) throw new ArgumentNullException(nameof(database));

            // Ensure consistent, explicit collection name
            _carCollection = database.GetCollection<Car>("Cars");
        }

        public void AddCar(Car car)
        {
            if (car == null)
            {
                _logger.LogError("Attempted to add a null car to the MongoDB collection.");
                throw new ArgumentNullException(nameof(car), "Car cannot be null");
            }

            try
            {
                _carCollection.InsertOne(car);
            }
            catch (Exception e)
            {
                _logger.LogError("Error adding car to database: {Message}", e.Message);
                throw;
            }
        }

        public void DeleteCar(Guid id)
        {
            if (id == Guid.Empty) return;

            try
            {
                var deleteResult = _carCollection.DeleteOne(car => car.Id == id);

                if (deleteResult.DeletedCount == 0)
                {
                    _logger.LogWarning($"No car found with Id: {id} to delete.");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error deleting car from database: {Message}", e.Message);
                throw;
            }
        }

        public List<Car> GetAllCars()
        {
            var cars = _carCollection.Find(_ => true).ToList();
            if (cars == null || cars.Count == 0)
            {
                _logger.LogWarning("No cars found in the MongoDB collection.");
                return new List<Car>();
            }
            return cars;
        }

        public Car? GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogWarning("GetById called with an empty Guid.");
                return null;
            }

            try
            {
                var car = _carCollection.Find(c => c.Id == id).FirstOrDefault();
                if (car == null)
                {
                    _logger.LogWarning($"No car found with Id: {id}.");
                }
                return car;
            }
            catch (Exception e)
            {
                _logger.LogError("Error fetching car by Id from database: {Message}", e.Message);
                throw;
            }
        }
    }
}

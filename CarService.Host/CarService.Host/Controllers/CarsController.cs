using CarService.BL.Interfaces;
using CarService.Models.Dto;
using CarService.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using MapsterMapper;

namespace CarService.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarCrudService _carCrudService;
        private readonly IMapper _mapper;
        

        public CarsController(
            ICarCrudService carCrudService, 
            IMapper mapper, 
            ILogger<CarsController> logger)
        {
            _carCrudService = carCrudService;
        }

        [HttpDelete]
        public IActionResult DeleteCar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than zero.");
            }
            var car = _carCrudService.GetById(id);
            if (car == null)
            {
                return NotFound($"Car with ID {id} not found.");
            }
            _carCrudService.DeleteCar(id);
            return Ok();
        }

        [HttpGet(nameof(GetById))]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
            {
               
                return BadRequest("ID must be greater than zero.");
            }

            var car = _carCrudService.GetById(id);
            
            if (car == null)
            {
                return NotFound($"Car with ID {id} not found.");
            }

            return Ok(car);
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var cars = _carCrudService.GetAllCars();
            return Ok(cars);
        }

        [HttpPost]
        public IActionResult AddCar([FromBody] AddCarRequest? carRequest)
        {
            if (carRequest == null)
            {
                return BadRequest("Car data is null.");
            }

            var car = _mapper.Map<Car>(carRequest);
            _carCrudService.AddCar(car);

            //_carCrudService.AddCar(new Car
            //{
            //    Model = carRequest.Model,
            //    Year = carRequest.Year,
            //});

            return Ok();
        }
    }
}

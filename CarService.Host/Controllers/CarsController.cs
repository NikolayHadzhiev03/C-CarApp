using CarService.DataLayer.Repositories;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private readonly ICarRepository _carService;

        public CarsController(ICarRepository carService)
        {
            _carService = carService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var cars = _carService.GetAllcars();
            return Ok(cars);
        }
    }
}

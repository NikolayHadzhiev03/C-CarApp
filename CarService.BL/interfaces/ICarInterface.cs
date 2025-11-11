using CarService.Models.DTL;

namespace CarService.BL.interfaces
{
    internal interface ICarService
    {
        void Addcar(Car car);
        void Deletecar(int id);
        List<Car> GetAllcars();
    }
}
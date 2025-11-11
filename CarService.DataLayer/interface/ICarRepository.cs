using CarService.Models.DTL;

namespace CarService.DataLayer.Repositories
{
    public interface ICarRepository
    {
        void Addcar(Car car);
        void Deletecar(int id);
        List<Car> GetAllcars();
    }
}
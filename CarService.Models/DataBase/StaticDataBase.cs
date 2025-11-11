using CarService.Models.DTL;

namespace CarService.Models.DataBase
{
    public static class StaticDataBase
    {
        public static List<Car> Cars { get; set; } = new List<Car>()
        {
             new Car() { Id=1, Model="BMW", Year=2010 },
             new Car() { Id=2, Model="Audi", Year=2012 },
             new Car() { Id=3, Model="Mercedes", Year=2015 },
         };
    }
}

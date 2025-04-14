using BlazorAPI.IRepo;
using BlazorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Data
{
    public class CarsRepository : ICarsRepository
    {
        private readonly ApplicationDbContext _context;

        public CarsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetAllProductsAsync() => await _context.CarsDb.AsNoTracking().ToListAsync();

        public async Task<Car> GetProductByIdAsync(int id) => await _context.CarsDb.AsNoTracking().FirstOrDefaultAsync(p => p.CarId == id);

        public async Task AddProductAsync(Car product)
        {
            await _context.CarsDb.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveProductAsync(int id)
        {
            var product = await _context.CarsDb.FindAsync(id);
            if (product != null)
            {
                _context.CarsDb.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateProductAsync(Car car)
        {
            var existingCar = await _context.CarsDb.FindAsync(car.CarId);
            if (existingCar != null)
            {
                existingCar.ModelId = car.ModelId;
                existingCar.Price = car.Price;
                existingCar.Year = car.Year;
                existingCar.Color = car.Color;
                existingCar.Status = car.Status;
                existingCar.ImageURL = car.ImageURL;
                existingCar.ManufactureDate = car.ManufactureDate;
                existingCar.Description = car.Description;

                _context.CarsDb.Update(existingCar);
                await _context.SaveChangesAsync();
            }
        }

    }
}

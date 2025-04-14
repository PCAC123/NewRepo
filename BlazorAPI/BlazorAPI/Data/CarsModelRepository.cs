using BlazorAPI.IRepo;
using BlazorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Data
{
    public class CarsModelRepository : ICarsModelRepository
    {
        private readonly ApplicationDbContext _context;

        public CarsModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CarModel>> GetAllCarModelsAsync() => await _context.CarModelsDb.AsNoTracking().ToListAsync();

        public async Task<CarModel> GetCarModelByIdAsync(int id) => await _context.CarModelsDb.AsNoTracking().FirstOrDefaultAsync(p => p.ModelId == id);

        public async Task AddCarModelAsync(CarModel product)
        {
            await _context.CarModelsDb.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCarModelAsync(int id)
        {
            var product = await _context.CarModelsDb.FindAsync(id);
            if (product != null)
            {
                _context.CarModelsDb.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCarModelAsync(CarModel car)
        {
            var existingCar = await _context.CarModelsDb.FindAsync(car.ModelId);
            if (existingCar != null)
            {
                existingCar.StyleId = car.StyleId;
                existingCar.ModelName = car.ModelName;             
                _context.CarModelsDb.Update(existingCar);
                await _context.SaveChangesAsync();
            }
        }

    }

}

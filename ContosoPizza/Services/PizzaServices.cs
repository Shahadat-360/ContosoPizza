using ContosoPizza.Data;
using ContosoPizza.DTOs;
using ContosoPizza.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services
{
    public class PizzaServices
    {
        private readonly PizzaDbContext _db;
        public PizzaServices(PizzaDbContext db)
        {
            _db = db;
        }

        //All Data
        public async Task<List<PizzaDto>> GetAllPizzaAsync(int Page,int PageSize)
        {
            var pizzas = await _db.Pizzas
                                  .Skip((Page-1)*PageSize)
                                  .Take(PageSize)
                                  .ToListAsync();
            return pizzas.Select(pizza => pizza.ToDto()).ToList();
        }

        //Get by Id
        public async Task<PizzaDto> GetByIdAsync(int id)
        {
            var pizza = await _db.Pizzas.FirstOrDefaultAsync(x => x.Id == id);
            return pizza?.ToDto();
        }

        //post 
        public async Task<PizzaDto> PizzaAddAsync(CreatePizzaDto dto)
        {
            var pizza = dto.CreateToEntity();
            await _db.Pizzas.AddAsync(pizza);
            await _db.SaveChangesAsync();
            return pizza.ToDto();
        }

        //put by Id
        public async Task UpdatePizzaAsync(int id,UpdatePizzaDto dto)
        {
            var pizza = await _db.Pizzas.FindAsync(id);
            _db.Entry(pizza)
                .CurrentValues
                .SetValues(dto.UpdateToEntity(id));
            await _db.SaveChangesAsync();
        }

        //delete by Id
        public async Task DeletePizzaById(int id)
        {
            await _db.Pizzas.Where(x => x.Id == id).ExecuteDeleteAsync();
        }
    }
}

using ContosoPizza.Data;
using ContosoPizza.DTOs;
using ContosoPizza.Entities;
using ContosoPizza.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaDbContext _db;
        public PizzaController(PizzaDbContext db) { _db = db; }

        //All Data
        [HttpGet]
        public async Task<ActionResult<List<Pizza>>> GetAll() => Ok(await _db.Pizzas.ToListAsync());
        
        //Get by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> Get(int id) => Ok(await _db.Pizzas.FirstOrDefaultAsync(x => x.Id == id));
        
        //post 
        [HttpPost]
        public async Task<ActionResult> Add(CreatePizzaDto dto)
        {
            var pizza = dto.CreateToEntity();
            await _db.Pizzas.AddAsync(pizza);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Add),new {id=pizza.Id }, dto);
        }

        //put by Id
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id,[FromBody]UpdatePizzaDto dto)
        {
            var pizza = await _db.Pizzas.FindAsync(id);
            _db.Entry(pizza)
                .CurrentValues
                .SetValues(dto.UpdateToEntity(id));
            await _db.SaveChangesAsync();
            return NoContent();
        }

        //delete by Id
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _db.Pizzas.Where(x => x.Id == id).ExecuteDeleteAsync();
        }
    }
}

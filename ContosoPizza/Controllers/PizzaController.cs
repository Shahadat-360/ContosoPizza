using ContosoPizza.Data;
using ContosoPizza.DTOs;
using ContosoPizza.Entities;
using ContosoPizza.Mapping;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private PizzaServices _pizzaServices;
        public PizzaController(PizzaServices pizzaServices) 
        {
            _pizzaServices = pizzaServices;
        }

        //All Data
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<PizzaDto>>> GetAll()
        {
            var pizzas = await _pizzaServices.GetAllPizzaAsync();
            if (pizzas == null || pizzas.Count == 0)
                return NoContent();
            return Ok(pizzas);
        }
        
        //Get by Id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PizzaDto>> Get(int id)
        {
            if (id == 0) return BadRequest();
            var pizza = await _pizzaServices.GetByIdAsync(id);
            return pizza == null ? NotFound() : Ok(pizza);
        }
        
        //post 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Add(CreatePizzaDto dto)
        {
            var pizza = await _pizzaServices.PizzaAddAsync(dto);
            return CreatedAtAction(nameof(Get),new {id=pizza.Id }, dto);
        }

        //put by Id
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update(int id,[FromBody]UpdatePizzaDto dto)
        {
            await _pizzaServices.UpdatePizzaAsync(id, dto);
            return NoContent();
        }

        //delete by Id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task Delete(int id)
        {
            await _pizzaServices.DeletePizzaById(id);
        }
    }
}

using ContosoPizza.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data
{
    public class PizzaDbContext(DbContextOptions<PizzaDbContext> options):DbContext(options)
    {
        public DbSet<Pizza> Pizzas { get; set; }
    }
}

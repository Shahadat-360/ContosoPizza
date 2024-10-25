using ContosoPizza.DTOs;
using ContosoPizza.Entities;

namespace ContosoPizza.Mapping
{
    public static class PizzaMapping
    {
        public static Pizza CreateToEntity(this CreatePizzaDto dto)
        {
            return new()
            {
                Name = dto.Name,
                IsGlutenFree = dto.IsGlutenFree,
                Price = dto.Price,
            };
        }
        public static Pizza UpdateToEntity(this UpdatePizzaDto dto,int id)
        {
            return new()
            {
                Id=id,
                Name=dto.Name,
                IsGlutenFree=dto.IsGlutenFree,
                Price=dto.Price
            };
        }

        public static PizzaDto ToDto(this Pizza pizza)
        {
            return new PizzaDto
            (
                pizza.Id,
                pizza.Name,
                pizza.IsGlutenFree,
                pizza.Price
            );
        }
    }
}

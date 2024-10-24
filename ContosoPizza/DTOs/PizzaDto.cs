using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.DTOs
{
    public record PizzaDto(
        int Id,
        string Name,
        bool IsGlutenFree
        );
}

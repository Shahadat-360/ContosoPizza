using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.DTOs
{
    public record CreatePizzaDto(
        [Required]
        string Name,
        [Required]
        bool IsGlutenFree,
        [Required]
        double Price
        );
}

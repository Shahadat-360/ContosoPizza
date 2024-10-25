namespace ContosoPizza.DTOs
{
    public record UpdatePizzaDto(
        string Name,
        bool IsGlutenFree,
        double Price
        );
}

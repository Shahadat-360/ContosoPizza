namespace ContosoPizza.DTOs
{
    public record CreatePizzaDto(
        string Name,
        bool IsGlutenFree
        );
}

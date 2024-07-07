namespace CoffeeShopAPI.DTO
{
    public record class ProductDetailsDto(
        int Id,
        string Name,
        decimal Price,
        int Volume,
        string Description,
        int CategoryId
    );
}

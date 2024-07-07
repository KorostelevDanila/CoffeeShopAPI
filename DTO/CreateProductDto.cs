namespace CoffeeShopAPI.DTO
{
    public record class CreateProductDto(
        string Name,
        decimal Price,
        int Volume,
        string Description,
        int CategoryId
        );
}

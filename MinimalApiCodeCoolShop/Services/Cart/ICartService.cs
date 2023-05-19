using Domain;

namespace MinimalApiCodeCoolShop.Services.Carts
{
    public interface ICartService
    {
        List<ProductCategory> GetProductCategories();
        List<Supplier> GetSuppliers();
        Product FindProductById(string id);
        bool SaveCartToDb(string UserId, string items);
        string ReadCartFromDb(string UserId);
    }
}
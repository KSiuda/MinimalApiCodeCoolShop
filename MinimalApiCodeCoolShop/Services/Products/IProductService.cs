using Domain;

namespace MinimalApiCodeCoolShop.Services.Products
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        List<ProductCategory> GetProductCategories();
        List<Supplier> GetSuppliers();
        List<Product> GetProductsByCategory(int categoryId);
        List<Product> GetProductsBySupplier(int supplierId);
    }
}

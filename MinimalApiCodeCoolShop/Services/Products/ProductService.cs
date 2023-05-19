using Data;

namespace MinimalApiCodeCoolShop.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly CodecoolshopContext _context;

        public ProductService(CodecoolshopContext context)
        {
            _context = context;
            CodecoolshopContext.IfDbEmptyAddNewItems(context);
        }

        public List<Domain.Product> GetAllProducts()
        {
            var products = _context.Products.ToList();
            return products;
        }

        public List<Domain.ProductCategory> GetProductCategories()
        {
            var productCategories = _context.ProductCategories.ToList();
            return productCategories;
        }

        public List<Domain.Supplier> GetSuppliers()
        {
            var suppliers = _context.Suppliers.ToList();
            return suppliers;
        }

        public List<Domain.Product> GetProductsByCategory(int categoryId)
        {
            var products = _context.Products.Where(p => p.ProductCategory.Id == categoryId).ToList();
            return products;
        }

        public List<Domain.Product> GetProductsBySupplier(int supplierId)
        {
            var products = _context.Products.Where(p => p.Supplier.Id == supplierId).ToList();
            return products;
        }
    }
}

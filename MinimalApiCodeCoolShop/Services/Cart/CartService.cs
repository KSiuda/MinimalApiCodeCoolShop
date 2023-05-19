using Data;
using Domain;

namespace MinimalApiCodeCoolShop.Services.Carts
{
    public class CartService : ICartService
    {
        private CodecoolshopContext _context;

        public CartService(CodecoolshopContext context)
        {
            _context = context;
            CodecoolshopContext.IfDbEmptyAddNewItems(context);
        }

        public List<ProductCategory> GetProductCategories()
        {
            var productCategories = _context.ProductCategories.ToList();
            return productCategories;
        }

        public List<Supplier> GetSuppliers()
        {
            var suppliers = _context.Suppliers.ToList();
            return suppliers;
        }

        public Product FindProductById(string id)
        {
            if (_context.Products.Any(product => product.Id.ToString() == id))
            {
                return _context.Products.First(product => product.Id.ToString() == id);
            }
            throw new ArgumentException("Wrong Id");
        }

        public bool SaveCartToDb(string UserId, string items)
        {
            var cart = new Cart();
            cart.UserId = UserId;
            cart.ItemsJson = items;
            if (_context.Carts.Any(cart => cart.UserId == UserId))
            {
                _context.Carts.First(cart => cart.UserId == UserId).ItemsJson = items;
                _context.SaveChanges();
            }
            else
            {
                _context.Carts.Add(cart);
                _context.SaveChanges();
            }

            return true;
        }
        public string ReadCartFromDb(string UserId)
        {
            var cart = "";
            if (_context.Carts.Any(cart => cart.UserId == UserId))
            {
                cart = _context.Carts.First(cart => cart.UserId == UserId).ItemsJson;
            }
            return cart;
        }
    }
}

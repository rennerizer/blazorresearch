using ShoppingCart.Models;

namespace ShoppingCart.Services
{
    public class CartService : ICartService
    {
        private List<Product> _cart = new();
        public IList<Product> Cart { get { return _cart; } }

        private int _total;
        public int Total { get { return _total; } }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        public void AddProduct(Product product)
        {
            _cart.Add(product);

            _total += product.Price;

            NotifyStateChanged();
        }

        public void DeleteProduct(Product product)
        {
            _cart.Remove(product);

            _total -= product.Price;

            NotifyStateChanged();
        }
    }
}

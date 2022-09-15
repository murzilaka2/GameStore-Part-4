using GameStore.Models;

namespace GameStore.Interfaces
{
    public interface IProduct
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void UpdateAll(Product[] products);
        void DeleteProduct(Product product);
    }
}

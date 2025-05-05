using WebapiProject.Models;

namespace WebapiProject.Repository
{
    public interface IProuductRepository
    {
        void AddProduct(Product product);
        void UpdateProduct(Product product, long? quantityAdded );
        void DeleteProduct(string productId);
        Product GetProductById(string productId);
        List<Product> GetProductByCategory(String Category);
        List<Product> GetProductByName(String Name);
        List<Product> GetProductBySupplier(int SuppId);

        List<Product> GetAllProducts();

        IEnumerable<Product> GetProductsByName(string productName);
    }
}

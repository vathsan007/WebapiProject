using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebapiProject.Models;

namespace WebapiProject.Repository
{
    public class ProductRepository : IProuductRepository
    {
        private readonly ApplicationDbContext db;
        private readonly IStockRepository _stockRepository;
        

        public ProductRepository(IStockRepository stockRepository, ApplicationDbContext db)
        {
            this.db = db;
            _stockRepository = stockRepository;
        }

        public void AddProduct(Product product)
        {
            var existingProduct = db.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                throw new System.Exception("Product already exists.");
            }

            var supplier = db.Suppliers.FirstOrDefault(s => s.SupplierId == product.SupplierId);
            if (supplier == null)
            {
                throw new System.Exception("Supplier not found.");
            }

            db.Database.ExecuteSqlRaw("EXEC AddProduct @p0, @p1, @p2, @p3, @p4,@p5,@p6,@p7",
                product.ProductId,
                product.ProductName, product.Description, product.Category, product.AvailableQuantity, product.UnitPrice, product.SupplierId,product.Image);
        }
        public void UpdateProduct(Product product, long? quantityAdded = null)
        {
            var supplierExists = db.Suppliers.Any(s => s.SupplierId == product.SupplierId);
            if (!supplierExists)
            {
                throw new System.Exception("Supplier not found.");
            }

            var existingProduct = db.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct == null)
            {
                throw new System.Exception("Product not found.");
            }

            db.Database.ExecuteSqlRaw("EXEC UpdateProduct @p0, @p1, @p2, @p3, @p4, @p5, @p6,@p7",
                product.ProductId, product.ProductName, product.Description, product.Category, product.UnitPrice, product.SupplierId, quantityAdded, product.Image);

            if (quantityAdded.HasValue)
            {
                long quantityDifference = quantityAdded.Value;
                //_stockRepository.UpdateStockForProductUpdate(product.ProductId, quantityDifference, DateTime.Now);
            }
        }

        public void DeleteProduct(string productId)
        {
            var product = db.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                throw new System.Exception("Product not found.");
            }

            db.Database.ExecuteSqlRaw("EXEC DeleteProduct @p0", product.ProductId);
        }

        public Product GetProductById(string productId)
        {
            var product = db.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                throw new System.Exception("Product not found.");
            }

            return product;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            var result = db.Products.FromSqlRaw("EXEC GetAllProducts").ToList();

            foreach (var item in result)
            {
                products.Add(new Product
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Description=item.Description,
                    Category=item.Category,
                    AvailableQuantity=item.AvailableQuantity,
                    UnitPrice = item.UnitPrice,
                    SupplierId=item.SupplierId,
                    Image=item.Image,
                });
            }

            return products;

        }

        public List<Product> GetProductByName(string PName)
        {
            var products = db.Products.Where(p => p.ProductName == PName).ToList();
            if (products == null || products.Count == 0)
            {
                throw new System.Exception("No products found with the given name.");
            }

            return products;
        }

        public List<Product> GetProductBySupplier(int SuppId)
        {
            var products = db.Products.Where(p => p.SupplierId == SuppId).ToList();
            if (products == null || products.Count == 0)
            {
                throw new System.Exception("No products found for the given supplier.");
            }

            return products;
        }

        public List<Product> GetProductByCategory(string Category)
        {
            var products = db.Products.Where(p => p.Category == Category).ToList();
            if (products == null || products.Count == 0)
            {
                throw new System.Exception("No products found in the given category.");
            }

            return products;
        }

        public IEnumerable<Product> GetProductsByName(string productName)
        {
            return db.Products
            .FromSqlRaw("EXEC GetProductsByName @p0", productName)
            .ToList();
        }


        
    }
}

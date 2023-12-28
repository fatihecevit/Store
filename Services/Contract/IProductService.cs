using Entities.Models;

namespace Services.Contract
{
    public interface IProductService{

        IEnumerable<Product> GelAllProducts(bool trackChanges);

        Product? GetOneProduct(int id, bool trackChanges); 

        void CreateProduct(Product product);
        void UpdateOneProduct(Product product);
        void DeleteOneProduct(int id);
    }

}
using Entities.Models;

namespace Services.Contract
{
    public interface ICategoryService{

        IEnumerable<Category> GetAllCategories(bool trackChanges);
    }
}
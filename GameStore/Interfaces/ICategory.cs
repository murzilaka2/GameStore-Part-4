using GameStore.Models;

namespace GameStore.Interfaces
{
    public interface ICategory
    {
        IEnumerable<Category> GetAllCategories();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }

}

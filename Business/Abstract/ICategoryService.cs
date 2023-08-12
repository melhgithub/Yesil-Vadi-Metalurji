using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task CategoryAdd(Category category);
        Task CategoryDelete(Category category);
        Task CategoryUpdate(Category category);
        Task<List<string>> GetCategoryNames();
        Task<Category> GetByID(int ID);
        Task<int> GetCategoryIdByName(string categoryName);
        Task<List<Category>> GetList();
        Task<Category> GetCategoryByName(string Name);
    }
}

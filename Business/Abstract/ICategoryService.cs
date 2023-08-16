using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService : GenericService<Category>
    {
        //Task CategoryAdd(Category category);
        //Task CategoryDelete(Category category);
        //Task CategoryUpdate(Category category);
        //Task<Category> GetByID(int ID);
        //Task<List<Category>> GetList();

        Task<int> GetCategoryIdByName(string categoryName);
        Task<List<string>> GetCategoryNames();
        Task<Category> GetCategoryByName(string Name);
    }
}

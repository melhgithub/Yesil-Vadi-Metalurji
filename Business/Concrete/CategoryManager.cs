using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }


        public async Task CategoryAdd(Category category)
        {
            await _categoryDal.Insert(category);
        }

        public async Task CategoryDelete(Category category)
        {
            category.Status = (CategoryStatuses)2;
            category.Active = false;
            await _categoryDal.Update(category);
        }

        public async Task CategoryUpdate(Category category)
        {
            await _categoryDal.Update(category);
        }

        public async Task<List<string>> GetCategoryNames()
        {
            return await _categoryDal.GetCategoryNames();
        }

        public async Task<Category> GetByID(int ID)
        {
            return await _categoryDal.GetByID(ID);
        }

        public async Task<int> GetCategoryIdByName(string categoryName)
        {
            var category = await _categoryDal.GetCategoryByName(categoryName);
            return category != null ? category.ID : 0;
        }
        public async Task<List<Category>> GetList()
        {
            return await _categoryDal.GetList();
        }

        public async Task<Category> GetCategoryByName(string Name)
        {
            return await _categoryDal.GetCategoryByName(Name);
        }
    }
}

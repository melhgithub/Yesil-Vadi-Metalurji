using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task Insert(T t);
        Task Delete(T t);
        Task Update(T t);
        Task<List<T>> GetList();
        Task<T> GetByID(int ID);

        Task<List<Product>> GetListWithIncludesForProduct();
        Task<List<OfferDetail>> GetOfferDetailsByOfferID(int offerID);

        Task<List<string>> GetCategoryNames();
        Task<List<string>> GetAdminNames();
        Task<List<string>> GetProductNames();

        Task<Category> GetCategoryByName(string Name);
        Task<Admin> GetAdminByName(string Name);
        Task<Product> GetProductByName(string Name);


    }
}

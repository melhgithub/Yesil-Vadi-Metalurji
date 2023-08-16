using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService : GenericService<Product>
    {
        //Task ProductAdd(Product product);
        //Task ProductDelete(Product product);
        //Task ProductUpdate(Product product);
        //Task<List<Product>> GetList();
        //Task<Product> GetByID(int ID);

        Task<List<Product>> GetListWithIncludes();
        Task<Product> GetProductByName(string Name);

    }
}

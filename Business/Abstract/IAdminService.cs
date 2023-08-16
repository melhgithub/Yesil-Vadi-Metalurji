using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService : GenericService<Admin>
    {
        //    Task AdminAdd(Admin admin);
        //    Task AdminDelete(Admin admin);
        //    Task AdminUpdate(Admin admin);
        //    Task<Admin> GetByID(int ID);
        //    Task<List<Admin>> GetList();

        Task<List<string>> GetAdminNames();
        Task<int> GetAdminIdByName(string AdminName);
        Task<Admin> GetAdminByName(string Name);

    }
}

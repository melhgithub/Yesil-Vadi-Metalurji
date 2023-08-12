using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService
    {
        Task AdminAdd(Admin admin);
        Task AdminDelete(Admin admin);
        Task AdminUpdate(Admin admin);
        Task<List<string>> GetAdminNames();
        Task<Admin> GetByID(int ID);
        Task<int> GetAdminIdByName(string AdminName);
        Task<List<Admin>> GetList();
        Task<Admin> GetAdminByName(string Name);

    }
}

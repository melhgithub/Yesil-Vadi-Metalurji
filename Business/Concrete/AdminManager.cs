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
    public class AdminManager : IAdminService
    {

        IAdminDal _adminDal;


        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public async Task Add(Admin admin)
        {
            await _adminDal.Insert(admin);
        }

        public async Task Delete(Admin admin)
        {
            admin.Active = false;
            await _adminDal.Update(admin);
        }

        public async Task Update(Admin admin)
        {
            await _adminDal.Update(admin);
        }

        public async Task<Admin> GetByID(int ID)
        {
            return await _adminDal.GetByID(ID);
        }

        public async Task<List<Admin>> GetList()
        {
            return await _adminDal.GetList();
        }

        public async Task<Admin> GetAdminByName(string Name)
        {
            return await _adminDal.GetAdminByName(Name);
        }

        public async Task<int> GetAdminIdByName(string AdminName)
        {
            var category = await _adminDal.GetCategoryByName(AdminName);
            return category != null ? category.ID : 0;
        }

        public async Task<List<string>> GetAdminNames()
        {
            return await _adminDal.GetAdminNames();
        }
    }
}

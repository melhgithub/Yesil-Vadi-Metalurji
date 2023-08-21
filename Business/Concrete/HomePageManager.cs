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
    public class HomePageManager : IHomePageService
    {

        IHomePageDal _homePageDal;


        public HomePageManager(IHomePageDal homePageDal)
        {
            _homePageDal = homePageDal;
        }

        public async Task Add(HomePage homepage)
        {
            await _homePageDal.Insert(homepage);
        }

        public async Task Delete(HomePage homepage)
        {
            await _homePageDal.Update(homepage);
        }

        public async Task Update(HomePage homepage)
        {
            await _homePageDal.Update(homepage);
        }

        public async Task<HomePage> GetByID(int ID)
        {
            return await _homePageDal.GetByID(ID);
        }

        public async Task<List<HomePage>> GetList()
        {
            return await _homePageDal.GetList();
        }
    }
}

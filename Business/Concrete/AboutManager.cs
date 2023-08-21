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
    public class AboutManager : IAboutService
    {

        IAboutDal _aboutDal;


        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public async Task Add(About about)
        {
            await _aboutDal.Insert(about);
        }

        public async Task Delete(About about)
        {
            await _aboutDal.Update(about);
        }

        public async Task Update(About about)
        {
            await _aboutDal.Update(about);
        }

        public async Task<About> GetByID(int ID)
        {
            return await _aboutDal.GetByID(ID);
        }

        public async Task<List<About>> GetList()
        {
            return await _aboutDal.GetList();
        }
    }
}

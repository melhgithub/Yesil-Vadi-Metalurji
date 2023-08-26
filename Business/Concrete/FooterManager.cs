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
    public class FooterManager : IFooterService
    {

        IFooterDal _footerDal;


        public FooterManager(IFooterDal footerDal)
        {
            _footerDal = footerDal;
        }

        public async Task Add(Footer footer)
        {
            await _footerDal.Insert(footer);
        }

        public async Task Delete(Footer footer)
        {
            await _footerDal.Update(footer);
        }

        public async Task Update(Footer footer)
        {
            await _footerDal.Update(footer);
        }

        public async Task<Footer> GetByID(int ID)
        {
            return await _footerDal.GetByID(ID);
        }

        public async Task<List<Footer>> GetList()
        {
            return await _footerDal.GetList();
        }
    }
}

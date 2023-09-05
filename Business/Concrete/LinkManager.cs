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
    public class LinkManager : ILinkService
    {

        ILinkDal _linkDal;


        public LinkManager(ILinkDal linkDal)
        {
            _linkDal = linkDal;
        }

        public async Task Add(Link link)
        {
            await _linkDal.Insert(link);
        }

        public async Task Delete(Link link)
        {
            await _linkDal.Update(link);
        }

        public async Task Update(Link link)
        {
            await _linkDal.Update(link);
        }

        public async Task<Link> GetByID(int ID)
        {
            return await _linkDal.GetByID(ID);
        }

        public async Task<List<Link>> GetList()
        {
            return await _linkDal.GetList();
        }
    }
}

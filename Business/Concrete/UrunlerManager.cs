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
    public class UrunlerManager : IUrunlerService
    {

        IUrunlerDal _urunlerDal;


        public UrunlerManager(IUrunlerDal urunlerDal)
        {
            _urunlerDal = urunlerDal;
        }

        public async Task Add(Urunler urunler)
        {
            await _urunlerDal.Insert(urunler);
        }

        public async Task Delete(Urunler urunler)
        {
            await _urunlerDal.Update(urunler);
        }

        public async Task Update(Urunler urunler)
        {
            await _urunlerDal.Update(urunler);
        }

        public async Task<Urunler> GetByID(int ID)
        {
            return await _urunlerDal.GetByID(ID);
        }

        public async Task<List<Urunler>> GetList()
        {
            return await _urunlerDal.GetList();
        }
    }
}

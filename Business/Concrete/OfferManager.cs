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
    public class OfferManager : IOfferService
    {
        IOfferDal _offerDal;

        public OfferManager(IOfferDal offerDal)
        {
            _offerDal = offerDal;
        }

        public async Task<Offer> GetByID(int ID)
        {
            return await _offerDal.GetByID(ID);
        }

        public async Task<List<Offer>> GetList()
        {
            return await _offerDal.GetList();
        }

        public async Task Add(Offer offer)
        {
            await _offerDal.Insert(offer);
        }

        public async Task Delete(Offer offer)
        {
            offer.Status = (OfferStatuses)2;
            offer.Active = false;
            await _offerDal.Update(offer);
        }

        public async Task Update(Offer offer)
        {
            await _offerDal.Update(offer);
        }
    }
}

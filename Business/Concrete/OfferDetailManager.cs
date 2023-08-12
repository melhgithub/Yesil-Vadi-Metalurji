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
    public class OfferDetailManager : IOfferDetailService
    {
        IOfferDetailDal _offerDetailDal;

        public OfferDetailManager(IOfferDetailDal offerDetailDal)
        {
            _offerDetailDal = offerDetailDal;
        }

        public async Task<OfferDetail> GetByID(int ID)
        {
            return await _offerDetailDal.GetByID(ID);
        }

        public async Task<List<OfferDetail>> GetList()
        {
            return await _offerDetailDal.GetList();
        }

        public async Task<List<OfferDetail>> GetOfferDetailsByOfferID(int offerID)
        {
            return await _offerDetailDal.GetOfferDetailsByOfferID(offerID);
        }

        public async Task OfferDetailAdd(OfferDetail offerDetail)
        {
            await _offerDetailDal.Insert(offerDetail);
        }

        public async Task OfferDetailDelete(OfferDetail offerDetail)
        {
            await _offerDetailDal.Delete(offerDetail);
        }

        public async Task OfferDetailUpdate(OfferDetail offerDetail)
        {
            await _offerDetailDal.Update(offerDetail);
        }
    }
}

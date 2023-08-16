using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOfferDetailService : GenericService<OfferDetail>
    {
        //Task OfferDetailAdd(OfferDetail offerDetail);
        //Task OfferDetailDelete(OfferDetail offerDetail);
        //Task OfferDetailUpdate(OfferDetail offerDetail);
        //Task<OfferDetail> GetByID(int ID);
        //Task<List<OfferDetail>> GetList();


        Task<List<OfferDetail>> GetOfferDetailsByOfferID(int offerID);
    }
}

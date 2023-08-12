﻿using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOfferService
    {
        Task OfferAdd(Offer offer);
        Task OfferDelete(Offer offer);
        Task OfferUpdate(Offer offer);
        Task<List<Offer>> GetList();
        Task<Offer> GetByID(int ID);
    }
}

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
    public class ProductionManager : IProductionService
    {
        IProductionDal _productionDal;

        public ProductionManager(IProductionDal productionDal)
        {
            _productionDal = productionDal;
        }

        public async Task<Production> GetByID(int ID)
        {
            return await _productionDal.GetByID(ID);
        }

        public async Task<List<Production>> GetList()
        {
            return await _productionDal.GetList();
        }

        public async Task ProductionAdd(Production production)
        {
            await _productionDal.Insert(production);
        }

        public async Task ProductionDelete(Production production)
        {
            production.Status = (ProductionStatuses)2;
            production.Active = false;
            await _productionDal.Update(production);
        }

        public async Task ProductionUpdate(Production production)
        {
            await _productionDal.Update(production);
        }
    }
}

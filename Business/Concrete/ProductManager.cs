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
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task<Product> GetByID(int ID)
        {
            return await _productDal.GetByID(ID);
        }

        public async Task<List<Product>> GetList()
        {
            return await _productDal.GetList();
        }

        public async Task<List<Product>> GetListWithIncludes()
        {
            return await _productDal.GetListWithIncludesForProduct();
        }

        public async Task<Product> GetProductByName(string Name)
        {
            return await _productDal.GetProductByName(Name);
        }
        public async Task Add(Product product)
        {
            await _productDal.Insert(product);
        }

        public async Task Delete(Product product)
        {
            product.Status = (ProductStatuses)2;
            product.Active = false;
            await _productDal.Update(product);
        }

        public async Task Update(Product product)
        {
            await _productDal.Update(product);
        }

        public Task<Product> CheckProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetLast3Product()
        {
            var products = await _productDal.GetList();
            var latestProducts = products.OrderByDescending(p => p.CreateDate)
                .Take(3)
                .ToList();

            return latestProducts;
        }
    }
}

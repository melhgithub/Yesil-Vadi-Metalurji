using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly Context _context;
        private readonly DbSet<T> _dbSet;

        protected Context c = new Context();
        public async Task<T> GetByID(int ID)
        {
            return await c.Set<T>().FindAsync(ID);
        }

        public async Task<List<T>> GetList()
        {
            return await c.Set<T>().ToListAsync();
        }

        public async Task Insert(T t)
        {
            c.Add(t);
            await c.SaveChangesAsync();
        }

        public async Task Update(T t)
        {
            c.Update(t);
            await c.SaveChangesAsync();
        }

        public async Task Delete(T t)
        {
            c.Remove(t);
            await c.SaveChangesAsync();
        }


        public async Task<List<string>> GetCategoryNames()
        {
            return await c.Categories.Select(c => c.Name).ToListAsync();
        }

        public async Task<List<string>> GetProductNames()
        {
            return await c.Products.Select(c => c.Name).ToListAsync();
        }

        public async Task<List<string>> GetAdminNames()
        {
            return await c.Admins.Select(c => c.UserName).ToListAsync();
        }


        public async Task<Category> GetCategoryByName(string Name)
        {
            return await c.Categories.FirstOrDefaultAsync(c => c.Name == Name);
        }

        public async Task<Product> GetProductByName(string Name)
        {
            return await c.Products.FirstOrDefaultAsync(c => c.Name == Name);
        }


        public async Task<Admin> GetAdminByName(string Name)
        {
            return await c.Admins.FirstOrDefaultAsync(c => c.UserName == Name);
        }




        public async Task<List<Product>> GetListWithIncludesForProduct()
        {
            return await c.Products.Include(p => p.Category)
                                         .ToListAsync();
        }

        public async Task<List<OfferDetail>> GetOfferDetailsByOfferID(int offerID)
        {
            return await c.OfferDetails.Where(p => p.OfferID == offerID).ToListAsync();
        }
    }
}

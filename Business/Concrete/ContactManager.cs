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
    public class ContactManager : IContactService
    {

        IContactDal _contactDal;


        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task Add(Contact contact)
        {
            await _contactDal.Insert(contact);
        }

        public async Task Delete(Contact contact)
        {
            await _contactDal.Update(contact);
        }

        public async Task Update(Contact contact)
        {
            await _contactDal.Update(contact);
        }

        public async Task<Contact> GetByID(int ID)
        {
            return await _contactDal.GetByID(ID);
        }

        public async Task<List<Contact>> GetList()
        {
            return await _contactDal.GetList();
        }
    }
}

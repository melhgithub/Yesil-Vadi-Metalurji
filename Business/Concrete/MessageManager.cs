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
    public class MessageManager : IMessageService
    {

        IMessageDal _messageDal;


        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public async Task Add(Message message)
        {
            await _messageDal.Insert(message);
        }

        public async Task Delete(Message message)
        {
            await _messageDal.Update(message);
        }

        public async Task Update(Message message)
        {
            await _messageDal.Update(message);
        }

        public async Task<Message> GetByID(int ID)
        {
            return await _messageDal.GetByID(ID);
        }

        public async Task<List<Message>> GetList()
        {
            return await _messageDal.GetList();
        }
    }
}

using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        Task OrderAdd(Order order);
        Task OrderDelete(Order order);
        Task OrderUpdate(Order order);
        Task<List<Order>> GetList();
        Task<Order> GetByID(int ID);
    }
}

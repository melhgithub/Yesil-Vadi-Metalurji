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
    public class OrderManager : IOrderService
    {

        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public async Task<Order> GetByID(int ID)
        {
            return await _orderDal.GetByID(ID);
        }

        public async Task<List<Order>> GetList()
        {
            return await _orderDal.GetList();
        }
        public async Task Add(Order order)
        {
            await _orderDal.Insert(order);
        }

        public async Task Delete(Order order)
        {
            order.Status = (OrderStatuses)2;
            order.Active = false;
            await _orderDal.Update(order);
        }
        public async Task Update(Order order)
        {
            await _orderDal.Update(order);
        }
    }
}

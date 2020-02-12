using System.Collections.Generic;
using System.Linq;
using WebAppNetCore1.Contexto;
using WebAppNetCore1.Interfaces;
using WebAppNetCore1.Models;

namespace WebAppNetCore1.Services
{
    public class SaleOrderService : ISaleOrderService
    {
        private readonly IContextoDB _contextoDB;

        public SaleOrderService(IContextoDB contextoDB)
        {
            _contextoDB = contextoDB;
        }

        public int AddSaleOrder(SaleOrder saleOrder)
        {
            _contextoDB.SaleOrders.Add(saleOrder);
            _contextoDB.SaveChanges();

            return saleOrder.Id;
        }

        public IEnumerable<SaleOrder> GetSaleOrders()
        {
            return _contextoDB.SaleOrders.AsQueryable().ToList();
        }

        public SaleOrder Update(SaleOrder saleOrder)
        {
            var saleUpd = _contextoDB.SaleOrders.Update(saleOrder).Entity;
            _contextoDB.SaveChanges();

            return saleUpd;
        }

        public SaleOrder GetById(int saleOrderId)
        {
            return _contextoDB.SaleOrders.Where(s => s.Id == saleOrderId).FirstOrDefault();
        }
    }
}

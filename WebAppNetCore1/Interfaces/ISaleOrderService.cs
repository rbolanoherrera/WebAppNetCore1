using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppNetCore1.Models;

namespace WebAppNetCore1.Interfaces
{
    public interface ISaleOrderService
    {
        int AddSaleOrder(SaleOrder saleOrder);
        IEnumerable<SaleOrder> GetSaleOrders();
        SaleOrder Update(SaleOrder saleOrder);
    }
}

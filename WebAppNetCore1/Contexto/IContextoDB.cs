using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebAppNetCore1.Models;

namespace WebAppNetCore1.Contexto
{
    public interface IContextoDB
    {

        DbSet<SaleOrder> SaleOrders { get; set; }

        int SaveChanges();
        
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    }
}

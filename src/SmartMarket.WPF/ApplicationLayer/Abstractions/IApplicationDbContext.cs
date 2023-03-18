using Microsoft.EntityFrameworkCore;
using SmartMarket.WPF.DomainLayer.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SmartMarket.WPF.ApplicationLayer.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

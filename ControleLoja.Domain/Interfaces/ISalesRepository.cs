using ControleLoja.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleLoja.Domain.Interfaces
{
    public interface ISalesRepository
    {
        Task<IEnumerable<Sales>> GetSalesAsync();
        Task<Sales> GetByIdAsync(int? id);

        //Task<Product> GetProductCategoryAsync(int? id);

        Task<Sales> CreateAsync(Sales sales);
        Task<Sales> UpdateAsync(Sales sales);
        Task<Sales> RemoveAsync(Sales sales);
    }
}

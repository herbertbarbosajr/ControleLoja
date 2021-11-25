using ControleLoja.Domain.Entities;
using ControleLoja.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLoja.Infra.Data.Repositories
{
    public class SalesRepository
    {
        protected readonly ApplicationDbContext context;
        public SalesRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }


        //FINDERS
        public async Task<IEnumerable<Sales>> FindAllAsync()
        {
            return await context.Sales.ToListAsync();

        }
        public async Task<IEnumerable<Sales>> FindByDateCreation(DateTime dateTime)
        {
            return await context.Sales.Where(sale => sale.CreatedAt == dateTime).ToListAsync();
        }

        public async Task<Sales> FindById(int id)
        {
            return await context.Sales.FirstOrDefaultAsync(sale => sale.Id == id);
        }

        public async Task<IEnumerable<Sales>> FindByIdProduct(Guid id)
        {
            return await context.Sales.Where(sale => sale.IdProduct == id).ToListAsync();

        }

        public async Task<IEnumerable<Sales>> FindByNameClient(string name)
        {
            return await context.Sales.Where(
                sale => EF.Functions.Like(sale.NameClient, "%" + name + "%")
                ).ToListAsync();
        }

        public async Task<IEnumerable<Sales>> FindByQtd(int qtd)
        {
            return await context.Sales.Where(sale => sale.Qtd == qtd).ToListAsync();
        }

        //OTHERS
        public async Task<Sales> Create(Sales sale)
        {
            var item = await context.AddAsync(sale);
            return (await context.SaveChangesAsync() > 0) ? item.Entity : null;
        }

        public async Task<bool> DeleteAsync(Sales sale)
        {
            context.Sales.Remove(sale);
            return (await context.SaveChangesAsync() > 0);
        }
        public async Task<Sales> Update(Sales sale)
        {
            var item = context.Update(sale);
            return (await context.SaveChangesAsync() > 0) ? item.Entity : null;
        }
    }
}

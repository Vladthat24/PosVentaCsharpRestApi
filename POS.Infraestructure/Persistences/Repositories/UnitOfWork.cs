using POS.Domain.Entities;
using POS.Infraestructure.Persistences.Contexts;
using POS.Infraestructure.Persistences.Interfaces;

namespace POS.Infraestructure.Persistences.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly POSContext _context;

        public ICategoryRepository Category {  get; private set; }

        public UnitOfWork(POSContext context)
        {
            _context = context;
            Category= new CategoryRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
            //GC.SuppressFinalize(this);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

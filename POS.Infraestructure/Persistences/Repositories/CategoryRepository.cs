using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infraestructure.Commons.Bases.Request;
using POS.Infraestructure.Commons.Bases.Response;
using POS.Infraestructure.Persistences.Contexts;
using POS.Infraestructure.Persistences.Interfaces;

namespace POS.Infraestructure.Persistences.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(POSContext context) : base(context) { }
        public async Task<BaseEntityResponse<Category>> ListCategorias(BaseFilterRequest filters)
        {
            var response = new BaseEntityResponse<Category>();

            //var categories=(from c in _context.Categories
            //                where c.AuditDeleteDate==null && c.AuditDeleteDate==null
            //                select c).AsNoTracking().AsQueryable();

            var categories = GetEntityQuery(x => x.AuditDeleteUser == null && x.AuditDeleteDate == null);

            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.Textfilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        categories = categories.Where(x => x.Name!.Contains(filters.Textfilter));
                        break;
                    case 2:
                        categories = categories.Where(x => x.Description!.Contains(filters.Textfilter));
                        break;
                }
            }

            if (filters.StateFiler is not null)
            {
                categories = categories.Where(x => x.State.Equals(filters.StateFiler));
            }
            if (!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
            {
                categories = categories.Where(x => x.AuditCreateDate >= Convert.ToDateTime(filters.StartDate) && x.AuditCreateDate <= Convert.ToDateTime(filters.EndDate).AddDays(1));
            }

            if (filters.Sort is null)
            {
                filters.Sort = "Id";
            }
            response.TotalRecord = await categories.CountAsync();
            response.Items = await Orderning(filters, categories, !(bool)filters.Download!).ToListAsync();

            return response;
        }


    }
}

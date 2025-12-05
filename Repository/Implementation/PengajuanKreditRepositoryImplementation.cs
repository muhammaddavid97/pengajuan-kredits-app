using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SkyWorkTask.Model;
using SkyWorkTask.Model.Context;
using System.Drawing.Printing;

namespace SkyWorkTask.Repository.Implementation
{
    public class PengajuanKreditRepositoryImplementation : IPengajuanKreditRepository
    {

        private readonly PengajuanKreditContext _context;

        // Dependency Injection via constructor
        public PengajuanKreditRepositoryImplementation(PengajuanKreditContext context)
        {
            _context = context;
        }
        public async Task AddNewDataAsync(PengajuanKredit model)
        {
           
           await _context.PengajuanKredits.AddAsync(model);

           await _context.SaveChangesAsync();
        }

        public async Task DeleteDataAsync(int id)
        {
           await _context.PengajuanKredits
                .Where(i => i.Id.Equals(id))
                .ExecuteDeleteAsync();                
        }

        public async Task<IEnumerable<PengajuanKredit>> GetAllDataAsync(int page, int pageSize)
        {
            var data = await _context.PengajuanKredits
                        .AsNoTracking()
                        .OrderBy(x => x.CreatedAt)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();

            return data;
        }

        public async Task<PengajuanKredit> GetDataByIdAsync(int id)
        {
            var data = await _context.PengajuanKredits
                 .Where(item => item.Id.Equals(id))
                 .AsNoTracking()
                 .FirstOrDefaultAsync();

            return data;
        }

        public async Task UpdateDataAsync(PengajuanKredit model)
        {
            await _context.PengajuanKredits
                 .Where(i => i.Id == model.Id)
                 .ExecuteUpdateAsync(x => x
                    .SetProperty(y => y.Id, model.Id)
                    .SetProperty(y => y.Angsuran, model.Angsuran)
                    .SetProperty(y => y.Plafon, model.Plafon)
                    .SetProperty(y => y.Bunga, model.Bunga)
                    .SetProperty(y => y.Tenor, model.Tenor)
                    .SetProperty(y => y.UpdateAt, DateTime.UtcNow)
                 );
        }
    }
}

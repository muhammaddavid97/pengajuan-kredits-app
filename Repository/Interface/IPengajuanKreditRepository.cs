using SkyWorkTask.Model;

namespace SkyWorkTask.Repository
{
    public interface IPengajuanKreditRepository
    {
        Task<IEnumerable<PengajuanKredit>> GetAllDataAsync(int page, int pageSize);
        Task<PengajuanKredit> GetDataByIdAsync(int id);
        Task AddNewDataAsync(PengajuanKredit model);
        Task UpdateDataAsync (PengajuanKredit model);
        Task DeleteDataAsync (int id);
    }
}

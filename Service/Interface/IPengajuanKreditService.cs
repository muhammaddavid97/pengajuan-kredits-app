using SkyWorkTask.dto;
using SkyWorkTask.Model;

namespace SkyWorkTask.Service.Interface
{
    public interface IPengajuanKreditService
    {
        Task<IEnumerable<PengajuanKreditDTO>> GetAllDataAsync(int page, int pageSize);
        Task<PengajuanKreditDTO> GetDataByIdAsync(int id);
        Task AddNewDataAsync(PengajuanKreditDTO data);
        Task  UpdateDataAsync(PengajuanKreditDTO data);
        Task DeleteDataAsync(int id);
        Task<PengajuanKreditDTO> AngsuranPerbulan(PengajuanKreditDTO data);

    }
}

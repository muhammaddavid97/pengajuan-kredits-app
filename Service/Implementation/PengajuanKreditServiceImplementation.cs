using SkyWorkTask.dto;
using SkyWorkTask.Model;
using SkyWorkTask.Repository;
using SkyWorkTask.Service.Interface;

namespace SkyWorkTask.Service.Implementation
{
    public class PengajuanKreditServiceImplementation : IPengajuanKreditService
    {

        private readonly IPengajuanKreditRepository _pengajuanKreditRepository;
        public PengajuanKreditServiceImplementation(IPengajuanKreditRepository pengajuanKreditRepository)
        {
            _pengajuanKreditRepository = pengajuanKreditRepository;
        }
        public async Task AddNewDataAsync(PengajuanKreditDTO data)
        {
            if (data == null) 
                throw new ArgumentNullException("data");

            if (data.Plafon < 0 || data.Bunga < 0 || data.Tenor < 0)
                throw new ArgumentOutOfRangeException("Number can't negative");
            

            var newData = new PengajuanKredit
            {
                Id = data.Id,
                Bunga = data.Bunga,
                Angsuran = data.Angsuran,
                Plafon = data.Plafon,
                Tenor = data.Tenor,
                CreatedAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            await _pengajuanKreditRepository.AddNewDataAsync(newData);
        }

        public async Task DeleteDataAsync(int id)
        {
            var getData = await _pengajuanKreditRepository.GetDataByIdAsync(id);

            if (getData == null) 
                throw new KeyNotFoundException("Data Not Found");

            await _pengajuanKreditRepository.DeleteDataAsync(getData.Id);
        }

        public async Task<IEnumerable<PengajuanKreditDTO>> GetAllDataAsync(int page, int pageSize)
        {
            var getData = await _pengajuanKreditRepository.GetAllDataAsync(page, pageSize);
            
            if (getData == null || getData.Count() < 0)
            {
                throw new KeyNotFoundException("Data Not Found");
            }

            return getData.Select(item => new PengajuanKreditDTO
            {
                Id = item.Id,
                Angsuran = item.Angsuran,
                Bunga = item.Bunga,
                Plafon = item.Plafon,
                Tenor = item.Tenor,
                CreatedAt = item.CreatedAt,
                UpdateAt = item.UpdateAt
            });
        }

        public async Task<PengajuanKreditDTO> GetDataByIdAsync(int id)
        {
           var getData = await _pengajuanKreditRepository.GetDataByIdAsync(id);

            if (getData == null)
                throw new KeyNotFoundException("Data Not Found");

            var results = new PengajuanKreditDTO
            {
                Id = getData.Id,
                Angsuran = getData.Angsuran,
                Bunga = getData.Bunga,
                Plafon = getData.Plafon,
                Tenor = getData.Plafon,
                CreatedAt = getData.CreatedAt,
                UpdateAt = getData.UpdateAt
            };

            return results;
        }

        public async Task UpdateDataAsync(PengajuanKreditDTO data)
        {
            var getData = await _pengajuanKreditRepository.GetDataByIdAsync(data.Id);

            if (data.Plafon < 0 || data.Bunga < 0 || data.Tenor < 0)
                throw new ArgumentOutOfRangeException("Number can't negative");

            if (getData == null) 
                throw new KeyNotFoundException("Data Not Found");

            getData = new PengajuanKredit
            {
                Id = data.Id,
                Angsuran = data.Angsuran,
                Bunga = data.Bunga,
                Plafon = data.Plafon,
                Tenor = data.Tenor,
                CreatedAt = data.CreatedAt,
                UpdateAt = data.UpdateAt
            };

            await _pengajuanKreditRepository.UpdateDataAsync(getData);
        }
    }
}

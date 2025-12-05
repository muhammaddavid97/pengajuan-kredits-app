using SkyWorkTask.dto;

namespace SkyWorkTask.Body
{
    public class GetPengajuanKreditResponse
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<PengajuanKreditDTO> Items { get; set; }
    }
}

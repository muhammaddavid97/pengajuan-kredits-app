namespace SkyWorkTask.dto
{
    public class PengajuanKreditDTO
    {
        public int Id { get; set; }
        public int Plafon { get; set; }
        public decimal Bunga { get; set; }
        public int Tenor { get; set; }
        public int Angsuran { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}

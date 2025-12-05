namespace SkyWorkTask.Model
{
    public class PengajuanKredit
    {
        public int Id { get; set; }
        public int Plafon { get; set; }
        public decimal Bunga { get; set; }
        public int Tenor {  get; set; }
        public int Angsuran { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

    }
}

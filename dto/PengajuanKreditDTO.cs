
using System.ComponentModel.DataAnnotations;

namespace SkyWorkTask.dto
{
    public class PengajuanKreditDTO
    {
        public int Id { get; set; }
        public int Plafon { get; set; }

        [Range(1, 100, ErrorMessage = "Bunga harus antara 1 sampai 100 persen.")]
        public decimal Bunga { get; set; }
        public int Tenor { get; set; }
        public int Angsuran { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime CreatedAt { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime UpdatedAt { get; set; }
        public decimal HitungAngsuran { get; set; }
    }
}

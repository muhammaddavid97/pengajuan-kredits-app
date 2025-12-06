using SkyWorkTask.dto;
using System.ComponentModel.DataAnnotations;

namespace SkyWorkTask.Body
{
    public class PerhitunganAngsuranRequest
    {
        public int Plafon { get; set; }

        [Range(1, 100, ErrorMessage = "Bunga harus antara 1 sampai 100 persen.")]
        public decimal Bunga { get; set; }
        public int Tenor { get; set; }
    }
}

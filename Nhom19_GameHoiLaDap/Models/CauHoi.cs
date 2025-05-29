using System.ComponentModel.DataAnnotations;

namespace Nhom19_GameHoiLaDap.Models
{
    public class CauHoi
    {
        [Key]
        public int CauHoiId { get; set; }

        [Required]
        public string NoiDung { get; set; } = string.Empty;

        [Required]
        public string DapAnDung { get; set; } = string.Empty;

        [Required]
        public string DapAnSai1 { get; set; } = string.Empty;

        [Required]
        public string DapAnSai2 { get; set; } = string.Empty;

        [Required]
        public string DapAnSai3 { get; set; } = string.Empty;

        [Required]
        [Range(1, 3, ErrorMessage = "Độ khó từ 1 đến 3")]
        public int DoKho { get; set; }
    }
}

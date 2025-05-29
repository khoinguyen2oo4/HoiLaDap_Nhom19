using System.ComponentModel.DataAnnotations;

namespace Nhom19_GameHoiLaDap.Models
{
    public class NguoiChoi
    {
        [Key]
        public int NguoiChoiId { get; set; }

        [Required]
        public string TenDangNhap { get; set; } = string.Empty;

        [Required]
        public string MatKhau { get; set; } = string.Empty;

        public string HoTen { get; set; } = string.Empty;

        public int DiemCaoNhat { get; set; }

        public ICollection<KetQua> KetQuas { get; set; } = new List<KetQua>();
    }

}

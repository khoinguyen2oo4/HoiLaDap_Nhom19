using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nhom19_GameHoiLaDap.Models
{
    public class KetQua
    {
        [Key] // Khóa chính
        public int KetQuaId { get; set; }

        public int Diem { get; set; }

        public DateTime ThoiGian { get; set; } = DateTime.Now;

        // FK: liên kết với người chơi
        [ForeignKey("NguoiChoi")]
        public int NguoiChoiId { get; set; }

        public NguoiChoi NguoiChoi { get; set; }
    }
}

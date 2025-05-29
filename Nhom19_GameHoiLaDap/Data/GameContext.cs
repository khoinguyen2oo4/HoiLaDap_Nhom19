using Microsoft.EntityFrameworkCore;
using Nhom19_GameHoiLaDap.Models;

namespace Nhom19_GameHoiLaDap.Data
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options) { }

        public DbSet<CauHoi> CauHois { get; set; }
        public DbSet<NguoiChoi> NguoiChois { get; set; }
        public DbSet<KetQua> KetQuas { get; set; }
    }
}
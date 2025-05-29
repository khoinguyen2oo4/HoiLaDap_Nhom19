using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Nhom19_GameHoiLaDap.Data
{
    public class GameContextFactory : IDesignTimeDbContextFactory<GameContext>
    {
        public GameContext CreateDbContext(string[] args)
        {
            // Trỏ về thư mục gốc chứa appsettings.json
            var path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));

            var configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<GameContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            Console.WriteLine("📂 Path Base: " + Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..")));
            Console.WriteLine("🧪 Connection string: " + connectionString);


            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("⚠️ Chuỗi kết nối bị rỗng hoặc không tìm thấy trong appsettings.json!");

            optionsBuilder.UseSqlServer(connectionString);

            return new GameContext(optionsBuilder.Options);
        }
    }
}

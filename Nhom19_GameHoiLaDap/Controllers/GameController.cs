using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nhom19_GameHoiLaDap.Data;

namespace Nhom19_GameHoiLaDap.Controllers
{
    public class GameController : Controller
    {
        private readonly GameContext _context;

        public GameController(GameContext context)
        {
            _context = context;
        }

        // GET: /Game/Play
        [HttpGet]
        public IActionResult Play()
        {
            var cauHoi = _context.CauHois
                .OrderBy(q => Guid.NewGuid())
                .FirstOrDefault();

            if (cauHoi == null)
                return Content("⚠️ Chưa có câu hỏi nào trong hệ thống.");

            var dapAn = new List<string>
            {
                cauHoi.DapAnDung,
                cauHoi.DapAnSai1,
                cauHoi.DapAnSai2,
                cauHoi.DapAnSai3
            };

            // Trộn đáp án ngẫu nhiên
            var random = new Random();
            var dapAnNgauNhien = dapAn.OrderBy(x => random.Next()).ToList();

            ViewBag.CauHoi = cauHoi;
            ViewBag.DapAn = dapAnNgauNhien;

            return View();
        }

        // POST: /Game/SubmitAnswer
        [HttpPost]
        public IActionResult SubmitAnswer(int cauHoiId, string luaChon)
        {
            var cauHoi = _context.CauHois.Find(cauHoiId);
            if (cauHoi == null) return NotFound();

            bool ketQua = (luaChon == cauHoi.DapAnDung);
            ViewBag.KetQua = ketQua;
            ViewBag.DapAnDung = cauHoi.DapAnDung;

            return View("KetQua");
        }

    }
}

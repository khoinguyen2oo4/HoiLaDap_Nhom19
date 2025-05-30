using Microsoft.AspNetCore.Mvc;
using Nhom19_GameHoiLaDap.Data;
using Nhom19_GameHoiLaDap.Models;

namespace Nhom19_GameHoiLaDap.Controllers
{
    public class CauHoiController : Controller
    {
        private readonly GameContext _context;

        public CauHoiController(GameContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ds = _context.CauHois.ToList();
            return View(ds);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CauHoi cauHoi)
        {
            if (ModelState.IsValid)
            {
                _context.CauHois.Add(cauHoi);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cauHoi);
        }

        public IActionResult Edit(int id)
        {
            var ch = _context.CauHois.Find(id);
            if (ch == null) return NotFound();
            return View(ch);
        }

        [HttpPost]
        public IActionResult Edit(CauHoi cauHoi)
        {
            if (ModelState.IsValid)
            {
                _context.CauHois.Update(cauHoi);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cauHoi);
        }

        public IActionResult Delete(int id)
        {
            var ch = _context.CauHois.Find(id);
            if (ch == null) return NotFound();
            return View(ch);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var ch = _context.CauHois.Find(id);
            if (ch != null)
            {
                _context.CauHois.Remove(ch);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

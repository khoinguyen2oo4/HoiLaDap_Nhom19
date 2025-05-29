using Microsoft.AspNetCore.Mvc;
using Nhom19_GameHoiLaDap.Data;
using Nhom19_GameHoiLaDap.Models;

public class AccountController : Controller
{
    private readonly GameContext _context;

    public AccountController(GameContext context)
    {
        _context = context;
    }

    // GET: /Account/Register
    public IActionResult Register() => View();

    // POST: /Account/Register
    [HttpPost]
    public IActionResult Register(NguoiChoi nguoiChoi)
    {
        if (_context.NguoiChois.Any(x => x.TenDangNhap == nguoiChoi.TenDangNhap))
        {
            ModelState.AddModelError("", "Tên đăng nhập đã tồn tại!");
            return View();
        }

        _context.NguoiChois.Add(nguoiChoi);
        _context.SaveChanges();
        return RedirectToAction("Login");
    }

    // GET: /Account/Login
    public IActionResult Login() => View();

    // POST: /Account/Login
    [HttpPost]
    public IActionResult Login(string tenDangNhap, string matKhau)
    {
        var user = _context.NguoiChois
            .FirstOrDefault(x => x.TenDangNhap == tenDangNhap && x.MatKhau == matKhau);

        if (user == null)
        {
            ViewBag.Error = "Sai thông tin đăng nhập!";
            return View();
        }

        TempData["NguoiChoiId"] = user.NguoiChoiId;
        TempData["HoTen"] = user.HoTen;
        return RedirectToAction("Index", "Home");
    }
}

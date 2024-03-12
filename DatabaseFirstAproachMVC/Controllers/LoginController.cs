using DatabaseFirstAproachMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstAproachMVC.Controllers
{
    public class LoginController : Controller
    {
       
        public readonly DatabaseFirstApproachContext _databaseFirstApproachContext;

        public LoginController(DatabaseFirstApproachContext databaseFirstApproachContext)
        {
            _databaseFirstApproachContext = databaseFirstApproachContext;
        }
        // GET: LoginController
        public ActionResult Index()
        {
            //List<SelectListItem> gender = new()
            //{
            //    new SelectListItem{ Value = "male" ,Text = "male"},
            //    new SelectListItem{ Value = "female" ,Text = "female"}
            //};
            //ViewBag.gender = gender;
            return View(s);
        }
        [HttpPost]
        public async Task<ActionResult> Index(TblUser user)
        {
            var data = await _databaseFirstApproachContext.TblUsers.FirstOrDefaultAsync(item => item.Email == user.Email);
            if (data != null)
            {
                HttpContext.Session.SetString("mySession", user.Email.ToString());
                return RedirectToAction("Dashboard");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: LoginController/Details/5
        public ActionResult Dashboard()
        {
            ViewBag.testSession = HttpContext.Session.GetString("mySession");
            if (ViewBag.testSession == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Logout()
        {
            if (HttpContext.Session.GetString("mySession") != null)
            {
                HttpContext.Session.Remove("mySession");
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Registration(TblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                await _databaseFirstApproachContext.TblUsers.AddAsync(tblUser);
                await _databaseFirstApproachContext.SaveChangesAsync();
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}

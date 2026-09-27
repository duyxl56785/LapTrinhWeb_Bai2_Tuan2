using Microsoft.AspNetCore.Mvc;
using FormSubmit.Models;

namespace FormSubmit.Controllers
{
    public class AccountController : Controller
    {
        
        [HttpGet]
        [Route("Account")]
        [Route("Account/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Account")]
        [Route("Account/Login")]
        public IActionResult Login(LoginViewModel model)
        {
            if (model.Username == "admin" && model.Password == "123")
            {
                ViewBag.Message = "Login success";
                ViewBag.IsSuccess = true;
            }
            else
            {
                ViewBag.Message = "Login failed";
                ViewBag.IsSuccess = false;
            }

            return View();
        }
    }
}
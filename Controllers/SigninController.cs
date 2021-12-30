using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devTalksASP.Interfaces;
using devTalksASP.Models;
using devTalksASP.Services;


namespace devTalksASP.Controllers
{
    public class SigninController : Controller
    {
        private IRepository<User> _userRepository;
        SigninService _signinService;
        public SigninController(IRepository<User> userRepository,SigninService signinService)
        {
            _userRepository = userRepository;
            _signinService = signinService;
        }
        public IActionResult Index(string loginError,string createnError)
        {
            ViewBag.SigninService = _signinService;
            ViewBag.LoginError = loginError;
            ViewBag.CreateError = createnError;
            return View();
        }

        public IActionResult GetLoginForm(string email,string pw)
        {
            if (_signinService.Login(email, pw))
                return RedirectToAction("Index","Home");
            return RedirectToAction( "Index", "Signin", new { loginError = "Email ou mot de passe incorrect." });
        }

        public IActionResult GetCreateForm(User user,string verifyPassword)
        {
            if (user.Password == verifyPassword)
            {
                if (!_signinService.IsExist(user.Email))
                {
                    user.StateUser = Models.User.StateEnum.Accept;
                    if (_userRepository.Save(user))
                    {
                        _signinService.Login(user.Email, user.Password);
                        return RedirectToAction("Index", "Home");
                    }
                }
                return RedirectToAction("Index", "Signin", new { createnError = "L'adresse email est déjà utilisé." });
            }
            else
                return RedirectToAction("Index", "Signin", new { createnError = "Les mots de passe sont différents." });
        }

        public IActionResult Logout(string type)
        {
            _signinService.Logout();
            if (type=="deco")
                return RedirectToAction("Index", "Home");
            return RedirectToAction("Index", "Signin");

        }

    }
}

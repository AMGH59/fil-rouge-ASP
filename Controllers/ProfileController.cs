using devTalksASP.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devTalksASP.Controllers
{
    public class ProfileController : Controller
    {
        SigninService _signinService;
        public ProfileController(SigninService signinService)
        {
            _signinService = signinService;
        }
        public IActionResult Index()
        {
            ViewBag.SigninService = _signinService;
            return View();
        }
    }
}

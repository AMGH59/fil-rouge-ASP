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
        public IActionResult Index(string choice)
        {

            if (_signinService.IsLogged())
            {
                ViewBag.SigninService = _signinService;
                if (choice == "question")
                {
                    ViewBag.Question = _signinService.GetCreatedTopics();
                    ViewBag.Choice ="question";
                    return View();
                }
                else if( choice == "response")
                {
                    ViewBag.Question = _signinService.GetHelpedGiven();
                    ViewBag.Choice = "response";
                    return View();
                }
                else
                {
                    return View();

                }
            }
            return RedirectToAction("Index", "Signin");
        }
    }
}

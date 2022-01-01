using devTalksASP.Models;
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
        StateManagementService _stateManagementService;
        TopicService _topicService;
        public ProfileController(SigninService signinService, StateManagementService stateManagementService, TopicService topicService)
        {
            _signinService = signinService;
            _stateManagementService = stateManagementService;
            _topicService = topicService;
        }
        public IActionResult Index(string choice, string message,string classMessage)
        {

            if (_signinService.IsLogged())
            {
                ViewBag.Message = message;
                ViewBag.ClassMessage = classMessage;
                ViewBag.SigninService = _signinService;
                switch (choice)
                {
                    case "1":
                        ViewBag.Topics = _topicService.GetTopicsInProgress();
                        ViewBag.nTopics = _signinService.GetCreatedTopics().Count();
                        break;
                    case "2":
                        ViewBag.Topics = _topicService.GetTopicsInResolved();
                        ViewBag.nTopics = _signinService.GetCreatedTopics().Count();
                        break;
                    case "3":
                        ViewBag.Topics = _topicService.GetTopicsDisallowed();
                        ViewBag.nTopics = _signinService.GetCreatedTopics().Count();
                        break;
                    default:
                        ViewBag.Topics = _signinService.GetCreatedTopics();
                        ViewBag.nTopics = _signinService.GetCreatedTopics().Count();
                        break;
                }
                return View();

            }
            return RedirectToAction("Index", "Signin");
        }

        public IActionResult CloseTopic(int id)
        {
            if (_stateManagementService.CloseTopic(id))
            {
                return RedirectToAction("Index", "Profile", new { message = "Vous avez clos le sujet.", classMessage= " bg-success p-2 mt-2 rounded text-light" });
            }
            return RedirectToAction("Index", "Profile", new { message = "Le sujet n'a pas été clos.", classMessage = " bg-danger p-2 mt-2 rounded text-light" });
        }

    }
}

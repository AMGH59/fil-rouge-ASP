using devTalksASP.Interfaces;
using devTalksASP.Models;
using devTalksASP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace devTalksASP.Controllers
{
    public class TechnoController : Controller
    {
        TechnoService _technoService;
        private IHttpContextAccessor _accessor;
        public TechnoController(TechnoService technoService, IHttpContextAccessor accessor)
        {
            _technoService = technoService;
            _accessor = accessor;
        }
        public IActionResult Index()
        {
            Dictionary<Techno, int> technosDict = _technoService.GetTechnosCountPairs();
            return View("Index", technosDict);
        }

        public IActionResult Detail(int id)
        {
            Techno techno = _technoService.FindTechnoById(id);
            ViewBag.Topics = _technoService.FindTopicsByTechno(techno);
            ViewBag.CurrentUser = _accessor.HttpContext.Session.GetInt32("id");
            return View(techno);
        }
        
    }
}

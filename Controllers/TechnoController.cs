using devTalksASP.Interfaces;
using devTalksASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace devTalksASP.Controllers
{
    public class TechnoController : Controller
    {
        IRepository<Techno> _technoRepository;
        private IHttpContextAccessor _accessor;
        public TechnoController(IRepository<Techno> technoRepository, IHttpContextAccessor accessor)
        {
            _technoRepository = technoRepository;
            _accessor = accessor;
        }
        public IActionResult Index()
        {
            List<Techno> technos = (List<Techno>)_technoRepository.GetAll();
            return View("Index", technos);
        }

        public IActionResult Detail(int id)
        {
            Techno techno = _technoRepository.FinById(id);
            ViewBag.CurrentUser = _accessor.HttpContext.Session.GetInt32("id");
            return View(techno);
        }
        
    }
}

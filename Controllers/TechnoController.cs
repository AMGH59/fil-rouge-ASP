using devTalksASP.Interfaces;
using devTalksASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace devTalksASP.Controllers
{
    public class TechnoController : Controller
    {
        IRepository<Techno> _technoRepository;
        IRepository<Topic> _topicRepository;
        private IHttpContextAccessor _accessor;
        public TechnoController(IRepository<Techno> technoRepository,IRepository<Topic> topicRepository, IHttpContextAccessor accessor)
        {
            _technoRepository = technoRepository;
            _topicRepository = topicRepository;
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
            ViewBag.NbTopic = _topicRepository.Search(t => t.Technos.Contains(techno)).ToList().Count();
            ViewBag.CurrentUser = _accessor.HttpContext.Session.GetInt32("id");
            return View(techno);
        }
        
    }
}

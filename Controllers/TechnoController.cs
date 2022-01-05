using devTalksASP.Interfaces;
using devTalksASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace devTalksASP.Controllers
{
    public class TechnoController : Controller
    {
        IRepository<Techno> _technoRepository;
        public TechnoController(IRepository<Techno> technoRepository)
        {
            _technoRepository = technoRepository;
        }
        public IActionResult Index()
        {
            List<Techno> technos = (List<Techno>)_technoRepository.GetAll();
            return View("Index", technos);
        }


        
    }
}

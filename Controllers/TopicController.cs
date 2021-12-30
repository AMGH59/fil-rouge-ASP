using devTalksASP.Interfaces;
using devTalksASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace devTalksASP.Controllers
{
    public class TopicController : Controller
    {
        IRepository<Topic> _topicRepository;
        IRepository<Techno> _technoRepository;
        public TopicController(IRepository<Topic> topicRepository, IRepository<Techno> technoRepository)
        {
            _topicRepository = topicRepository;
            _technoRepository = technoRepository;
        }
        public IActionResult Index()
        {
            List<Topic> topics = _topicRepository.GetAll();
            return View("Index", topics);
        }

        public IActionResult NewTopicForm()
        {
            List<Techno> technos = _technoRepository.GetAll();
            return View("NewTopicForm", technos);
        }
        public IActionResult SubmitNewTopic(Topic topic)
        {
            _topicRepository.SaveIt(topic);
            return RedirectToAction("Index");
        }
    }
}

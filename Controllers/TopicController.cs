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
        IRepository<User> _userRepository;
        public TopicController(IRepository<Topic> topicRepository, IRepository<Techno> technoRepository, IRepository<User> userRepository)
        {
            _topicRepository = topicRepository;
            _technoRepository = technoRepository;
            _userRepository = userRepository;
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
        public IActionResult SubmitNewTopic(Topic topic, int authorId)
        {
            topic.Author = _userRepository.FinById(authorId);
            _topicRepository.SaveIt(topic);
            return RedirectToAction("Index");
        }
    }
}

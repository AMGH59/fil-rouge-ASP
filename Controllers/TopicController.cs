using devTalksASP.Interfaces;
using devTalksASP.Models;
using devTalksASP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;


namespace devTalksASP.Controllers
{
    public class TopicController : Controller
    {
        IRepository<Topic> _topicRepository;
        IRepository<Techno> _technoRepository;
        IRepository<User> _userRepository;
        IRepository<Message> _messageRepository;
        private IHttpContextAccessor _accessor;

        public TopicController(IRepository<Topic> topicRepository, IRepository<Techno> technoRepository, IRepository<User> userRepository, IRepository<Message> messageRepository, IHttpContextAccessor accessor)
        {
            _topicRepository = topicRepository;
            _technoRepository = technoRepository;
            _messageRepository = messageRepository;
            _userRepository = userRepository;
            _accessor = accessor;

        }
        public IActionResult Index()
        {
            List<Topic> topics = (List<Topic>)_topicRepository.GetAll();
            return View("Index", topics);
        }
        public IActionResult SubmitSearch(string searchNavbar)
        {
            List<Topic> topics = (List<Topic>)_topicRepository.Search(t => t.Question.Contains(searchNavbar) || t.Body.Contains(searchNavbar));
            return View("Index", topics);
        }

        public IActionResult NewTopicForm()
        {
            List<Techno> technos = (List<Techno>)_technoRepository.GetAll();
            ViewBag.CurrentUser = _accessor.HttpContext.Session.GetInt32("id");
            return View("NewTopicForm", technos);
        }
        public IActionResult SubmitNewTopic(Topic topic,List<int> technos)
        {
            int authorId=(int)_accessor.HttpContext.Session.GetInt32("id");
            topic.Author = _userRepository.FinById(authorId);
            topic.Technos = (List<Techno>)_technoRepository.Search(tech => technos.Contains(tech.Id));
            _topicRepository.Save(topic);
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            Topic topic = _topicRepository.FinById(id);
            //List<Message> responses = _messageRepository.GetAllByTopic(id);
            TopicMessageViewModel tmvm = new TopicMessageViewModel();
            tmvm.Topic = topic;
            //tmvm.Messages = responses;
            ViewBag.CurrentUser = _accessor.HttpContext.Session.GetInt32("id");
            return View(tmvm);
        }
        public IActionResult SubmitAnswer(Message answer, int Id_topic, int Id_user)
        {
            answer.User= _userRepository.FinById(Id_user);
            answer.Topic = _topicRepository.FinById(Id_topic);
            _messageRepository.Save(answer);
            return RedirectToAction("Index");
        }
    }
}

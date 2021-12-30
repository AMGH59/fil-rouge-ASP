using devTalksASP.Interfaces;
using devTalksASP.Models;
using devTalksASP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace devTalksASP.Controllers
{
    public class TopicController : Controller
    {
        IRepository<Topic> _topicRepository;
        IRepository<Techno> _technoRepository;
        IRepository<User> _userRepository;
        IRepository<Message> _messageRepository;
        public TopicController(IRepository<Topic> topicRepository, IRepository<Techno> technoRepository, IRepository<User> userRepository, IRepository<Message> messageRepository)
        {
            _topicRepository = topicRepository;
            _technoRepository = technoRepository;
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            List<Topic> topics = _topicRepository.GetAll();
            return View("Index", topics);
        }
        public IActionResult SubmitSearch(string searchNavbar)
        {
            List<Topic> topics = (List<Topic>)_topicRepository.Search(t => t.Question.Contains(searchNavbar) || t.Body.Contains(searchNavbar));
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

        public IActionResult Detail(int id)
        {
            Topic topic = _topicRepository.FinById(id);
            List<Message> responses = _messageRepository.GetAllByTopic(id);
            TopicMessageViewModel tmvm = new TopicMessageViewModel();
            tmvm.Topic = topic;
            tmvm.Messages = responses;
            return View(tmvm);
        }
        public IActionResult SubmitAnswer(Message answer, int Id_user, int Id_topic)
        {
            answer.Id_user = _userRepository.FinById(Id_user).Id;
            answer.Id_topic = _topicRepository.FinById(Id_topic).Id;
            _messageRepository.SaveIt(answer);
            return RedirectToAction("Index");
        }
    }
}

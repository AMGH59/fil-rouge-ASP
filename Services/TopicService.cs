using devTalksASP.Interfaces;
using devTalksASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devTalksASP.Services
{
    public class TopicService
    {
        private IRepository<Topic> _topicRepository;
        SigninService _signinService;
        public TopicService(IRepository<Topic> topicRepository, SigninService signinService)
        {
            _topicRepository = topicRepository;
            _signinService = signinService;


        }

        public IEnumerable<Topic> GetTopicsInProgress(int id)
        {
            id = id == 0 ? _signinService.CurrentUser.Id : id;
            IEnumerable <Topic> topics = default(IEnumerable<Topic>);
            topics=_topicRepository.Search(t => t.AuthorId == id && t.StateTopic == Topic.StateEnum.InProgress);
            return topics;
        }
        public IEnumerable<Topic> GetTopicsDisallowed(int id)
        {
            id = id == 0 ? _signinService.CurrentUser.Id : id;
            IEnumerable<Topic> topics = default(IEnumerable<Topic>);
            topics = _topicRepository.Search(t => t.AuthorId == id && t.StateTopic == Topic.StateEnum.Disallow);
            return topics;
        }
        public IEnumerable<Topic> GetTopicsInResolved(int id)
        {
            id = id == 0 ? _signinService.CurrentUser.Id : id;
            IEnumerable<Topic> topics = default(IEnumerable<Topic>);
            topics = _topicRepository.Search(t => t.AuthorId == id && t.StateTopic == Topic.StateEnum.Resolved);
            return topics;
        }
    }
}

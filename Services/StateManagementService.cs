using devTalksASP.Interfaces;
using devTalksASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devTalksASP.Services
{
    public class StateManagementService
    {
        private IRepository<User> _userRepository;
        private IRepository<Message> _messageRepository;
        private IRepository<Topic> _topicRepository;


        public StateManagementService(IRepository<User> userRepository, IRepository<Message> messageRepository,IRepository<Topic> topicRepository)
        {
            _userRepository = userRepository;
            _messageRepository = messageRepository;
            _topicRepository = topicRepository;

        }
        public bool ReportUser(int id)
        {
            User u = _userRepository.FinById(id);
            if (u != null)
            {
                u.StateUser = User.StateEnum.Waiting;
                return true;
            }
            return false;
        }
        public bool ReportMessage(int id)
        {
            Message m = _messageRepository.FinById(id);
            if(m != null)
            {
                m.StateMessage = Message.StateMessageEnum.Reported;
                return true;
            }
            return false;
        }
        public bool ReportTopic(int id)
        {
            Topic t = _topicRepository.FinById(id);
            if (t != null)
            {
                t.StateTopic = Topic.StateEnum.Disallow;
                return true;
            }
            return false;
        }
        public bool CloseTopic(int id)
        {
            Topic t = _topicRepository.FinById(id);
            if(t != null)
            {
                t.StateTopic = Topic.StateEnum.Resolved;
                return true;
            }
            return false;
        }
    }
}

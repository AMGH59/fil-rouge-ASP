using devTalksASP.Models;
using System.Collections.Generic;

namespace devTalksASP.ViewModels
{
    public class TopicMessageViewModel
    {
        public Topic Topic { get; set; }
        public List<Message> Messages { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace devTalksASP.Models
{
    public class Topic
    {
        private int id;
        private string question;
        private string body;
        private User author;
        private List<Message> responses;
        private List<Techno> technos;
        private DateTime date;


        public enum StateEnum
        {
            Disallow,
            InProgress,
            Resolved
        }

        public Topic()
        {
            Date = DateTime.Now;
            StateTopic = StateEnum.InProgress;
            Responses = new List<Message>();
            Technos = new List<Techno>();

            // En attendant la connection avec User (Fake User)
            Author = new User { FirstName = "Tutu", LastName = "Titi", Email = "tutu@titi.com", Id = 2, IsAdmin = true, IsLogged = true, StateUser = User.StateEnum.Accept, Password = "123" };
        }

        public int Id { get => id; set => id = value; }
        public string Question { get => question; set => question = value; }
        public string Body { get => body; set => body = value; }
        public virtual List<Message> Responses { get ; set ; }
        public virtual List<Techno> Technos { get => technos; set => technos = value; }
        public User Author { get => author; set => author = value; }
        public StateEnum StateTopic { get; set; }
        public DateTime Date { get => date; set => date = value; }
    }
}


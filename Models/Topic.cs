﻿using System;
using System.Collections.Generic;
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
        }

        public int Id { get => id; set => id = value; }
        public string Question { get => question; set => question = value; }
        public string Body { get => body; set => body = value; }
        public virtual List<Message> Responses { get => responses; set => responses = value; }
        public virtual List<Techno> Technos { get => technos; set => technos = value; }
        public User Author { get => author; set => author = value; }
        public StateEnum StateTopic { get; set; }
        public DateTime Date { get => date; set => date = value; }
    }
}


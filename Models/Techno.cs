﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devTalksASP.Models
{
    public class Techno
    {
        private int id;
        private string description;
        private string name;
        //private List<Topic> topics;
        private Techno()
        {

        }
        public int Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
        public string Name { get => name; set => name = value; }
        public virtual List<Topic> Topics { get; set; }
    }
}


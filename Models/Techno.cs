using System;
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
        private List<Topic> topics_id;
        private Techno()
        {

        }
        public int Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
        public string Name { get => name; set => name = value; }
        public virtual List<Topic> Topics_id { get => topics_id; set => topics_id = value; }
    }
}


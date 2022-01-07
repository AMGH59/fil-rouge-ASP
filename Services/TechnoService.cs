using devTalksASP.Interfaces;
using devTalksASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devTalksASP.Services
{
    public class TechnoService
    {
        private IRepository<Techno> _technoRepository;
        private IRepository<Topic> _topicRepository;
        public TechnoService(IRepository<Topic> topicRepository, IRepository<Techno> technoRepository)
        {
            _topicRepository = topicRepository;
            _technoRepository = technoRepository;
        }

        public Dictionary<Techno, int> GetTechnosCountPairs()
        {
            List<Techno> technosList = (List<Techno>)_technoRepository.GetAll();
            Dictionary<Techno, int> technosDict = new Dictionary<Techno, int>();
            foreach (Techno tec in technosList)
                technosDict.Add(tec, _topicRepository.Search(t => t.Technos.Contains(tec)).Count());
            return technosDict;
        }

        public Techno FindTechnoById(int id)
        {
            return _technoRepository.FinById(id);
        }
        public IEnumerable<Topic> FindTopicsByTechno(Techno techno)
        {
            return _topicRepository.Search(t => t.Technos.Contains(techno));
        }


    }
}

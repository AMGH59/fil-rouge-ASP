using devTalksASP.Models;
using devTalksASP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTalksASP.Repositories
{
    class TechnoRepository : BaseRepository,IRepository<Techno>
    {
        public Techno FinById(int id)
        {
            return _dataContext.Instance.Technos.Find(id);
        }

        public bool Save(Techno techno)
        {
            _dataContext.Instance.Technos.Add(techno);
            return _dataContext.Instance.SaveChanges() > 0;
        }

        public IEnumerable<Techno> Search(Func<Techno, bool> predicate)
        {
            return _dataContext.Instance.Technos.Where(t => predicate(t)).ToList();
        }

        public bool Update(Techno element)
        {
            return _dataContext.Instance.SaveChanges() > 0;

        }
    }
}

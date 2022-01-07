using devTalksASP.Models;
using devTalksASP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using devTalksASP.Repositories;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace devTalksASP.Repositories
{
    class TopicRepository : BaseRepository,IRepository<Topic>
    {
        public TopicRepository(DataContext dataContext) : base(dataContext) { }

        public Topic FinById(int id)
        {
            return _dataContext.Topics.Include(t => t.Author).Include(t => t.Responses).ThenInclude(r=>r.User).Include(t => t.Technos).FirstOrDefault(t=>t.Id==id);
        }
        public bool Save(Topic topic)
        {
            _dataContext.Topics.Add(topic);
            return _dataContext.SaveChanges() > 0;
        }

        public IEnumerable<Topic> Search(Func<Topic, bool> predicate)
        {
            return _dataContext.Topics.Include(t => t.Author).Include(t => t.Responses).ThenInclude(r => r.User).Include(t => t.Technos).Where(m => predicate(m)).ToList();
        }

        public bool Update(Topic topic)
        {
            return _dataContext.SaveChanges() > 0;
        }

        public bool Remove(Topic topic)
        {
            _dataContext.Topics.Remove(topic);
            return _dataContext.SaveChanges() > 0;
        }

        public IEnumerable<Topic> Search(Expression<Func<Topic, bool>> predicate)
        {
            return _dataContext.Topics.Include(t => t.Author).Include(t => t.Responses).ThenInclude(r => r.User).Include(t => t.Technos).Where(predicate).ToList();
        }

        public Topic SearchOne(Expression<Func<Topic, bool>> searchMethode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> GetAll()
        {
            return _dataContext.Topics.Include(t => t.Author).Include(t => t.Responses).ThenInclude(r => r.User).Include(t => t.Technos).ToList();
        }
    }
}

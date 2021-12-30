using devTalksASP.Models;
using devTalksASP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using devTalksASP.Repositories;
using System.Linq.Expressions;

namespace devTalksASP.Repositories
{
    class TopicRepository : BaseRepository,IRepository<Topic>
    {
        public TopicRepository(DataContext dataContext) : base(dataContext) { }

        public Topic FinById(int id)
        {
            return _dataContext.Topics.Find(id);
        }

        public bool Save(Topic topic)
        {
            _dataContext.Topics.Add(topic);
            return _dataContext.SaveChanges() > 0;
        }

        public IEnumerable<Topic> Search(Func<Topic, bool> predicate)
        {
            return _dataContext.Topics.Where(m => predicate(m)).ToList();
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
            return _dataContext.Topics.Where(predicate).ToList();

        }

        public Topic SearchOne(Expression<Func<Topic, bool>> searchMethode)
        {
            throw new NotImplementedException();
        }
    }
}

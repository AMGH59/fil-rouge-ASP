﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace devTalksASP.Interfaces
{
    public interface IRepository<T>
    {
        bool Save(T element);
        T SaveIt(T element);
        bool Update(T element);
        T FinById(int id);
        IEnumerable<T> Search(Expression<Func<T, bool>> predicate);
        T SearchOne(Expression<Func<T, bool>> searchMethode);
        List<T> GetAll();
        public List<T> GetAllByTopic(int Id_topic);

    }
}

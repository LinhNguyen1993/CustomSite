using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CustomSite.Entities;

namespace CustomSite.Core
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        T GetSingle(Guid Id);
        T GetSingle(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);        
    }
}
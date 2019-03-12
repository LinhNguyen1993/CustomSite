using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CustomSite.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomSite.Core
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private SiteContext _context;
        public EntityBaseRepository(SiteContext context)
        {
            _context = context;
        }

        public virtual void Add(T entity)
        {
            _context.Add<T>(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Remove<T>(entity);
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);
            foreach (var entity in entities)
            {
                _context.Remove<T>(entity);
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual T GetSingle(Guid Id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == Id);
        }

        public virtual T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public virtual void Update(T entity)
        {
            _context.Attach<T>(entity);
            _context.Entry<T>(entity).State = EntityState.Modified;
        }
    }
}
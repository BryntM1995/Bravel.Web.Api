using Bravel.Web.Api.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravel.Web.Api.Repository
{
    public interface IBaseRepository<Entity>
    {
        void Add(Entity entity);
        void Update(Entity entity);
        bool Remove(int key);
        Entity GetById(int key);
        IQueryable<Entity> GetAll();
        public bool Commit();
    }
    public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : class, IBaseEntity
    {
        private readonly DbContext _dbContext;
        protected readonly DbSet<Entity> _dbSet;
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Entity>();
        }
        public void Add(Entity entity)
        {
            _dbSet.Add(entity);
            Commit();
        }

        public void Update(Entity entity)
        {
            Update(entity);
        }

        public bool Remove(int key)
        {
            var item = GetById(key);
            item.Deleted = true;
            Update(item);
            return Commit();
        }

        public Entity GetById(int id)
        {
            var entity = GetAll().Where(x => x.Id == id).FirstOrDefault() ?? throw new InvalidOperationException("Entity not found");
            return entity;
        }

        public IQueryable<Entity> GetAll()
        {
            return _dbSet;
        }

        public bool Commit()
        {
            var result = _dbContext.SaveChanges() == 1;
            return result;
        }
    }
}

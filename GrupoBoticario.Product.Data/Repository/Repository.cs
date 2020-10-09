using GrupoBoticario.Product.Business.Interfaces;
using GrupoBoticario.Product.Business.Models;
using GrupoBoticario.Product.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GrupoBoticario.Product.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly DataContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(DataContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Insert(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(int id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void DetachLocal(Func<TEntity, bool> predicate)
        {
            var local = Db.Set<TEntity>().Local.Where(predicate).FirstOrDefault();
            if (local != null)
            {
                Db.Entry(local).State = EntityState.Detached;
            }
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}

using CORE.DAL.Context;
using CORE.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CORE.DAL.Common
{
    public class Repository<DBEntity> : IRepository<DBEntity> where DBEntity : class
    {
        private readonly customerContext Context;

        public Repository(customerContext context)
        {
            Context = context;
        }

        public DBEntity Get(int id)
        {
            return Context.Set<DBEntity>().Find(id);
        }

        public async Task<IEnumerable<DBEntity>> Find(Expression<Func<DBEntity, bool>> predicate)
        {
            return await Context.Set<DBEntity>().Where(predicate).ToListAsync();
        }

        public async Task Add(DBEntity entity)
        {
            await Context.Set<DBEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Update(DBEntity entity)
        {
            Context.Set<DBEntity>().Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<DBEntity> entities)
        {
            await Context.Set<DBEntity>().AddRangeAsync(entities);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(DBEntity entity)
        {
            Context.Set<DBEntity>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<DBEntity> entities)
        {
            Context.Set<DBEntity>().RemoveRange(entities);
            await Context.SaveChangesAsync();
        }
    }
}

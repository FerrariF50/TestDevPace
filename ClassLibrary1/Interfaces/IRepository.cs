﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CORE.DAL.Interfaces
{
    public interface IRepository<DBEntity> where DBEntity : class
    {
        DBEntity Get(int id);
        Task<IEnumerable<DBEntity>> Find(Expression<Func<DBEntity, bool>> predicate);
        Task Add(DBEntity entity);
        Task Update(DBEntity entity);
        Task AddRange(IEnumerable<DBEntity> entities);
        Task Delete(DBEntity entity);
        Task RemoveRange(IEnumerable<DBEntity> entities);
    }
}

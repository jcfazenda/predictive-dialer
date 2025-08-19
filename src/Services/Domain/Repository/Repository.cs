﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Domain.Repository
{
    public class Repository<TEntity, TID> : IRepository<TEntity, TID> where TEntity : class
    {
        protected readonly DbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(GRCContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj) => DbSet.Add(obj);

        public virtual TEntity GetById(TID id)
        {
            var entity = DbSet.Find(id) ?? throw new InvalidOperationException($"Entidade com id {id} não encontrada.");
            return entity;
        }

        public virtual IQueryable<TEntity> GetAll() => DbSet;

        public virtual IQueryable<TEntity> GetPagination(Expression<Func<TEntity, bool>> filter,
                                                         int page = 1,
                                                         int quantity = 10) =>
            DbSet.Where(filter).Skip((page - 1) * quantity).Take(quantity);

        public virtual IQueryable<TEntity> GetPagination(Expression<Func<TEntity, bool>> filter,
                                                         Expression<Func<TEntity, object>> orderBy,
                                                         int page = 1,
                                                         int quantity = 10) =>
            DbSet.Where(filter).Skip((page - 1) * quantity).Take(quantity);

        public virtual IQueryable<TEntity> GetAutoComplete(Expression<Func<TEntity, bool>> filter,
                                                           Expression<Func<TEntity, object>> orderBy,
                                                           int quantity = 10) =>
            DbSet.Where(filter).OrderBy(orderBy).Take(quantity);

        public virtual void Update(TEntity obj) => DbSet.Update(obj);

        public virtual void Remove(TID id)
        {
            var entity = DbSet.Find(id) ?? throw new InvalidOperationException($"Entidade com id {id} não encontrada.");
            DbSet.Remove(entity);
        }

        public int SaveChanges(TID id) => Db.SaveChanges();

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

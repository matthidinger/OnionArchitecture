using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security;

namespace Core.Services.Impl
{
    public interface IQueryFilterService
    {
        void SecureEntity<TEntity>(Expression<Func<TEntity, bool>> filter);
        TEntity AuthorizeEntity<TEntity>(TEntity entity);
        IQueryable<TEntity> SecureQuery<TEntity>(IQueryable<TEntity> query);
        bool IsEntitySecured<TEntity>();
    }

    public class QueryFilterService : IQueryFilterService
    {
        private readonly Dictionary<Type, LambdaExpression> _filters;

        public QueryFilterService()
        {
            _filters = new Dictionary<Type, LambdaExpression>();
        }

        public void SecureEntity<TEntity>(Expression<Func<TEntity, bool>> filter)
        {
            _filters.Add(typeof(TEntity), filter);
        }

        public TEntity AuthorizeEntity<TEntity>(TEntity entity)
        {
            if (!IsEntitySecured<TEntity>())
                return entity;

            var whereClause = GetSecurityExpression<TEntity>();
            bool authorized = whereClause.Compile().Invoke(entity);

            if (authorized == false)
            {
                throw new SecurityException(string.Format("Unathorized access to the requested entity: {0}.", typeof(TEntity)));
            }

            return entity;
        }

        public IQueryable<TEntity> SecureQuery<TEntity>(IQueryable<TEntity> query)
        {
            if (!IsEntitySecured<TEntity>())
                return query;

            var whereClause = GetSecurityExpression<TEntity>();
            return query.Where(whereClause);
        }

        public bool IsEntitySecured<TEntity>()
        {
            Type entityType = typeof(TEntity);
            return _filters.ContainsKey(entityType);
        }

        private Expression<Func<TEntity, bool>> GetSecurityExpression<TEntity>()
        {
            Type entityType = typeof(TEntity);
            var expression = _filters[entityType];

            return Expression.Lambda<Func<TEntity, bool>>(expression.Body, expression.Parameters);
        }
    }
}
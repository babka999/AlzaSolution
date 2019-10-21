using Alza.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alza.Services
{
    /// <summary>
    /// Common service
    /// </summary>
    public partial class CommonService : ICommonService
    {
        #region Fields

        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Ctor

        public CommonService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Add record
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        /// <returns>TEntity</returns>
        public virtual TEntity Add<TEntity>(TEntity model) where TEntity : class
        {
            TEntity result = _dbContext.Add(model).Entity;
            _dbContext.SaveChanges();
            return result;
        }

        /// <summary>
        /// Has entity record
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public virtual bool Any<TEntity>() where TEntity : class => _dbContext.Set<TEntity>().Any();

        /// <summary>
        /// Update record
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual void Update<TEntity>(TEntity model) where TEntity : class
        {
            _dbContext.Update(model);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Remove record
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual void Remove<TEntity>(TEntity model) where TEntity : class
        {
            _dbContext.Remove(model);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Get all records
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public virtual List<TEntity> GetAll<TEntity>() where TEntity : class => _dbContext.Set<TEntity>().ToList();

        /// <summary>
        /// Get records by key
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="modelType"></param>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public virtual TEntity GetByKey<TEntity>(Type modelType, params object[] keyValues) where TEntity : class => (TEntity)_dbContext.Find(modelType, keyValues);

        #endregion
    }
}

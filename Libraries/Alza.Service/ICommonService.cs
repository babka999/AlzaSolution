using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alza.Services
{
    /// <summary>
    /// Common service interface
    /// </summary>
    public partial interface ICommonService
    {
        #region Public methods

        /// <summary>
        /// Add record
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        TEntity Add<TEntity>(TEntity model) where TEntity : class;

        /// <summary>
        /// Has entity record
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        bool Any<TEntity>() where TEntity : class;

        /// <summary>
        /// Update record
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        void Update<TEntity>(TEntity model) where TEntity : class;

        /// <summary>
        /// Remove record
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        void Remove<TEntity>(TEntity model) where TEntity : class;

        /// <summary>
        /// Get all records
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        List<TEntity> GetAll<TEntity>() where TEntity : class;

        /// <summary>
        /// Get records by key
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="modelType"></param>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        TEntity GetByKey<TEntity>(Type modelType, params object[] keyValues) where TEntity : class;

        #endregion

        #region Async public methods

        /// <summary>
        /// Add record async
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        /// <returns>TEntity</returns>
        Task<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity model) where TEntity : class;

        /// <summary>
        /// Has entity record async
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        Task<bool> AnyAsync<TEntity>() where TEntity : class;

        /// <summary>
        /// Update record async
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateAsync<TEntity>(TEntity model) where TEntity : class;

        /// <summary>
        /// Remove record async
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        Task RemoveAsync<TEntity>(TEntity model) where TEntity : class;

        /// <summary>
        /// Get all records async
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        Task<List<TEntity>> GetAllAsync<TEntity>() where TEntity : class;

        /// <summary>
        /// Get records by key async
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="modelType"></param>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task<TEntity> GetByKeyAsync<TEntity>(Type modelType, params object[] keyValues) where TEntity : class;

        #endregion
    }
}

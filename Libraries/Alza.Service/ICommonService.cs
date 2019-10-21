using System;
using System.Collections.Generic;
using System.Text;

namespace Alza.Services
{
    /// <summary>
    /// Common service interface
    /// </summary>
    public partial interface ICommonService
    {
        #region Public methods

        TEntity Add<TEntity>(TEntity model) where TEntity : class;

        bool Any<TEntity>() where TEntity : class;

        void Update<TEntity>(TEntity model) where TEntity : class;

        void Remove<TEntity>(TEntity model) where TEntity : class;

        List<TEntity> GetAll<TEntity>() where TEntity : class;

        TEntity GetByKey<TEntity>(Type modelType, params object[] keyValues) where TEntity : class;

        #endregion
    }
}

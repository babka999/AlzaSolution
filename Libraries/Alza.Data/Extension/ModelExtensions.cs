using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Alza.Data.Extension
{
    /// <summary>
    /// Model extensions
    /// </summary>
    public static class ModelExtensions
    {
        #region Public methods

        /// <summary>
        /// Map model to model => both models have to has same properties 
        /// </summary>
        /// <typeparam name="TOld"></typeparam>
        /// <typeparam name="TNew"></typeparam>
        /// <param name="old"></param>
        /// <returns></returns>
        public static TNew Mapping<TOld, TNew>(this TOld old) where TNew : class, new() where TOld : class
        {
            if (old == null)
                return new TNew();
            TNew model = new TNew();
            Type entity = typeof(TNew);
            Dictionary<string, PropertyInfo> propDictNew = entity.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToDictionary(p => p.Name.ToUpper(), p => p);
            Dictionary<string, PropertyInfo> propDictOld = old.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).ToDictionary(p => p.Name.ToUpper(), p => p);

            foreach (KeyValuePair<string, PropertyInfo> propNew in propDictNew)
                if (propDictOld.ContainsKey(propNew.Key))
                {
                    PropertyInfo piOld = propDictOld[propNew.Key];
                    try
                    {
                        Type t = Nullable.GetUnderlyingType(propNew.Value.PropertyType) ?? propNew.Value.PropertyType;
                        propNew.Value.SetValue(model, Convert.ChangeType(piOld.GetValue(old), t));
                    }
                    catch { }
                }
            return model;
        }

        /// <summary>
        /// Map list of model to list of model => both models have to has same properties 
        /// </summary>
        /// <typeparam name="TOld"></typeparam>
        /// <typeparam name="TNew"></typeparam>
        /// <param name="old"></param>
        /// <returns></returns>
        public static List<TNew> Mapping<TOld, TNew>(this List<TOld> old) where TNew : class, new() where TOld : class
        {
            if (old == null || old.Count == 0)
                return null;
            List<TNew> model = new List<TNew>();
            foreach (TOld oldItem in old)
                model.Add(oldItem.Mapping<TOld, TNew>());
            return model;
        }

        #endregion
    }
}

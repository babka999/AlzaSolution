using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alza.Data
{
    public partial class ApplicationDbContext : DbContext, IDbContext
    {
        #region Ctor

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        #endregion

        #region Override method

        /// <summary>
        /// Add entities + mapping entities
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            #region Entities mapping configuration

            //builder.AddConfiguration(new ContractTypeMap());

            #endregion
        }

        #endregion
    }
}

﻿using Alza.Extensions.Model;
using System.ComponentModel.DataAnnotations;

namespace AlzaWebApi.V1.Models
{
    /// <summary>
    /// Update product model
    /// </summary>
    public class UpdateProductModel : IValidator
    {
        /// <summary>
        /// Description
        /// </summary>
        [MaxLength(500)]
        public string Description { get; set; }
    }
}

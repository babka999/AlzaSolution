using System;
using System.Collections.Generic;
using System.Net;

namespace AlzaWebApi.Models
{
    /// <summary>
    /// Error model
    /// </summary>
    public class ErrorModel
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ErrorModel()
        {
            Errors = new ErrorDetailModel();
        }

        /// <summary>
        /// Errors
        /// </summary>
        public ErrorDetailModel Errors { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Http status
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Trace id
        /// </summary>
        public Guid TraceId { get; set; }

        /// <summary>
        /// Generate error model
        /// </summary>
        /// <returns></returns>
        public static ErrorModel GetErrorModel(string title, string description, HttpStatusCode status)
            => new ErrorModel
            {
                Errors = new ErrorDetailModel
                {
                    Description = new List<string> { description }
                },
                Status = (int)status,
                Title = title,
                TraceId = Guid.NewGuid()
            };
    }

    /// <summary>
    /// Error detail model
    /// </summary>
    public class ErrorDetailModel
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ErrorDetailModel()
        {
            Description = new List<string>();
        }
        /// <summary>
        /// Description
        /// </summary>
        public List<string> Description { get; set; }

    }
}

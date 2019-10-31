using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
            Errors = new Dictionary<string, HashSet<string>>();
        }

        /// <summary>
        /// Properties errors
        /// </summary>
        public Dictionary<string,HashSet<string>> Errors { get; set; }

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
        public static ErrorModel GetErrorModel(string title, string propertyName, string propertyError, HttpStatusCode status)
            => new ErrorModel
            {
                Errors = new Dictionary<string, HashSet<string>> { 
                    { propertyName, new HashSet<string> { propertyError } } 
                },
                Status = (int)status,
                Title = title,
                TraceId = Guid.NewGuid()
            };

        /// <summary>
        /// Generate error model
        /// </summary>
        /// <param name="title"></param>
        /// <param name="validationResults"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static ErrorModel GetErrorModel(string title, List<ValidationResult> validationResults, HttpStatusCode status)
        {
            Dictionary<string, HashSet<string>> propertyErrors = new Dictionary<string, HashSet<string>>();
            foreach (string propertyName in validationResults.Select(x => x.MemberNames.First()).GroupBy(x => x).Select(x => x.Key))
                propertyErrors.Add(propertyName, new HashSet<string>(validationResults.Where(x => x.MemberNames.First() == propertyName).Select(x => x.ErrorMessage).ToList()));
            return new ErrorModel
            {
                Errors = propertyErrors,
                Status = (int)status,
                Title = title,
                TraceId = Guid.NewGuid()
            }; ;
        }

        /// <summary>
        /// Generate error model
        /// </summary>
        /// <param name="validationResults"></param>
        /// <returns></returns>
        public static ErrorModel GetErrorModel(List<ValidationResult> validationResults) =>
            GetErrorModel("Bad request.", validationResults, HttpStatusCode.BadRequest);
    }
}

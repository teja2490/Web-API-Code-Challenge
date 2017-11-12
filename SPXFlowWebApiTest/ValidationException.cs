using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPXFlowWebApiTest
{
    public class ValidationException : Exception
    {
        private readonly ModelStateDictionary _modelState;
        private string p;
        private System.Web.Http.ModelBinding.ModelStateDictionary ModelState;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="modelState">State of the model.</param>
        public ValidationException(string message, ModelStateDictionary modelState)
            : base(message)
        {
            _modelState = modelState;
        }

        public ValidationException(string p, System.Web.Http.ModelBinding.ModelStateDictionary ModelState)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.ModelState = ModelState;
        }

        internal List<Error> GetErrorDetails()
        {
            return _modelState.Keys.SelectMany(key => _modelState[key].Errors
                                                        .Select(x => new Error
                                                        {
                                                            Target = key,
                                                            Message = !string.IsNullOrEmpty(x.ErrorMessage) ? x.ErrorMessage : "Invalid value"
                                                        })).ToList();
        }
    }

    /// <summary>
    /// Error Model Class
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Http Status Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Error message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Property name
        /// </summary>
        /// <value>
        /// Target
        /// </value>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Target { get; set; }

        /// <summary>
        /// List of validation errors
        /// </summary>
        public List<Error> Details { get; set; }

        /// <summary>
        /// Inner Error
        /// </summary>
        public InnerError Innererror { get; set; }

    }

    public class InnerError
    {
        /// <summary>
        /// Gets or sets the trace.
        /// </summary>
        /// <value>
        /// The trace.
        /// </value>
        public string Trace { get; set; }
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public string Context { get; set; }
    }
}
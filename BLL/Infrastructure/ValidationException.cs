using System;

namespace BLL.Infrastructure
{
    /// <summary>
    /// Class for exception validation.
    /// </summary>
    public class ValidationException : Exception
    {
        public string Property { get; protected set; }
        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}

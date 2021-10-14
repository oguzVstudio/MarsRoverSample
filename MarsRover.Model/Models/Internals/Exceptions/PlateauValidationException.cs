using MarsRover.Core.Interfaces.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Model.Models.Internals.Exceptions
{
    public class PlateauValidationException : Exception, IException
    {
        public PlateauValidationException() : base(HandleExceptionMessage())
        {
        }

        public PlateauValidationException(string message) : base(HandleExceptionMessage(message))
        {
        }

        private static string HandleExceptionMessage(string message = null)
        {
            return string.IsNullOrEmpty(message) ? "Out of Range!" : message;
        }

        public PlateauValidationException(string message, Exception innerException) : base(message, innerException) { }
    }
}

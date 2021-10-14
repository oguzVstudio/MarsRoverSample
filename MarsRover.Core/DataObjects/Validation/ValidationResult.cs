using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.DataObjects.Validation
{
    public class ValidationResult
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}

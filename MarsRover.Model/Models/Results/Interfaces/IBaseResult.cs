using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Model.Models.Results.Interfaces
{
    public interface IBaseResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}

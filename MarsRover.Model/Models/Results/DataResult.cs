using MarsRover.Model.Models.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Model.Models.Results
{
    public class DataResult<T> : IDataResult<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}

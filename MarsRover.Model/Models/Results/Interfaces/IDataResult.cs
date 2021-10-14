using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Model.Models.Results.Interfaces
{
    public interface IDataResult<T> : IBaseResult
    {
        public T Data { get; set; }
    }
}

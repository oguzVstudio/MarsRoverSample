using MarsRover.Model.Models.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Model.Models.Results
{
    public class BaseResult : IBaseResult
    {
        public BaseResult()
        {
            this.Success = true;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}

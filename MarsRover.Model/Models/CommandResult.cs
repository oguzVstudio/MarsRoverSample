using MarsRover.Model.Interfaces;
using MarsRover.Model.Models.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Model.Models
{
    class CommandResult
    {
        public IDataResult<IPlateau> Plateau { get; set; }
        public IDataResult<IRover> Rover { get; set; }
    }
}

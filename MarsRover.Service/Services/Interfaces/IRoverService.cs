using MarsRover.Model.Enums;
using MarsRover.Model.Interfaces;
using MarsRover.Model.Models.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Service.Services.Interfaces
{
    public interface IRoverService
    {
        IDataResult<IRover> CreateRover(IPlateau plateau, string roverPosition);
        IDataResult<string> Move(IRover rover, string navigationLetters);
    }
}

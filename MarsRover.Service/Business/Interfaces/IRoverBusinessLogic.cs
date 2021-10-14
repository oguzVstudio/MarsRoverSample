using MarsRover.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Service.Business.Interfaces
{
    internal interface IRoverBusinessLogic
    {
        IRover CreateRover(IPlateau plateau, string roverPosition);
        void Movement(IRover rover, string navigationLetters);
    }
}

using MarsRover.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Service.Business.Interfaces
{
    internal interface IPlateauBusinessLogic
    {
        IPlateau Create(string plateauString);
        IPlateau Plateau { get; }
    }
}

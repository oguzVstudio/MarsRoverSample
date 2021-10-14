using MarsRover.Model.Models.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Model.Interfaces
{
    public interface IVehicle
    {
        Location Location { get; }
        IPlateau Plateau { get; }
        void Move();
        void TurnLeft();
        void TurnRight();
    }
}

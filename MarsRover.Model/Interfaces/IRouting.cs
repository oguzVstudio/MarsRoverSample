using MarsRover.Model.Enums;
using MarsRover.Model.Models.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Model.Interfaces
{
    public interface IRouting
    {
        public NavigationFace RouteCommand { get; }
        public Int16 Angle { get;}
        IRouting TurnRight();
        IRouting TurnLeft();
        Location Move(Location location);
    }
}

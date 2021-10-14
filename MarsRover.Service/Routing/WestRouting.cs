using MarsRover.Model.Enums;
using MarsRover.Model.Interfaces;
using MarsRover.Model.Models.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Service.Routing
{
    public class WestRouting : IRouting
    {
        public NavigationFace RouteCommand => NavigationFace.W;
        public Int16 Angle => (Int16)NavigationFace.W;

        public Location Move(Location location)
        {
            return new Location(location.X - 1, location.Y);
        }

        public IRouting TurnLeft()
        {
            return new SouthRouting();
        }

        public IRouting TurnRight()
        {
            return new NorthRouting();
        }
    }
}

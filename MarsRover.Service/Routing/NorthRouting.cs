using MarsRover.Model.Enums;
using MarsRover.Model.Interfaces;
using MarsRover.Model.Models.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Service.Routing
{
    public class NorthRouting : IRouting
    {
        public NavigationFace RouteCommand => NavigationFace.N;
        public Int16 Angle => (Int16)NavigationFace.N;

        public Location Move(Location location)
        {
            return new Location(location.X, location.Y + 1);
        }

        public IRouting TurnLeft()
        {
            return new WestRouting();
        }

        public IRouting TurnRight()
        {
            return new EastRouting();
        }
    }
}

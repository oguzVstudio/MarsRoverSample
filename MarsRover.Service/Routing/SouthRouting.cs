using MarsRover.Model.Enums;
using MarsRover.Model.Interfaces;
using MarsRover.Model.Models.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Service.Routing
{
    public class SouthRouting : IRouting
    {
        public NavigationFace RouteCommand => NavigationFace.S;

        public Int16 Angle => (Int16)NavigationFace.S;

        public Location Move(Location location)
        {
            return new Location(location.X, location.Y - 1);
        }

        public IRouting TurnLeft()
        {
            return new EastRouting();
        }

        public IRouting TurnRight()
        {
            return new WestRouting();
        }
    }
}

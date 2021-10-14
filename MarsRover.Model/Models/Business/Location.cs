using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Model.Models.Business
{
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

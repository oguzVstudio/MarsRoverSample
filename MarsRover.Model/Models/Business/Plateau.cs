using MarsRover.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Model.Models.Business
{
    public class Plateau : IPlateau
    {
        public int Height { get; private set; }

        public int Width { get; private set; }

        public Plateau(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public bool IsCorrectLocation(Location location)
        {
            return location.X <= Width && location.Y <= Height;
        }
    }
}

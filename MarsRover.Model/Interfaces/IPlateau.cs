using MarsRover.Model.Models.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Model.Interfaces
{
    public interface IPlateau
    {
        int Height { get; }
        int Width { get; }
        bool IsCorrectLocation(Location location);
    }
}

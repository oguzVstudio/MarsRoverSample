using MarsRover.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Model.Interfaces
{
    public interface IRover
    {
        void Process(IEnumerable<NavigationLetters> navigationLetters);
        string GetLastPosition();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public interface IFactory
    {
        void CommandForConsole();
        string Command(string plateauCoordinates, string roverPosition, string navigationLetters);
    }
}

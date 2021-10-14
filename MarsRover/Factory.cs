using MarsRover.Model.Interfaces;
using MarsRover.Model.Models.Internals.Exceptions;
using MarsRover.Model.Models.Results.Interfaces;
using MarsRover.Service.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Factory : IFactory
    {
        private readonly IPlateauService _plateauService;
        private readonly IRoverService _roverService;

        public Factory(IRoverService roverService, IPlateauService plateauService)
        {
            _plateauService = plateauService;
            _roverService = roverService;
        }

        public string Command(string plateauCoordinates, string roverPosition, string navigationLetters)
        {
            var plateauResult = _plateauService.Create(plateauCoordinates);
            if (!plateauResult.Success)
                throw new PlateauValidationException(plateauResult.Message);
            var roverResult = _roverService.CreateRover(plateauResult.Data, roverPosition);
            if (!roverResult.Success)
                throw new Exception(roverResult.Message);
            var moveResult = _roverService.Move(roverResult.Data, navigationLetters);
            if (!moveResult.Success)
                throw new Exception(moveResult.Message);

            return roverResult.Data.GetLastPosition();
        }

        public void CommandForConsole()
        {
            IDataResult<IPlateau> plateauResult;

            do
            {
                Console.WriteLine("Please enter plateau co-ordinates X Y");
                string plateauCoordinates = Console.ReadLine();
                plateauResult = _plateauService.Create(plateauCoordinates);
                Console.WriteLine(plateauResult.Message);

            } while (!plateauResult.Success);

            do
            {
                Console.WriteLine($"Please enter Rover position like X Y N {{N--> N,E,S,W - X--> [0-9] - Y--> [0-9]}}");
                string roverPosition = Console.ReadLine();
                var roverResult = _roverService.CreateRover(plateauResult.Data, roverPosition);
                if(!roverResult.Success)
                {
                    Console.WriteLine(roverResult.Message);
                    continue;
                }
                else
                    Console.WriteLine($"Rover located on {roverPosition}");
                do
                {
                    Console.WriteLine($"Please enter rover navigation letters {{M->Move, L->Left, R->Right}} like LMLMLMLMM");
                    string navigationLetters = Console.ReadLine();
                    var moveResult = _roverService.Move(roverResult.Data, navigationLetters);
                    if (!roverResult.Success)
                    {
                        Console.WriteLine(roverResult.Message);
                        continue;
                    }
                    else
                    {
                        Console.Clear();                        
                        Console.WriteLine(moveResult.Data);
                    }
                } while (!roverResult.Success);
            } while (true);
            
        }
    }
}

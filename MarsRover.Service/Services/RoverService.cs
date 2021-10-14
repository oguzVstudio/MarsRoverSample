using MarsRover.Model.Enums;
using MarsRover.Model.Interfaces;
using MarsRover.Model.Models.Business;
using MarsRover.Model.Models.Internals.Exceptions;
using MarsRover.Model.Models.Results;
using MarsRover.Model.Models.Results.Interfaces;
using MarsRover.Service.Business;
using MarsRover.Service.Business.Interfaces;
using MarsRover.Service.Services.Interfaces;
using MarsRover.Service.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;


namespace MarsRover.Service.Services
{
    public class RoverService : IRoverService
    {
        private IRoverBusinessLogic _roverBusinessLogic;
        private readonly IPlateauService _plateauService;
        public RoverService(IPlateauService plateauService)
        {
            _plateauService = plateauService;
            _roverBusinessLogic = new RoverBusinessLogic();
        }
        public IDataResult<IRover> CreateRover(IPlateau plateau, string roverPosition)
        {
            try
            {
                var roverResult = _roverBusinessLogic.CreateRover(plateau, roverPosition);
                return new DataResult<IRover>()
                {
                    Data = roverResult,
                    Message = null,
                    Success = true
                };
            }
            catch (Exception _ex)
            {
                return new DataResult<IRover>()
                {
                    Data = null,
                    Message = _ex.Message,
                    Success = false
                };
            }            
        }

        public IDataResult<string> Move(IRover rover, string navigationLetters)
        {
            try
            {
                string firstPosition = rover.GetLastPosition();

                _roverBusinessLogic.Movement(rover, navigationLetters);
                
                string lastPosition = rover.GetLastPosition();
                
                var plateau = _plateauService.CurrentPlateau();

                var sb = new StringBuilder();
                sb.AppendLine($"Plateau size: X= {plateau.Data.Width} Y={plateau.Data.Height}");
                sb.AppendLine($"Navigation letters: {navigationLetters}");
                sb.AppendLine($"Rover is moved from {firstPosition} to {lastPosition}");

                return new DataResult<string>()
                {
                    Data = sb.ToString(),
                    Success = true,
                    Message = null
                };
            }
            catch (Exception _ex)
            {
                return new DataResult<string>()
                {
                    Success = false,
                    Message = _ex.Message
                };
            }            
        }
    }
}

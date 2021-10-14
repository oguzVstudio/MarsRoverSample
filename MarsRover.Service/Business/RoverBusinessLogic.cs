using MarsRover.Core.Validators;
using MarsRover.Model.Enums;
using MarsRover.Model.Interfaces;
using MarsRover.Model.Models.Business;
using MarsRover.Model.Models.Internals.Exceptions;
using MarsRover.Service.Business.Interfaces;
using MarsRover.Service.Utilities;
using MarsRover.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover.Service.Business
{
    internal class RoverBusinessLogic : IRoverBusinessLogic
    {
        private IValidator _roverValidator;
        private IValidator _roverNavigationValidator;

        public IRover CreateRover(IPlateau plateau, string roverPosition)
        {
            if (plateau is null)
                throw new PlateauValidationException("Plateau is not defined!");

            _roverValidator = new RoverValidator();

            var result = _roverValidator.Validate(roverPosition);
            Match roverMatch = null;
            if (result.Success)
            {
                roverMatch = Regex.Match(roverPosition, RegexPatterns.RoverPosition, RegexOptions.Singleline);
            }
            else
            {
                var sb = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    sb.AppendLine(error);
                }

                throw new Exception(sb.ToString());
            }

            int axisX = Int16.Parse(roverMatch.Groups[1].Value), axisY = Int16.Parse(roverMatch.Groups[2].Value);
            NavigationFace navigationFace = (NavigationFace)(Enum.Parse(typeof(NavigationFace), roverMatch.Groups[3].Value));

            var routings = GetRoutingsInAssembly();
            IRouting routing = routings.FirstOrDefault(u => u.RouteCommand == navigationFace);

            return new Rover(plateau, new Location(axisX, axisY), routing);
        }

        public void Movement(IRover rover, string navigationLetters)
        {
            _roverNavigationValidator = new RoverNavigationValidator();
            var result = _roverNavigationValidator.Validate(navigationLetters);

            if (!result.Success)
            {
                var sb = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    sb.AppendLine(error);
                }

                throw new Exception(sb.ToString());
            }


            IList<NavigationLetters> navigations = new List<NavigationLetters>();
            foreach (var navigationLetter in navigationLetters)
            {
                var command = (NavigationLetters)Enum.Parse(typeof(NavigationLetters), navigationLetter.ToString());
                navigations.Add(command);
            }

            rover.Process(navigations);
        }

        private IEnumerable<IRouting> GetRoutingsInAssembly()
        {
            return Assembly.GetExecutingAssembly().ExportedTypes.Where(x =>
                typeof(IRouting).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IRouting>().ToList();
        }
    }
}

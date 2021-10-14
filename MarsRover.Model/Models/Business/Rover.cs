using MarsRover.Model.Enums;
using MarsRover.Model.Interfaces;
using MarsRover.Model.Models.Internals.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Model.Models.Business
{
    public class Rover : IRover, IVehicle
    {
        private readonly IPlateau _plateau;
        private Location _location;
        private IRouting _routing;

        public Rover(IPlateau plateau, Location location, IRouting routing)
        {
            _location = location;
            _plateau = plateau;
            if (!_plateau.IsCorrectLocation(_location))
                throw new PlateauValidationException();

            _routing = routing;
        }
        public Location Location
        {
            get { return _location; }
        }

        public IPlateau Plateau
        {
            get { return _plateau; }
        }

        public void Move()
        {
            var location = _routing.Move(_location);
            if (!_plateau.IsCorrectLocation(_location))
                throw new PlateauValidationException();

            _location = location;
        }

        public void Process(IEnumerable<NavigationLetters> navigationLetters)
        {
            foreach (var navigation in navigationLetters)
            {
                switch (navigation)
                {
                    case NavigationLetters.L:
                        this.TurnLeft();
                        break;
                    case NavigationLetters.R:
                        this.TurnRight();
                        break;
                    case NavigationLetters.M:
                        this.Move();
                        break;
                    default:
                        throw new ArgumentException($"Invalid routing: {navigation.ToString()}");
                }
            }
        }

        public void TurnLeft()
        {
            _routing = _routing.TurnLeft();
        }

        public void TurnRight()
        {
            _routing = _routing.TurnRight();
        }

        public string GetLastPosition()
        {
            return $"{_location.X} {_location.Y} {_routing.RouteCommand.ToString()}";
        }
    }
}

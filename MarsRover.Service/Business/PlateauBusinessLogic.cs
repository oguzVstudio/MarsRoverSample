using MarsRover.Core.Validators;
using MarsRover.Model.Interfaces;
using MarsRover.Model.Models.Business;
using MarsRover.Model.Models.Internals.Exceptions;
using MarsRover.Service.Business.Interfaces;
using MarsRover.Service.Utilities;
using MarsRover.Service.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover.Service.Business
{
    internal class PlateauBusinessLogic : IPlateauBusinessLogic
    {
        private IValidator _plateauValidator;
        public IPlateau Plateau { get; private set; }

        public IPlateau Create(string plateauString)
        {
            _plateauValidator = new PlateauValidator();

            var result = _plateauValidator.Validate(plateauString);

            if (result.Success)
            {
                var match = Regex.Match(plateauString, RegexPatterns.PlateauSize, RegexOptions.Singleline);
                Plateau = new Plateau(UInt16.Parse(match.Groups[1].Value), UInt16.Parse(match.Groups[2].Value));
            }
            else
            {
                var sb = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    sb.AppendLine(error);
                }

                throw new PlateauValidationException(sb.ToString());
            }

            return Plateau;
        }
    }
}

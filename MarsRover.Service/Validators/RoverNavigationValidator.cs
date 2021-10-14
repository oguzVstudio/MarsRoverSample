using MarsRover.Core.DataObjects.Validation;
using MarsRover.Core.Validators;
using MarsRover.Service.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover.Service.Validators
{
    public class RoverNavigationValidator : IValidator
    {
        public ValidationResult Validate(object @object)
        {

            bool success = false;
            IList<string> messages = new List<string>();
            if (@object.GetType() != typeof(string))
                messages.Add("Invalid Input Type!");

            if (string.IsNullOrEmpty(@object.ToString()))
                messages.Add("Input is null");
            else
            {
                var match = Regex.Match(@object.ToString(), RegexPatterns.Command, RegexOptions.Singleline);
                success = match.Success;
                if (!match.Success)
                    messages.Add($"Navigation command text = {@object} is not valid!"); ;
            }


            return new ValidationResult()
            {
                Success = success,
                Errors = success ? null : messages
            };
        }
    }
}

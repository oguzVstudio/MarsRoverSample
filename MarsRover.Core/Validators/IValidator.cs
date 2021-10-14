using MarsRover.Core.DataObjects.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Validators
{
    public interface IValidator
    {
        ValidationResult Validate(object @object);
    }
    public interface IValidator<T> : IValidator where T : class, new()
    {
        ValidationResult Validate(T entity);
    }
}

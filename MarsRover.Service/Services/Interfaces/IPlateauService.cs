using MarsRover.Model.Interfaces;
using MarsRover.Model.Models.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Service.Services.Interfaces
{
    public interface IPlateauService
    {
        IDataResult<IPlateau> Create(string plateauString);
        IDataResult<IPlateau> CurrentPlateau();
    }
}

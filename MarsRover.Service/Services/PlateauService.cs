using MarsRover.Core.Validators;
using MarsRover.Model.Interfaces;
using MarsRover.Model.Models.Business;
using MarsRover.Model.Models.Results;
using MarsRover.Model.Models.Results.Interfaces;
using MarsRover.Service.Business;
using MarsRover.Service.Business.Interfaces;
using MarsRover.Service.Services.Interfaces;
using MarsRover.Service.Utilities;
using MarsRover.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover.Service.Services
{
    public class PlateauService : IPlateauService
    {
        private IPlateauBusinessLogic _plateauBusinessLogic;

        public PlateauService()
        {
            _plateauBusinessLogic = new PlateauBusinessLogic();
        }
        public IDataResult<IPlateau> Create(string plateauString)
        {            
            IPlateau plateau = null;
            try
            {
                plateau = _plateauBusinessLogic.Create(plateauString);

                return new DataResult<IPlateau>()
                {
                    Data = plateau,
                    Message = null,
                    Success = true
                };
            }
            catch (Exception _ex)
            {
                return new DataResult<IPlateau>()
                {
                    Data = plateau,
                    Message = _ex.Message,
                    Success = false
                };
            }            
        }

        public IDataResult<IPlateau> CurrentPlateau()
        {
            if (_plateauBusinessLogic.Plateau != null)
                return new DataResult<IPlateau>()
                {
                    Data = _plateauBusinessLogic.Plateau,
                    Message = null,
                    Success = true
                };

            else
                return new DataResult<IPlateau>()
                {
                    Success = false,
                    Message = "Plateau has not been initialized"
                };
        }
    }
}

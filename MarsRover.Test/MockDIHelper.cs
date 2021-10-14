using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Service.Services;
using MarsRover.Service.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Test
{
    class MockDIHelper
    {
        private IServiceProvider _serviceProvider { get; }

        public MockDIHelper()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IPlateauService, PlateauService>()
                .AddSingleton<IRoverService, RoverService>()
                .AddSingleton<IFactory, Factory>()
                .BuildServiceProvider();

            _serviceProvider = serviceProvider;
        }

        public IServiceProvider ServiceProvider
        {
            get
            {
                return _serviceProvider;
            }
        }


    }
}

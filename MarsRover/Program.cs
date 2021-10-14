using MarsRover.Core.DataObjects.Enum;
using MarsRover.Core.Extensions;
using MarsRover.Model.Enums;
using MarsRover.Service.Services;
using MarsRover.Service.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IPlateauService, PlateauService>()
                .AddSingleton<IRoverService, RoverService>()
                .AddSingleton<IFactory,Factory>()
                .BuildServiceProvider();

            var factory = serviceProvider.GetRequiredService<IFactory>();
            factory.CommandForConsole();

            Console.Read();
        }
    }
}

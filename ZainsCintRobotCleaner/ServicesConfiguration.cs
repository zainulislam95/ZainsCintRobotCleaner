using Cleaner.Service.Implementations;
using Cleaner.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ZainsCintRobotCleaner
{
    public static class ServicesConfiguration
    {
        public static ServiceProvider BuildServiceProvider()
        { 
            var serviceProvider = new ServiceCollection() 
                .AddScoped<IRobotCleanerService, RobotCleanerService>()
                .AddScoped<IRobotInputService, RobotInputService>()
                .AddScoped<IRobotOutputService, RobotOutputService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}

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
                .AddScoped<IRobotInputService, RobotInputService>()
                .AddScoped<IRobotOutputService, RobotOutputService>()
                .AddScoped<IRobotCleanerService, RobotCleanerService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}

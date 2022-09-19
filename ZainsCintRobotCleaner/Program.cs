using Cleaner.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using ZainsCintRobotCleaner;

var serviceProvider = ServicesConfiguration.BuildServiceProvider();

var robotCleanerService = serviceProvider.GetService<IRobotCleanerService>();
robotCleanerService!.Clean();
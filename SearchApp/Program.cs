// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Search;
using Search.Interfaces;
using Search.Services;
using SearchApp.Interfaces;
using SearchApp.Services;

if (args.Count() != 1)
{
    Console.WriteLine("use: searchApp.exe <path>");
    return;
}

// Service container (Dependency injection)
var builder = new ServiceCollection()
    .AddSingleton<Application>()
    .AddSingleton<IDirectoryService, DirectoryService>() 
    .AddSingleton<IFileService, FileService>()
    .AddSingleton<ITopService, TopService>()
    .AddSingleton<ICacheService, CacheService>()
    .AddSingleton<ICountService, CountService>()
    .BuildServiceProvider();

Application console = builder.GetRequiredService<Application>();
console.Run(args[0].Trim());
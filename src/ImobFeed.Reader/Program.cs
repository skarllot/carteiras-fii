using System.IO.Abstractions;
using ImobFeed.Reader;
using ImobFeed.Reader.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

var serviceCollection = new ServiceCollection();
serviceCollection
    .AddSingleton<IFileSystem, FileSystem>();

var registrar = new TypeRegistrar(serviceCollection);

var app = new CommandApp(registrar);
app.Configure(
    config =>
    {
        config.AddCommand<TextFileCommand>("texto");
        config.AddCommand<ImageFileCommand>("imagem");
    });

return app.Run(args);
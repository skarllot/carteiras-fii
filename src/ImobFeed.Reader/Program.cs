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
        config.AddCommand<IndexCommand>("indice");
        config.AddCommand<TopCommand>("top");
        config.AddCommand<FavoritosCommand>("favoritos");
        config.AddCommand<AtualizarListaAtivosCommand>("atualizar-ativos");
    });

return app.Run(args);
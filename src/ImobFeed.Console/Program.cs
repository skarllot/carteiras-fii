using System.IO.Abstractions;
using ImobFeed.Api;
using ImobFeed.Console.Commands;
using ImobFeed.Console.DependencyInjection;
using ImobFeed.Core;
using ImobFeed.Html;
using ImobFeed.Leitores;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

var serviceCollection = new ServiceCollection();
serviceCollection
    .AddSingleton<IFileSystem, FileSystem>()
    .AdicionarImobFeedCore()
    .AdicionarImobFeedLeitores()
    .AdicionarImobFeedApi()
    .AdicionarImobFeedHtml();

var registrar = new TypeRegistrar(serviceCollection);

var app = new CommandApp(registrar);
app.Configure(
    config =>
    {
        config.AddCommand<TextFileCommand>("texto");
        config.AddCommand<ImageFileCommand>("imagem");
        config.AddCommand<IndexCommand>("indice");
        config.AddCommand<FavoritosCommand>("favoritos");
        config.AddCommand<AtualizarListaAtivosCommand>("atualizar-ativos");
    });

return app.Run(args);
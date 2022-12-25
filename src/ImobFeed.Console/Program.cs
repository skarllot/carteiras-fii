using ImobFeed.Console.Commands;
using ImobFeed.Console.DependencyInjection;
using Spectre.Console.Cli;

var registrar = new TypeRegistrar();

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
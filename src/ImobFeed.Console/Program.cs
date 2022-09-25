using System.IO.Abstractions;
using ImobFeed.Api.Analise;
using ImobFeed.Api.Indexacao;
using ImobFeed.Console;
using ImobFeed.Console.DependencyInjection;
using ImobFeed.Core;
using ImobFeed.Core.Analise;
using ImobFeed.Core.Recomendacoes;
using ImobFeed.Html.Analise;
using ImobFeed.Html.Referencia;
using ImobFeed.Leitores.Texto;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

var serviceCollection = new ServiceCollection();
serviceCollection
    .AddSingleton<IFileSystem, FileSystem>()
    .AddSingleton<DefaultAppConfiguration>()
    .AddSingleton<IAppConfiguration>(provider => provider.GetRequiredService<DefaultAppConfiguration>())
    .AddSingleton<ReferenciaAtivos>()
    .AddSingleton<EscritorIndicacoesFavoritas>()
    .AddSingleton<CalculadoraIndicacoesFavoritas>()
    .AddSingleton<INomeArquivoCorretora, NomeArquivoCorretora>()
    .AddSingleton<IndicacoesFavoritasHtml>()
    .AddSingleton<Indices>()
    .AddSingleton<IndicesRaiz>()
    .AddSingleton<IndicesAno>()
    .AddSingleton<IndicesMes>()
    .AddSingleton<IndicesCorretora>();

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
using System.Collections.Immutable;
using System.IO.Abstractions;
using System.Text;
using System.Text.Json;
using ImobFeed.Core.Common;
using Stubble.Core;
using Stubble.Core.Builders;
using Stubble.Core.Settings;

namespace ImobFeed.Core.Analise;

public class IndicacoesFavoritasHtml
{
    private readonly IFileSystem _fileSystem;
    private readonly StubbleVisitorRenderer _stubble;
    private readonly RenderSettings _renderSettings;

    public IndicacoesFavoritasHtml(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        _stubble = new StubbleBuilder().Build();
        _renderSettings = RenderSettings.GetDefaultRenderSettings();
        _renderSettings.CultureInfo = CultureCache.PortuguesBrasil;
    }

    private const string Template =
        @"<!DOCTYPE html>
<html lang=""pt-BR"">
<head>
  <title>Indicações Favoritas em {{Mes}}/{{Ano}}</title>
  <meta charset=""utf-8"">
  <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
  <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css"" rel=""stylesheet"" integrity=""sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT"" crossorigin=""anonymous"">
  <script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/js/bootstrap.bundle.min.js"" integrity=""sha384-u1OknCvxWvY5kfmNBILK2hRnQC3Pr17a+RTT6rIHI7NnikvbZlHgTPOOmMi466C8"" crossorigin=""anonymous""></script>
  <style>
table.table tbody tr td {
  border-left: 1px solid #718698;
}
table.table tbody tr td:first-child {
  border: none;
}
  </style>
</head>
<body>
<div class=""container"">
  <h1 class=""display-1"">Indicações Favoritas em {{Mes}}/{{Ano}}</h1>
  <br />
  <div >
  <table class=""table table-sm table-striped"">
    <thead class=""table-light"">
      <tr>
        <th scope=""col"" class=""text-nowrap"">Código</th>
        <th scope=""col"" class=""text-nowrap"">Nome</th>
        <th scope=""col"" class=""text-nowrap"">Segmento</th>
        <th scope=""col"" class=""text-nowrap"">Administrador</th>
        <th scope=""col"" class=""text-nowrap"">P/VPA</th>
        <th scope=""col"" class=""text-nowrap"">Yield 1 Mês</th>
        <th scope=""col"" class=""text-nowrap"">Yield 12 Meses</th>
        <th scope=""col"" class=""text-nowrap"">Peso</th>
        <th scope=""col"" class=""text-nowrap"">Corretoras</th>
      </tr>
    </thead>
    <tbody>
{{#Indicacoes}}
      <tr>
        <td>{{Codigo}}</td>
        <td>{{Nome}}</td>
        <td>{{Segmento}}</td>
        <td>{{Administrador}}</td>
        <td>{{PVpa}}</td>
        <td>{{Yield1Mes}}%</td>
        <td>{{Yield12Meses}}%</td>
        <td>{{Peso}}%</td>
        <td>{{#Corretoras}}{{.}}{{/Corretoras}}</td>
      </tr>
{{/Indicacoes}}
    </tbody>
  </table>
  </div>
</div>
</body>
</html>
";

    public void Criar(IDirectoryInfo baseDirectory, IProgress<string> progress)
    {
        foreach (var file in baseDirectory.EnumerateFiles("??????-favoritos.json", SearchOption.TopDirectoryOnly))
        {
            Criar(file, progress);
        }
    }

    private void Criar(IFileInfo source, IProgress<string> progress)
    {
        var destination = _fileSystem.FileInfo.FromFileName(source.FullName.Replace(".json", ".html"));
        if (destination.Exists && destination.LastWriteTimeUtc > source.LastWriteTimeUtc)
            return;

        using var stream = source.OpenRead();
        var indicacoesFavoritas = JsonSerializer.Deserialize<ListaIndicacoesFavoritas>(
            stream,
            SourceGenerationContext.Default.Options)!;

        string result = _stubble.Render(
            Template,
            indicacoesFavoritas with
            {
                Indicacoes = indicacoesFavoritas.Indicacoes
                    .Select(
                        it => it with
                        {
                            Peso = Math.Round(it.Peso * 100m, 2),
                            Yield1Mes = it.Yield1Mes is not null
                                ? Math.Round(it.Yield1Mes.Value * 100m, 2)
                                : null,
                            Yield12Meses = it.Yield12Meses is not null
                                ? Math.Round(it.Yield12Meses.Value * 100m, 2)
                                : null,
                            Corretoras = ImmutableArray.Create(string.Join(", ", it.Corretoras))
                        })
                    .ToImmutableArray()
            },
            _renderSettings);

        _fileSystem.File.WriteAllText(destination.FullName, result, Encoding.UTF8);

        progress.Report(destination.FullName);
    }
}
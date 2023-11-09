using System.IO.Abstractions;
using System.Text.Json;
using ImobFeed.Core;
using ImobFeed.Core.Recomendacoes.Modelos;

namespace ImobFeed.Api.Recomendacoes;

public static class SerializadorArquivoCarteira
{
    public static void Salvar(IFileInfo fileInfo, ArquivoCarteira arquivoCarteira)
    {
        using var fileStream = fileInfo.Open(FileMode.Create, FileAccess.ReadWrite);
        JsonSerializer.Serialize(fileStream, arquivoCarteira, JsonSerializerOptionsProvider.Default);

        fileStream.Flush();
    }

    public static ArquivoCarteira? Ler(IFileInfo fileInfo)
    {
        using var stream = fileInfo.OpenRead();
        return JsonSerializer.Deserialize<ArquivoCarteira>(stream, JsonSerializerOptionsProvider.Default);
    }
}
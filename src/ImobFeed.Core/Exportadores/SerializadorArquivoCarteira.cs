using System.IO.Abstractions;
using System.Text.Json;

namespace ImobFeed.Core.Exportadores;

public static class SerializadorArquivoCarteira
{
    public static void Salvar(IFileInfo fileInfo, ArquivoCarteira arquivoCarteira)
    {
        using var fileStream = fileInfo.Open(FileMode.Create, FileAccess.ReadWrite);
        JsonSerializer.Serialize(fileStream, arquivoCarteira, SourceGenerationContext.Default.Options);

        fileStream.Flush();
    }

    public static ArquivoCarteira? Ler(IFileInfo fileInfo)
    {
        using var stream = fileInfo.OpenRead();
        return JsonSerializer.Deserialize<ArquivoCarteira>(stream, SourceGenerationContext.Default.Options);
    }
}
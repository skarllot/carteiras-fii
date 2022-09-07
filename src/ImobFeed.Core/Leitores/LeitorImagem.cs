using System.IO.Abstractions;
using Tesseract;

namespace ImobFeed.Core.Leitores;

public sealed class LeitorImagem
{
    public string LerTextoImagem(IFileInfo fileInfo)
    {
        using var engine = new TesseractEngine("./tessdata", "eng", EngineMode.Default);
        using var img = Pix.LoadFromFile(fileInfo.FullName);
        using var page = engine.Process(img);
        return page.GetText();
    }
}
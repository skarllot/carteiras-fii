using System.Text.Json;
using ImobFeed.Core;
using ImobFeed.Core.Referencia;
using ImobFeed.Core.Referencia.Modelos;
using NodaTime;

namespace ImobFeed.Api.Referencia;

public class EscritorListaAtivosIndicadores
{
    private readonly IAppConfiguration _appConfig;
    private readonly IClock _clock;
    private readonly IFonteReferenciaAtivos _fonteReferenciaAtivos;
    private readonly IReferenciaAtivos _referenciaAtivos;

    public EscritorListaAtivosIndicadores(
        IAppConfiguration appConfig,
        IClock clock,
        IFonteReferenciaAtivos fonteReferenciaAtivos,
        IReferenciaAtivos referenciaAtivos)
    {
        _appConfig = appConfig;
        _clock = clock;
        _fonteReferenciaAtivos = fonteReferenciaAtivos;
        _referenciaAtivos = referenciaAtivos;
    }

    public void Explorar(IProgress<ArquivoCriado> progress)
    {
        var now = _clock.GetCurrentInstant().InUtc();
        var apiReferencia = _appConfig.GetApiDirectory().IrParaApiReferencia();

        var (listaAtivos, listaIndicadores) = _fonteReferenciaAtivos.BuscarEAgregar();
        var ativosDiff = ListaAtivosDiff.Criar(_referenciaAtivos.CarregarAtivos(), listaAtivos);

        var arqAtivos = apiReferencia.IrParaArquivoReferenciaAtivos();
        using (var stream = arqAtivos.Open(FileMode.Create, FileAccess.Write))
        {
            JsonSerializer.Serialize(stream, listaAtivos, SourceGenerationContext.DefaultWithConverters.Options);
            stream.Flush();
            progress.Report(new ArquivoCriado(arqAtivos.FullName));
        }

        var arqDiff = apiReferencia.IrParaArquivoDiffReferenciaAtivos(now.ToDateTimeOffset());
        using (var stream = arqDiff.Open(FileMode.Create, FileAccess.Write))
        {
            JsonSerializer.Serialize(stream, ativosDiff, SourceGenerationContext.DefaultWithConverters.Options);
            stream.Flush();
            progress.Report(new ArquivoCriado(arqDiff.FullName));
        }

        var arqIndicadores = apiReferencia.IrParaArquivoReferenciaIndicadores(new YearMonth(now.Year, now.Month));
        using (var stream = arqIndicadores.Open(FileMode.Create, FileAccess.Write))
        {
            JsonSerializer.Serialize(stream, listaIndicadores, SourceGenerationContext.DefaultWithConverters.Options);
            stream.Flush();
            progress.Report(new ArquivoCriado(arqIndicadores.FullName));
        }
    }
}
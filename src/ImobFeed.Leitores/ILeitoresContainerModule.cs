using ImobFeed.Core.Recomendacoes;
using ImobFeed.Leitores.Texto;
using Jab;

namespace ImobFeed.Leitores;

[ServiceProviderModule]

// Texto
[Singleton(typeof(INomeArquivoCorretora), typeof(NomeArquivoCorretora))]
public interface ILeitoresContainerModule
{
}
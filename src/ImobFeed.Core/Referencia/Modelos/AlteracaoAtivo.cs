using System.ComponentModel;
using ImobFeed.Core.CarteiraMensal;

namespace ImobFeed.Core.Referencia.Modelos;

public sealed record AlteracaoAtivo(CollectionChangeAction Acao, Ativo? EstadoAnterior, Ativo? EstadoAtual);
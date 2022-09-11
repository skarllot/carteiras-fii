using System.Text.Json.Serialization;

namespace ImobFeed.Core.CarteiraMensal;

[JsonConverter(typeof(PercentualJsonConverter))]
public readonly record struct Percentual(decimal Valor) : IComparable<Percentual>, IComparable
{
    public static readonly Percentual Zero = new(0);

    public override string ToString() => $"{Valor * 100}%";

    public static bool operator <(Percentual left, Percentual right) => left.CompareTo(right) < 0;

    public static bool operator >(Percentual left, Percentual right) => left.CompareTo(right) > 0;

    public static bool operator <=(Percentual left, Percentual right) => left.CompareTo(right) <= 0;

    public static bool operator >=(Percentual left, Percentual right) => left.CompareTo(right) >= 0;

    public int CompareTo(Percentual other) => Valor.CompareTo(other.Valor);

    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(null, obj)) return 1;
        return obj is Percentual other
            ? CompareTo(other)
            : throw new ArgumentException($"Object must be of type {nameof(Percentual)}");
    }
}
using System.Reflection;
using System.Text;
using Validation;

namespace ImobFeed.Html;

public static class Templates
{
    private static readonly Assembly _assembly = typeof(Templates).Assembly;

    public static string IndicacoesFavoritas()
    {
        const string resourceName = "ImobFeed.Html.Analise.IndicacoesFavoritas.mustache";
        return GetString(resourceName);
    }

    private static string GetString(string resourceName)
    {
        using var stream = _assembly.GetManifestResourceStream(resourceName);
        Assumes.NotNull(stream);

        using var reader = new StreamReader(stream, Encoding.UTF8);
        return reader.ReadToEnd();
    }
}
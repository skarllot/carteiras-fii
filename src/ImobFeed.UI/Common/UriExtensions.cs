using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ImobFeed.UI.Common;

public static class UriExtensions
{
    public static void OpenInBrowser(this Uri uri)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            using var proc = new Process { StartInfo = { UseShellExecute = true, FileName = uri.ToString() } };
            proc.Start();
            return;
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            Process.Start("x-www-browser", uri.ToString());
            return;
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            Process.Start("open", uri.ToString());
            return;
        }

        throw new PlatformNotSupportedException(
            $"Cannot open URI in browser for current platform: {RuntimeInformation.RuntimeIdentifier}");
    }
}
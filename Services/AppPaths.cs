using System;
using System.IO;

namespace Mochi.Services;

public static class AppPaths
{
    private const string AppFolderName = "Mochi";
    private const string ConfigFileName = "config.json";
    private const string SaveFileName = "save.json";

    private static string LocalAppDataDir =>
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            AppFolderName);

    public static string ConfigPath => Path.Combine(LocalAppDataDir, ConfigFileName);

    public static string SavePath => Path.Combine(LocalAppDataDir, SaveFileName);

    public static void EnsureAppFolderExists()
    {
        if (!Directory.Exists(LocalAppDataDir)) Directory.CreateDirectory(LocalAppDataDir);
    }
}
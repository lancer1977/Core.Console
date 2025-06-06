using DynamicData;
using System.Diagnostics;

namespace PolyhydraGames.Core.Console.System;

public class AppSwitcher : BaseSwitcher
{
    private static AppSwitcher? _instance;
    public static AppSwitcher Instance => _instance ??= new AppSwitcher();

    public bool SwitchToApp(string appName)
    {
        var proc = Process.GetProcessesByName(appName)
            .FirstOrDefault(p => p.MainWindowHandle != IntPtr.Zero && IsWindowVisible(p.MainWindowHandle));
        return SwitchToProcess(proc, appName);
    }

    public bool SwitchToProcess(Process? proc, string appName = "")
    {
        if (proc != null)
        {
            var handle = proc.MainWindowHandle;
            if (handle != IntPtr.Zero && !IsWindowVisible(handle))
            {
                return SetForegroundWindow(handle);
            }
            else
            {
                WriteLine("Valid window not found for process: " + appName);
            }
        }
        else
        {
            WriteLine($"Process with the name '{appName}' not found.");
        }
        return false;
    }

    public async Task SwitchAllApps(string appName, int delaySeconds)
    {
        var procs = Process.GetProcessesByName(appName)
            .Where(p => p.MainWindowHandle != IntPtr.Zero)
            .ToList();
        //&& !IsWindowVisible(p.MainWindowHandle)
        WriteLine($"Found {procs.Count} visible windows for '{appName}'");

        foreach (var proc in procs)
        {
            SwitchToProcess(proc, appName);
            WriteLine($"Switched to: {proc.MainWindowTitle}");
            await Task.Delay(TimeSpan.FromSeconds(delaySeconds));
        }

        WriteLine("Done");
    }
}
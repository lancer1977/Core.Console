using DynamicData;
using System.Diagnostics;

namespace PolyhydraGames.Core.Console.System;

public class AppSwitcher  
{
    private static AppSwitcher? _instance;
    public static AppSwitcher Instance => _instance ??= new AppSwitcher();

    public bool SwitchToApp(string appName)
    {
        var proc = Process.GetProcessesByName(appName)
            .FirstOrDefault(p => p.MainWindowHandle != IntPtr.Zero && User32.IsWindowVisible(p.MainWindowHandle));
        return SwitchToProcess(proc, appName);
    }

    public bool SwitchToProcess(Process? proc, string appName = "")
    {
        if (proc != null)
        {
            var handle = proc.MainWindowHandle;
            if (handle != IntPtr.Zero && !User32.IsWindowVisible(handle))
            {
                return User32.SetForegroundWindow(handle);
            }
            else
            {
                SharedLogger.WriteLine("Valid window not found for process: " + appName);
            }
        }
        else
        {
            SharedLogger.WriteLine($"Process with the name '{appName}' not found.");
        }
        return false;
    }

    public async Task SwitchAllApps(string appName, int delaySeconds)
    {
        var procs = Process.GetProcessesByName(appName)
            .Where(p => p.MainWindowHandle != IntPtr.Zero)
            .ToList();
        //&& !IsWindowVisible(p.MainWindowHandle)
        SharedLogger.WriteLine($"Found {procs.Count} visible windows for '{appName}'");

        foreach (var proc in procs)
        {
            SwitchToProcess(proc, appName);
            SharedLogger.WriteLine($"Switched to: {proc.MainWindowTitle}");
            await Task.Delay(TimeSpan.FromSeconds(delaySeconds));
        }

        SharedLogger.WriteLine("Done");
    }
}
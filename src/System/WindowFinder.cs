using System.Diagnostics;
using System.Text;

namespace PolyhydraGames.Core.Console.System;

public static class WindowFinder  
{
 

    public static List<AppWindow> GetWindows(string appName)
    {
        var result = new List<AppWindow>();

        User32.EnumWindows((hWnd, lParam) =>
        {
            if (!User32.IsWindowVisible(hWnd))
                return true;

            User32.GetWindowThreadProcessId(hWnd, out int pid);
            var proc = Process.GetProcessById(pid);

            if (!proc.ProcessName.Equals(appName, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            var sb = new StringBuilder(1024);
            User32.GetWindowText(hWnd, sb, sb.Capacity);
            var title = sb.ToString();

            if (!string.IsNullOrWhiteSpace(title))
            {
                result.Add(new AppWindow(pid, title, hWnd));
            }

            return true;
        }, IntPtr.Zero);

        return result;
    }

    public static void SwitchToWindow(AppWindow window)
    {
        SharedLogger.WriteLine($"Bringing to front: [{window.PID}] {window.Title}");
        User32.SetForegroundWindow(window.Handle);
    }


}

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace OAuth.Core.System;
 
public class AppSwitcher
{ // Import the SetForegroundWindow function from user32.dll
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetForegroundWindow(nint hWnd);
    public static bool SwitchToApp(string appName)
    {
        var proc = Process.GetProcessesByName(appName).FirstOrDefault();
        if (proc != null)
        {
            var handle = proc.MainWindowHandle;
            SetForegroundWindow(handle);
            return true;
        }
        else
        {
            Console.WriteLine("Process with the name '{0}' not found.", appName);
            return false;
        }
    }


}
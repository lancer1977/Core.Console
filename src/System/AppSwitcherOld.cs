using System.Diagnostics;

namespace PolyhydraGames.Core.Console.System
{
    public class AppSwitcherOld  
    { // Import the SetForegroundWindow function from user32.dll

        public static bool SwitchToApp(string appName)
        {
            var proc = Process.GetProcessesByName(appName).FirstOrDefault();
            return SwitchToProcess(proc);
        }
        public static bool SwitchToProcess(Process? proc, string appName = "")
        {
            if (proc != null)
            {
                var handle = proc.MainWindowHandle;
                User32.SetForegroundWindow(handle);
                return true;
            }
            else
            {
                SharedLogger.WriteLine($"Process with the name '{appName}' not found."  );
                return false;
            }
        }

        public static async Task SwitchAllApps(string appName, int i)
        {

            var proc = Process.GetProcessesByName(appName);
            SharedLogger.WriteLine($"Found {proc.Length} items");
            foreach (var item in proc)
            {
                SwitchToProcess(item);
                SharedLogger.WriteLine(item.MainWindowTitle);

                await Task.Delay(TimeSpan.FromSeconds(i));
            }
            SharedLogger.WriteLine($"Done");
        }
    }
}
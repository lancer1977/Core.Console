using System.Diagnostics;

namespace PolyhydraGames.Core.Console.System
{
    public class AppSwitcherOld : BaseSwitcher
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
                SetForegroundWindow(handle);
                return true;
            }
            else
            {
                global::System.Console.WriteLine("Process with the name '{0}' not found.", appName);
                return false;
            }
        }

        public static async Task SwitchAllApps(string appName, int i)
        {

            var proc = Process.GetProcessesByName(appName);
            global::System.Console.WriteLine($"Found {proc.Length} items");
            foreach (var item in proc)
            {
                SwitchToProcess(item);
                global::System.Console.WriteLine(item.MainWindowTitle);

                await Task.Delay(TimeSpan.FromSeconds(i));
            }
            global::System.Console.WriteLine($"Done");
        }
    }
}
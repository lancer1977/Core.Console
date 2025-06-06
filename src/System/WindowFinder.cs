using System.Diagnostics;
using System.Text;

namespace PolyhydraGames.Core.Console.System
{
    public class WindowFinder : BaseSwitcher
    {
        private static WindowFinder? _instance;
        public static WindowFinder Instance => _instance ??= new WindowFinder();

        public List<(int PID, string Title, IntPtr Handle)> GetWindows(string appName)
        {
            var result = new List<(int PID, string Title, IntPtr Handle)>();

            EnumWindows((hWnd, lParam) =>
            {
                if (!IsWindowVisible(hWnd))
                    return true;

                GetWindowThreadProcessId(hWnd, out int pid);
                var proc = Process.GetProcessById(pid);

                if (!proc.ProcessName.Equals(appName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                var sb = new StringBuilder(1024);
                GetWindowText(hWnd, sb, sb.Capacity);
                var title = sb.ToString();

                if (!string.IsNullOrWhiteSpace(title))
                {
                    result.Add((pid, title, hWnd));
                }

                return true;
            }, IntPtr.Zero);

            return result;
        }



        public void SwitchWindows(string appName, int delaySeconds = 2)
        {
            var edgeWindows = GetWindows(appName);
            global::System.Console.WriteLine($"Found {edgeWindows.Count} Edge windows.");

            foreach (var win in edgeWindows)
            {
                WriteLine($"Bringing to front: [{win.PID}] {win.Title}");
                SetForegroundWindow(win.Handle);
                Thread.Sleep(TimeSpan.FromSeconds(delaySeconds));
            }
        }


    }
}
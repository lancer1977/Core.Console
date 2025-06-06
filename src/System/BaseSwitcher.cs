using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Extensions.Logging;

namespace PolyhydraGames.Core.Console.System
{
    public abstract class BaseSwitcher
    {
        protected delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        protected static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        protected static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        protected static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        protected static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        protected static extern bool SetForegroundWindow(IntPtr hWnd);

        //[DllImport("user32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool SetForegroundWindow(nint hWnd);
        private static ILogger? _logger;
        private static void SetLogger(ILogger logger) => _logger = logger;
        public static void WriteLine(string message)
        {
            if (_logger != null)
            {
                _logger.LogInformation(message);
            }
            else
            {
                global::System.Console.WriteLine(message);
            }
        }
    }
}
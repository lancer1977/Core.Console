using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Extensions.Logging;

namespace PolyhydraGames.Core.Console.System
{
    public static class SharedLogger
    {  
        private static ILogger? _logger;
        public static void SetLogger(ILogger logger) => _logger = logger;
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
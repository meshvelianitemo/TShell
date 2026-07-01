
using System.Diagnostics;

namespace TShell.Core
{
    public class ShellContext
    {
        public string CurrentDirectory { get; set; }
            = Environment.CurrentDirectory;
        public bool IsRunning { get; set; } = true;

        public Dictionary<string, string> EnvironmentVariables { get; set; }
            = new();
        public Process? CurrentProcess { get; set; }
    }
}

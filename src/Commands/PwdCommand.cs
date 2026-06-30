
using TShell.Core;

namespace TShell.Commands
{
    public static class PwdCommand
    {
        public static string? Main(ShellContext context)
        {
            return context.CurrentDirectory;
        }
    }
}

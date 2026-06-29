
using Microsoft.Win32.SafeHandles;
using TShell.Core;
using TShell.Models;

namespace TShell.Commands
{
    public static class CdCommand 
    {
        public static string? Main(ParsedCommand result, ShellContext context)
        {
            if (result.arguments.Count == 0)
                return null;

            string fullPath = Path.GetFullPath(
            Path.Combine(
                context.CurrentDirectory,
                result.arguments[0]));

            if (!Directory.Exists(fullPath))
                return "Couldn't find directory specified";

            context.CurrentDirectory = fullPath;
            Directory.SetCurrentDirectory(fullPath);
            return null;
        }

    }
}

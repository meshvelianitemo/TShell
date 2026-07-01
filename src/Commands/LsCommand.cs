
using TShell.Core;
using TShell.Models;

namespace TShell.Commands
{
    public static class LsCommand
    {
        public static string Main (ShellContext context, ParsedCommand command)
        {
            Directory.GetDirectories(context.CurrentDirectory);

            LsResult result = new LsResult()
            {
                
            };
            return "haha";
        }
    }
}

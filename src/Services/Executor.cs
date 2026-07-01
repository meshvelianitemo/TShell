
using TShell.Commands;
using TShell.Core;
using TShell.Models;

namespace TShell.Services
{
    public class Executor
    {
        public string? Execute(ParsedCommand result, ShellContext context)
        {
            var baseCommand = result.command;

            switch (baseCommand.ToLower())
            {
                case "exit":
                    context.IsRunning = false;
                    break;

                case "pwd":
                    return PwdCommand.Main(context);

                case "cd":
                    return CdCommand.Main(result, context);

                case "ls":
                    return LsCommand.Main(context,result);

                default:
                    return ExternalCommand.Main(result, context);
                }
            return baseCommand.ToLower();
        }


    }
}

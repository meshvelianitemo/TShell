
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
                    break;

                case "pwd":
                    break;

                case "cd":
                    return CdCommand.Main(result, context);

                default:
                        //ExecuteExternalCommand(command);
                    break;
                }
            return baseCommand.ToLower();
        }


    }
}

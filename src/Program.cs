using TShell.Core;
using TShell.Models;
using TShell.Services;

Directory.SetCurrentDirectory(@"C:\Users\");
ShellContext context = new ShellContext();
ParsedCommand parsedCommand = new ParsedCommand();
CommandParser parser = new CommandParser();
Executor executor = new Executor();
while (context.IsRunning)
{
    Console.Write($"{context.CurrentDirectory}> ");

    string? input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
        continue;
    var command = parser.ParseCommand( input );
    parsedCommand.command = command[0];
    parsedCommand.arguments = command[1..];

    Console.WriteLine( executor.Execute(parsedCommand, context));
}
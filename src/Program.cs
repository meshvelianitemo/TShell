using System.Text.Json;
using TShell.Core;
using TShell.Models;
using TShell.Services;

string json = File.ReadAllText("appSettings.json");
Config config = JsonSerializer.Deserialize<Config>(json);
Directory.SetCurrentDirectory(Environment.CurrentDirectory);
ShellContext context = new ShellContext();
ParsedCommand parsedCommand = new ParsedCommand();
CommandParser parser = new CommandParser();
Executor executor = new Executor();

Console.WriteLine(Environment.OSVersion.VersionString);
Console.WriteLine($"Custom Shell Made in C#/.NET; Version TShell [{config.Version}]");
while (context.IsRunning)
{
    Console.Write($"{Environment.MachineName}@{Environment.CurrentDirectory}> ");

    string? input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
        continue;
    var command = parser.ParseCommand( input );
    parsedCommand.command = command[0];
    parsedCommand.arguments = command[1..];

    Console.WriteLine( executor.Execute(parsedCommand, context));
}


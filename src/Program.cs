using System.Text.Json;
using TShell.Core;
using TShell.Models;
using TShell.Services;

string json = File.ReadAllText("appSettings.json");
Config config = JsonSerializer.Deserialize<Config>(json);
Directory.SetCurrentDirectory(Environment.CurrentDirectory);
ShellContext context = new ShellContext();
CommandParser parser = new CommandParser();
Executor executor = new Executor();
Console.CancelKeyPress += (sender, e) =>
{
    e.Cancel = true;

    var child = context.CurrentProcess;
    if (child != null && !child.HasExited)
        child.Kill(entireProcessTree: true);
};

Console.WriteLine(Environment.OSVersion.VersionString);
Console.WriteLine($"Custom Shell Made in C#/.NET; Version TShell [{config.Version}]");
while (context.IsRunning)
{
    Console.Write($"{Environment.MachineName}@{Environment.CurrentDirectory}> ");

    string? input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
        continue;
    var parsedCommand = parser.ParseCommand( input );
    //foreach (var c in parsedCommand.arguments)
    //{
    //    Console.WriteLine(c);
    //}
    foreach (var c in parsedCommand.parameters)
    {
        Console.WriteLine(c);
    }

    string? output = executor.Execute(parsedCommand, context);
    if (output != null)
        Console.WriteLine(output);
}


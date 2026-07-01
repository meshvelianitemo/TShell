
using System.Diagnostics;
using TShell.Core;
using TShell.Models;

namespace TShell.Commands
{
    public static class ExternalCommand
    {
        public static string? Main(ParsedCommand result, ShellContext context)
        {
            string parameters = string.Join("", result.parameters);

            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c {result.command} -{parameters}",
                WorkingDirectory = context.CurrentDirectory,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = false,
                WindowStyle = ProcessWindowStyle.Normal,
            };

            using var process = new Process { StartInfo = startInfo };

            process.OutputDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                    Console.WriteLine(e.Data);
            };
            process.ErrorDataReceived += (sender, e) =>
            {
                if (e.Data != null)
                    Console.WriteLine(e.Data);
            };

            if (!process.Start())
                return "Failed to start process";

            context.CurrentProcess = process;
            try
            {
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }
            finally
            {
                context.CurrentProcess = null;
            }

            return null;
        }
    }
}

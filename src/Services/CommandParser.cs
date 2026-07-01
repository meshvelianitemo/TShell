

using System.Text;
using TShell.Models;

namespace TShell.Services
{
    public class CommandParser
    {
        public CommandParser()
        {
        }

        public ParsedCommand ParseCommand(string command)
        {
            var tokens = Tokenize(command);

            if (tokens.Count == 0)
                return new ParsedCommand();

            var arguments = new List<string>();
            var parameters = new List<string>();

            foreach (var token in tokens[1..])
            {
                if (token.StartsWith("--") && token.Length > 2)
                {
                    parameters.Add(token[2..]);
                }
                else if (token.StartsWith('-') && token.Length > 1)
                {
                    foreach (char c in token[1..])
                        parameters.Add(c.ToString());
                }
                else
                {
                    arguments.Add(token);
                }
            }

            return new ParsedCommand
            {
                command = tokens[0],
                arguments = arguments,
                parameters = parameters
            };
        }
        private static List<string> Tokenize(string input)
        {
            var tokens = new List<string>();
            var current = new StringBuilder();
            bool started = false;
            bool inQuotes = false;
            char quoteChar = '\0';

            foreach (char c in input)
            {
                if (inQuotes)
                {
                    if (c == quoteChar)
                        inQuotes = false;
                    else
                        current.Append(c);
                }
                else if (c == '"' || c == '\'')
                {
                    inQuotes = true;
                    quoteChar = c;
                    started = true;
                }
                else if (char.IsWhiteSpace(c))
                {
                    if (started)
                    {
                        tokens.Add(current.ToString());
                        current.Clear();
                        started = false;
                    }
                }
                else
                {
                    current.Append(c);
                    started = true;
                }
            }

            if (started)
                tokens.Add(current.ToString());

            return tokens;
        }
    }
}

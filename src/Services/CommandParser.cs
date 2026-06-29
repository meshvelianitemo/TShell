

namespace TShell.Services
{
    public class CommandParser
    {
        public CommandParser()
        {
        }

        public List<string> ParseCommand(string command)
        {
            List<string> commandArr= new List<string>();
            commandArr = command.Split(
                " ",
                StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            return commandArr;

        }
    }
}

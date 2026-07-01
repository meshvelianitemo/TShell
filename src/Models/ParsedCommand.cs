

namespace TShell.Models
{
    public class ParsedCommand
    {
        public string command { get; set; } = string.Empty;
        public List<string> arguments { get; set; } = new List<string>();
        public List<string> parameters { get; set; } = new List<string>();
    }
}

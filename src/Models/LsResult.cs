
namespace TShell.Models
{
    public class LsResult
    {
        public DateOnly CreationDate { get; set; }
        public string FileType { get; set; } = string.Empty;
        public string Name { get; set; }= string.Empty;
        public string? Permissions { get; set; } 
    }
}

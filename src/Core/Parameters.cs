
namespace TShell.Core
{
    public static class Parameters
    {
        public static Dictionary<string, List<string>> commandParameters = new Dictionary<string, List<string>>
        {
            ["ls"] = { "a", "l" , "help" },
            ["pwd"] = { "help" },
            ["cd"] = { "help" },
            ["mkdir"] = { "help" },
        };
    }
}

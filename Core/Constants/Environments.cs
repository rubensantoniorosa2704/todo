public static class EnvironmentVariables
{
    public static string DBString => Environment.GetEnvironmentVariable("DBString") 
        ?? throw new InvalidOperationException("DBString environment variable is not set.");
}

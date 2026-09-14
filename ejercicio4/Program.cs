static class LogLine
{
    public static void Main()
    {
        Console.WriteLine(Message("[ERROR]: Operacion invalida"));
        Console.WriteLine(LogLevel("[ERROR]: Operacion invalida"));
        Console.WriteLine(Reformat("[INFO]: Operacion completada"));
    }
    public static string Message(string logLine)
    {
       int colonIndex = logLine.IndexOf(':');
       return logLine.Substring(colonIndex + 1).Trim();

    }

    public static string LogLevel(string logLine)
    {
       int startIndex = logLine.IndexOf('[');
       int endIndex = logLine.IndexOf(']');
       return logLine.Substring(startIndex + 1, endIndex-startIndex-1).ToLower();
    }

    public static string Reformat(string logLine)
    {
       return $"{Message(logLine)} ({LogLevel(logLine)})";
    }
}

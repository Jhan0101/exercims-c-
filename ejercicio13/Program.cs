// TODO: define the 'LogLevel' enum
using System;
using System.Reflection;
public enum LogLevel
    {
        trace,
        debug,
        info,
        warning,
        error,
        fatal,
        UNKNOWN
    }
static class LogLine
{
    
    public static LogLevel ParseLogLevel(string logLine)
    {
       string levelCode = logLine.Substring(1, 3);

       return levelCode switch
       {
           "TRC" => LogLevel.trace,
           "DBG" => LogLevel.debug,
           "INF" => LogLevel.info,
           "WRN" => LogLevel.warning,
           "ERR" => LogLevel.error,
           "FTL" => LogLevel.fatal,
           _ => LogLevel.UNKNOWN
       };
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        int code = logLevel switch
        {
           LogLevel.UNKNOWN => 0,
            LogLevel.trace => 1,
            LogLevel.debug => 2,
            LogLevel.info => 4,
            LogLevel.warning => 5,
            LogLevel.error => 6,
            LogLevel.fatal => 42,
            _ => 0
        };
        return $"{code}:{message}";
    }
}
public class Program
{
    public static void Main()
    {
        LogLevel level = LogLine.ParseLogLevel("[INF]: File delete");
        Console.WriteLine(level);

        LogLevel unknown = LogLine.ParseLogLevel("[AMS]: actualizacion");
        Console.WriteLine(unknown);

        string codigo = LogLine.OutputForShortLog(LogLevel.fatal, "stack overflow");
        Console.WriteLine(codigo);
    }
} 
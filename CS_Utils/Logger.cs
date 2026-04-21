// File-scoped namespace (Modern C# 10+ standard)
namespace CS_Utils.Logging;

/// <summary>
/// Provides static methods for standardized file-based logging across the application.
/// </summary>
public static class Logger 
{
    private static readonly string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.log"); // Log file path

    //Clear "buttons" for the dev to press
    public static void Trace(string message) => Log(message, "TRACE");
    public static void Debug(string message) => Log(message, "DEBUG");
    public static void Info(string message) => Log(message, "INFO");
    public static void Warning(string message) => Log(message, "WARNING");
    public static void Error(string message) => Log(message, "ERROR");
    public static void Fatal(string message) => Log(message, "FATAL");

    /// <summary>
    /// Formats and appends a message to the log file with a timestamp and severity level.
    /// </summary>
    /// <param name="message">The message content to record.</param>
    /// <param name="level">The severity level (e.g., TRACE, INFO, FATAL).</param>
    private static void Log(string message, string level)
    {
        try
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level.PadRight(7)}] {message}";
            File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[LOGGER ERROR] {DateTime.Now}: {ex.Message}");
        }
    }
}
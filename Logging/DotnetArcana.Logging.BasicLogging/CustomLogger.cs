using Microsoft.Extensions.Logging;

namespace AspNetArcana.Logging.BasicLogging;

public class CustomLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName) => new CustomLogger();

    public void Dispose() {}
}

public class CustomLogger : ILogger
{
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        => NullScope.Insatance;

    public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
            return;

        Console.WriteLine($"[{logLevel}({eventId})]: {state}");
    }
}

internal sealed class NullScope : IDisposable
{
    public static NullScope Insatance { get; } = new();

    private NullScope() {}

    public void Dispose() {}
}

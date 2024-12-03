using AspNetArcana.Logging.BasicLogging;
using DotnetArcana.Logging.BasicLogging;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddJsonConsole((x) =>
    {
        x.JsonWriterOptions = new System.Text.Json.JsonWriterOptions
        {
            Indented = true
        };
    });
    builder.AddProvider(new CustomLoggerProvider());
});

ILogger logger = loggerFactory.CreateLogger<Program>();

var name = "Adam";
var age = 32;

logger.LogInformation("{Name} just turned {Age}", name, age);

using (logger.BeginTimedOperation("Handle processing {name}", name))
{
    logger.LogInformation("{Name} just turned {Age}", name, age);

    await Task.Delay(10);
}
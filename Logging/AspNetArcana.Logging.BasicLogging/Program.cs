using AspNetArcana.Logging.BasicLogging;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddJsonConsole();
    builder.AddProvider(new CustomLoggerProvider());
});

ILogger logger = loggerFactory.CreateLogger<Program>();

var name = "Adam";
var age = 32;

logger.LogInformation("{Name} just turned {Age}", name, age);
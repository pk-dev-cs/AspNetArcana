Install Required Packages

To begin, you'll need to install the following packages:

```bash
dotnet add package OpenTelemetry.Extensions.Hosting
dotnet add package OpenTelemetry.Instrumentation.AspNetCore
dotnet add package OpenTelemetry.Instrumentation.Http
dotnet add package OpenTelemetry.Exporter.Console
dotnet add package OpenTelemetry.Exporter.OpenTelemetryProtocol
```

Setting Up Instrumentation in Program.cs

You can configure OpenTelemetry instrumentation in your Program.cs file. For example, to add an additional tag for tracing, you can use the following code snippet:

```csharp
Activity.Current?.SetTag("client.id", 69);
```

To add more tags for tracing, simply repeat the SetTag method like this:

```csharp
Activity.Current?.SetTag("client.id", 69);
Activity.Current?.SetTag("custom.tag", "your_value");
```

Make sure you have the correct setup in Program.cs to initialize OpenTelemetry tracing.
﻿using System.Diagnostics.Metrics;

namespace AspNetArcana.OpenTelemetry.SimpleMetrics.Diagnostics;

public class ApplicationDiagnostics
{
    private const string ServiceName = "AspNetArcana.OpenTelemetry.SimpleMetrics";
    public static readonly Meter Meter = new Meter(ServiceName);

    public static Counter<long> ClientsCreatedCounter = Meter.CreateCounter<long>("clients.created");
}

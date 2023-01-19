namespace TrueWind.Smhi.ResourceModels;

internal sealed record SmhiPointRequest(
    DateTime ApprovedTime,
    DateTime ReferenceTime,
    Geometry Geometry,
    TimeSerie[] TimeSeries
    );

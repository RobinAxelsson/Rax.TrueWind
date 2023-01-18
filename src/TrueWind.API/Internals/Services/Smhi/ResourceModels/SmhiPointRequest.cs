namespace TrueWind.API.Internals.Services.Smhi.ResourceModels;

internal sealed record SmhiPointRequest(
    string ApprovedTime,
    string ReferenceTime,
    Geometry Geometry,
    TimeSerie[] TimeSeries
    );

namespace TrueWind.API.Internals.Services.Smhi.ResourceModels;

internal sealed record TimeSerie(
    DateTime ValidTime,
    Parameter[] Parameters
    );

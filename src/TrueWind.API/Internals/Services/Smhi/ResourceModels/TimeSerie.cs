namespace TrueWind.API.Internals.Services.Smhi.ResourceModels;

internal sealed record TimeSerie(
    string ValidTime,
    Parameter[] Parameters
    );

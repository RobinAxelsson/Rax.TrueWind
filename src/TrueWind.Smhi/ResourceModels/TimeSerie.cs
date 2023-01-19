namespace TrueWind.Smhi.ResourceModels;

internal sealed record TimeSerie(
    DateTime ValidTime,
    Parameter[] Parameters
    );

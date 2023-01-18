namespace TrueWind.API.Internals.Services.Smhi.ResourceModels;

internal sealed record Geometry
(
    string Type,
    float[][] Coordinates
);

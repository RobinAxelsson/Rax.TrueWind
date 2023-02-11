namespace TrueWind.ViVa.ResourceModels;

internal record GetSingleStationResult
(
    int ID,
    string Name,
    Sample[] Samples,
    string Felmeddelande
);
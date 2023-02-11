namespace TrueWind.ViVa.ResourceModels;

internal record Sample
(
    string Name,
    string Value,
    int Heading,
    string Unit,
    string Type,
    string Trend,
    string Msg,
    int Calm,
    string Updated,
    int StationID,
    string Quality,
    string WaterLevelReference,
    double WaterLevelOffset
);
﻿namespace TrueWind.Smhi.ResourceModels;

internal sealed record Parameter(
    string Name,
    string LevelType,
    int Level,
    string unit,
    float[] Values);

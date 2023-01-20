namespace TrueWind.Core.ValueObjects
{
    public sealed record GeoPoint
    {
        public float Latitude { get; }
        public float Longitude { get; }
        public GeoPoint(float latitude, float longitude)
        {
            //TODO: geographical validation, rounding
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}

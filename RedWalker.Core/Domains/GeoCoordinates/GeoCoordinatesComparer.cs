using System;

namespace RedWalker.Core.Domains.GeoCoordinates;

public class GeoCoordinatesComparer : IGeoCoordinatesComparer
{
    const double k = 111;

    public bool EnteringAreaByKilometer(GeoCoordinate coordinate1, GeoCoordinate coordinate2, double radiusKm)
    {
        double distanceKm = Math.Sqrt(Math.Pow(coordinate1.Lat - coordinate2.Lat, 2) +
                                    Math.Pow(coordinate1.Lon - coordinate2.Lon, 2)) * k;
        return distanceKm <= radiusKm;
    }
}
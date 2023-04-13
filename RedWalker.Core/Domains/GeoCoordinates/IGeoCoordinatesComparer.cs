namespace RedWalker.Core.Domains.GeoCoordinates;

public interface IGeoCoordinatesComparer
{
    public bool EnteringAreaByKilometer(GeoCoordinate coordinate1, GeoCoordinate coordinate2, double radius);
}
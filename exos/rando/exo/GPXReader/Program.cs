using Aspose.Gis;
using Aspose.Gis.Geometries;
namespace GPXReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var layer = Drivers.Gpx.OpenLayer("../../../../../gpx/Running.gpx"))
            {
                foreach (var feature in layer)
                {
                    switch (feature.Geometry.GeometryType)
                    {
                        // GPX waypoints are exported as features with point geometry.
                        case GeometryType.Point:


                            Console.WriteLine(feature.Geometry.Dimension);
                            //HandleGpxWaypoint(feature);
                            break;

                        // GPX routes are exported as features with line string geometry.
                        case GeometryType.LineString:

                            //HandleGpxRoute(feature);
                            LineString ls = (LineString)feature.Geometry;

                            foreach (var point in ls)
                            {
                                Console.WriteLine(point.AsText());
                                Console.WriteLine();
                                Console.WriteLine(point.X);
                                Console.WriteLine();
                            }
                            break;

                        // GPX tracks are exported as features with multi line string geometry.
                        // Every track segment is line string.
                        case GeometryType.MultiLineString:

                            //HandleGpxTrack(feature);
                            Console.WriteLine("de");
                            Console.WriteLine(feature.Geometry.AsText());
                            Console.WriteLine();
                            Console.WriteLine(feature.Geometry);
                            break;
                        default: break;
                    }
                }
            }
        }
    }
}

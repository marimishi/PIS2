using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;

namespace PIS
{
    public class Map : IEnumerable
    {
        public List<MapPoint> MapPoints;

        public Map()
        {
            MapPoints = new List<MapPoint>();
        }

        public void AddPoint(MapPoint point)
        {
            MapPoints.Add(point);
        }

        public IEnumerator<MapPoint> GetEnumerator()
        {
            return MapPoints.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformUtility
{
    /// <summary>
    /// GeometryPolygon
    /// </summary>
    public class GeometryPolygon : Geometry
    {
        public override DrawingCanavsGeometries Type => DrawingCanavsGeometries.Polygon;

        /// <summary>
        /// 多边形顶点集合
        /// </summary>
        public List<Point> Vertexs { get; private set; }

        public GeometryPolygon(IEnumerable<Point> vertexs)
        {
            this.Vertexs = new List<Point>(vertexs);
        }
    }
}
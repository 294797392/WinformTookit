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

        private PointF[] points;

        internal PointF[] Points
        {
            get
            {
                if (this.points == null)
                {
                    this.points = this.Vertexs.ToArray();
                }
                return this.points;
            }
        }

        /// <summary>
        /// 多边形顶点集合
        /// </summary>
        public List<PointF> Vertexs { get; private set; }

        public GeometryPolygon(IEnumerable<PointF> vertexs)
        {
            this.Vertexs = new List<PointF>(vertexs);
        }
    }
}
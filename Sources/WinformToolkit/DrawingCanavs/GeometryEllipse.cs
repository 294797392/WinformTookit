using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformUtility
{
    /// <summary>
    /// 椭圆形
    /// </summary>
    public class GeometryEllipse : GeometryRectangle
    {
        public override DrawingCanavsGeometries Type => DrawingCanavsGeometries.Ellipse;
    }
}
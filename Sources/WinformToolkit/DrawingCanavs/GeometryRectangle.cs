using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformUtility
{
    /// <summary>
    /// DrawingCanvasGeometryRectangle类
    /// </summary>
    public class GeometryRectangle : Geometry
    {
        public override DrawingCanavsGeometries Type => DrawingCanavsGeometries.Rectangle;

        /// <summary>
        /// 矩形的宽度
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// 矩形的高度
        /// </summary>
        public float Height { get; set; }

        public RectangleF RectangleF()
        {
            return new RectangleF(this.OffsetX, this.OffsetY, this.Width, this.Height);
        }

        public static GeometryRectangle FromRectangle(Rectangle rectangle)
        {
            return new GeometryRectangle()
            {
                Height = rectangle.Height,
                Width = rectangle.Width,
                OffsetX = rectangle.X,
                OffsetY = rectangle.Y
            };
        }
    }
}
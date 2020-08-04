using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformUtility
{
    /// <summary>
    /// 对画笔等进行一些配置
    /// </summary>
    public abstract class DrawingOptions
    {
        /// <summary>
        /// 多边形的边框颜色
        /// </summary>
        public Color PolygonBroderColor { get; set; }

        /// <summary>
        /// 多边形边框宽度
        /// </summary>
        public int PolygonBorderWidth { get; set; }

        /// <summary>
        /// 多边形背景颜色
        /// </summary>
        public Color PolygonBackgroundColor { get; set; }
    }

    public class DrawingOptionsGDI : DrawingOptions
    {
        private Pen polygonBorderPen;
        private Brush polygonBackgroundBrush;


        public Pen PolygonBorderPen
        {
            get
            {
                if (this.polygonBorderPen == null)
                {
                    this.polygonBorderPen = new Pen(base.PolygonBroderColor, base.PolygonBorderWidth);
                }
                return this.polygonBorderPen;
            }
        }

        public Brush PolygonBackgroundBrush
        {
            get
            {
                if (this.polygonBackgroundBrush == null)
                {
                    this.polygonBackgroundBrush = new SolidBrush(base.PolygonBackgroundColor);
                }
                return this.polygonBackgroundBrush;
            }
        }
    }
}
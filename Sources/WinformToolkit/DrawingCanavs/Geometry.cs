using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformUtility
{
    /// <summary>
    /// 图形类型枚举
    /// </summary>
    public enum DrawingCanavsGeometries
    {
        /// <summary>
        /// 矩形
        /// </summary>
        Rectangle,

        /// <summary>
        /// 多边形
        /// </summary>
        Polygon,

        /// <summary>
        /// 椭圆形
        /// </summary>
        Ellipse
    }

    /// <summary>
    /// 图形抽象类
    /// </summary>
    public abstract class Geometry
    {
        /// <summary>
        /// 图形类型
        /// </summary>
        public abstract DrawingCanavsGeometries Type { get; }

        /// <summary>
        /// 距离左上角的偏移X
        /// </summary>
        public float OffsetX { get; set; }

        /// <summary>
        /// 距离左上角的偏移Y
        /// </summary>
        public float OffsetY { get; set; }
    }
}
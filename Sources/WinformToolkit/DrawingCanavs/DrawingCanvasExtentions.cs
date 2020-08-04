using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformUtility
{
    /// <summary>
    /// DrawingCanvasExtentions类
    /// </summary>
    public static class DrawingCanvasExtentions
    {
        /// <summary>
        /// 根据P1的坐标和P2的坐标生成一个矩形
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Rectangle MakeRectangle(this Point p1, Point p2)
        {
            return new Rectangle(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y), Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));
        }
    }
}
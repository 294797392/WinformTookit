using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformUtility
{
    /// <summary>
    /// GeometryLayer类
    /// 功能：
    /// 1. 画图形
    /// 2. 存储Layer里的所有图形
    /// </summary>
    public class GeometryLayer : UserControl
    {
        protected DrawingOptionsGDI drawingOptions;

        #region 属性

        /// <summary>
        /// 画图配置
        /// </summary>
        public DrawingOptions Options { get; set; }

        /// <summary>
        /// 所有的图形集合
        /// </summary>
        protected ObservableCollection<Geometry> Geometries { get; private set; }

        #endregion

        #region 构造方法

        public GeometryLayer()
        {
            this.Geometries = new ObservableCollection<Geometry>();

            this.Dock = DockStyle.Fill;

            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.UpdateStyles();
        }

        #endregion

        #region 实例方法

        #region 绘图函数

        private void DrawRectangle(Graphics g, GeometryRectangle rectangle)
        {
            g.FillRectangle(this.drawingOptions.PolygonBackgroundBrush, rectangle.OffsetX, rectangle.OffsetY, rectangle.Width, rectangle.Height);
            g.DrawRectangle(this.drawingOptions.PolygonBorderPen, rectangle.OffsetX, rectangle.OffsetY, rectangle.Width, rectangle.Height);
        }

        private void DrawPolygon(Graphics g, GeometryPolygon polygon)
        {
            g.FillPolygon(this.drawingOptions.PolygonBackgroundBrush, polygon.Points);
            g.DrawPolygon(this.drawingOptions.PolygonBorderPen, polygon.Points);
        }

        private void DrawEllipse(Graphics g, GeometryEllipse ellipse)
        {
            g.FillEllipse(this.drawingOptions.PolygonBackgroundBrush, ellipse.OffsetX, ellipse.OffsetY, ellipse.Width, ellipse.Height);
            g.DrawEllipse(this.drawingOptions.PolygonBorderPen, ellipse.OffsetX, ellipse.OffsetY, ellipse.Width, ellipse.Height);
        }

        #endregion

        #endregion

        #region 公开接口

        public void AddGeometry(Geometry geometry)
        {
            this.Geometries.Add(geometry);
            this.Invalidate();
        }

        #endregion

        #region 事件处理器

        /// <summary>
        /// 重绘事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(System.Drawing.Color.MistyRose);

            if (this.drawingOptions == null)
            {
                this.drawingOptions = this.Options as DrawingOptionsGDI;
            }

            if (this.Geometries == null || this.Geometries.Count == 0)
            {
                return;
            }

            Graphics g = e.Graphics;

            foreach (Geometry geometry in this.Geometries)
            {
                switch (geometry.Type)
                {
                    case DrawingCanavsGeometries.Rectangle:
                        {
                            this.DrawRectangle(g, geometry as GeometryRectangle);
                            break;
                        }

                    case DrawingCanavsGeometries.Polygon:
                        {
                            this.DrawPolygon(g, geometry as GeometryPolygon);
                            break;
                        }

                    case DrawingCanavsGeometries.Ellipse:
                        {
                            this.DrawEllipse(g, geometry as GeometryEllipse);
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            }
        }

        #endregion
    }
}
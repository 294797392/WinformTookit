using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformUtility
{
    /// <summary>
    /// 实时画图形用的类
    /// </summary>
    internal class DrawingLayer : GeometryLayer
    {
        #region 常亮

        /// <summary>
        /// 最大放大倍数
        /// </summary>
        private const float MAXIMUM_SCALING = 100F;

        /// <summary>
        /// 最大缩小倍数
        /// </summary>
        private const float MINIMUM_SCALING = 0.5F;

        /// <summary>
        /// 每次缩放的比例
        /// </summary>
        private const float ScaleFactor = 0.5F;

        #endregion

        #region 公开事件

        /// <summary>
        /// 画图结束触发
        /// </summary>
        public event Action<Geometry> DrawCompleted;

        #endregion

        #region 实例变量

        /// <summary>
        /// 所有的链接点集合
        /// </summary>
        private List<ConnectionPoint> connectionPoints;

        /// <summary>
        /// 鼠标起始坐标
        /// </summary>
        private Point startMousePosition;

        /// <summary>
        /// 鼠标当前坐标
        /// </summary>
        private Point currentMousePosition;

        /// <summary>
        /// 当前是否正在画图
        /// </summary>
        private bool isDrawing;

        /// <summary>
        /// 多边形的点
        /// </summary>
        private List<Point> polygonPoints;

        /// <summary>
        /// 每个元素的偏移量
        /// </summary>
        private float geometryOffsetX = 0F;

        /// <summary>
        /// 每个元素的偏移量
        /// </summary>
        private float geometryOffsetY = 0F;

        /// <summary>
        /// 当前缩放倍数
        /// </summary>
        private float currentZoomFactor = 1;

        #endregion

        #region 属性

        /// <summary>
        /// 当前绘画类型
        /// </summary>
        internal DrawingCanavsGeometries DrawingType { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 构造方法
        /// </summary>
        public DrawingLayer()
        {
            this.connectionPoints = new List<ConnectionPoint>();
            this.isDrawing = false;
            this.polygonPoints = new List<Point>();
        }

        #endregion

        #region 实例方法

        private void NotifyDrawCompleted(Geometry geometry)
        {
            if (this.DrawCompleted != null)
            {
                this.DrawCompleted(geometry);
            }
        }

        #endregion

        #region 重写事件

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            //if (e.Delta > 0)
            //{
            //    // 放大
            //    if (this.currentZoomFactor >= MAXIMUM_SCALING)
            //    {
            //        return;
            //    }

            //    this.currentZoomFactor += ScaleFactor;
            //}
            //else
            //{
            //    // 缩小
            //    if (this.currentZoomFactor <= MINIMUM_SCALING)
            //    {
            //        return;
            //    }

            //    this.currentZoomFactor -= ScaleFactor;
            //}

            //// 鼠标坐标作为缩放中心点
            //Point mousePosition = e.Location;

            //// 获取鼠标所在图片的X轴的比例
            //float scaleX = (mousePosition.X / this.Width);

            //// 获取鼠标所在图片的Y轴的比例
            //float scaleY = (mousePosition.Y / this.Height);

            //// 缩小后的图片的大小
            //float sizeX = this.Width * this.currentZoomFactor;

            //// 计算缩小后鼠标所在图片的X轴的位置
            //float offsetX = sizeX * scaleX;

            //// 缩小后的图片的大小
            //float sizeY = this.Height * this.currentZoomFactor;

            //// 计算缩小后鼠标所在图片的Y轴的位置
            //float offsetY = sizeY * scaleY;

            //this.geometryOffsetX = -(offsetX - mousePosition.X);

            //this.geometryOffsetY = -(offsetY - mousePosition.Y);

            //// 重绘
            //this.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (!this.isDrawing)
            {
                return;
            }

            this.currentMousePosition = e.Location;

            switch (this.DrawingType)
            {
                case DrawingCanavsGeometries.Ellipse:
                case DrawingCanavsGeometries.Rectangle:
                    {
                        break;
                    }

                case DrawingCanavsGeometries.Polygon:
                    {
                        if (this.polygonPoints.Count > 1)
                        {
                            this.polygonPoints.RemoveAt(this.polygonPoints.Count - 1);
                            this.polygonPoints.Add(e.Location);
                            this.Invalidate();
                        }
                        break;
                    }
            }

            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            this.startMousePosition = e.Location;

            this.isDrawing = true;

            switch (this.DrawingType)
            {
                case DrawingCanavsGeometries.Ellipse:
                case DrawingCanavsGeometries.Rectangle:
                    {
                        break;
                    }

                case DrawingCanavsGeometries.Polygon:
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            this.polygonPoints.Add(e.Location);
                            if (this.polygonPoints.Count == 1)
                            {
                                this.polygonPoints.Add(e.Location);
                            }
                            this.Invalidate();
                        }
                        else
                        {
                            this.isDrawing = false;
                            this.polygonPoints.Clear();
                        }
                        break;
                    }

                default:
                    break;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            switch (this.DrawingType)
            {
                case DrawingCanavsGeometries.Ellipse:
                    {
                        this.isDrawing = false;
                        Rectangle r = this.startMousePosition.MakeRectangle(this.currentMousePosition);
                        this.NotifyDrawCompleted(GeometryEllipse.FromRectangle(r));
                        break;
                    }

                case DrawingCanavsGeometries.Rectangle:
                    {
                        this.isDrawing = false;
                        Rectangle r = this.startMousePosition.MakeRectangle(this.currentMousePosition);
                        this.NotifyDrawCompleted(GeometryRectangle.FromRectangle(r));
                        break;
                    }

                case DrawingCanavsGeometries.Polygon:
                    {
                        break;
                    }

                default:
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!this.isDrawing)
            {
                return;
            }

            Graphics g = e.Graphics;

            switch (this.DrawingType)
            {
                case DrawingCanavsGeometries.Rectangle:
                    {
                        Rectangle r = this.startMousePosition.MakeRectangle(this.currentMousePosition);
                        g.FillRectangle(this.drawingOptions.PolygonBackgroundBrush, r);
                        g.DrawRectangle(this.drawingOptions.PolygonBorderPen, r);
                        break;
                    }

                case DrawingCanavsGeometries.Polygon:
                    {
                        if (this.polygonPoints.Count <= 1)
                        {
                            return;
                        }

                        Point[] points = this.polygonPoints.ToArray();
                        g.FillPolygon(this.drawingOptions.PolygonBackgroundBrush, points, System.Drawing.Drawing2D.FillMode.Alternate);
                        g.DrawPolygon(this.drawingOptions.PolygonBorderPen, points);
                        break;
                    }

                case DrawingCanavsGeometries.Ellipse:
                    {
                        Rectangle r = this.startMousePosition.MakeRectangle(this.currentMousePosition);
                        g.FillEllipse(this.drawingOptions.PolygonBackgroundBrush, r);
                        g.DrawEllipse(this.drawingOptions.PolygonBorderPen, r);
                        break;
                    }

                default:
                    break;
            }
        }

        #endregion
    }
}

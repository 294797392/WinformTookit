using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace WinformUtility
{
    public partial class DarwingCanvasGDI : UserControl
    {
        #region 实例变量

        /// <summary>
        /// 所有图层
        /// </summary>
        private ObservableCollection<GeometryLayer> layers;

        /// <summary>
        /// 当前选中的图层
        /// </summary>
        private GeometryLayer selectedLayer;

        /// <summary>
        /// 画图图层
        /// </summary>
        private DrawingLayer drawingLayer;

        private bool enableDrawing;

        #endregion

        #region 属性

        /// <summary>
        /// 是否启用画图
        /// </summary>
        public bool EnableDrawing
        {
            get
            {
                return this.enableDrawing;
            }
            set
            {
                this.enableDrawing = value;
                this.drawingLayer.Visible = value;
                this.drawingLayer.DrawingType = this.DrawingType;
            }
        }

        /// <summary>
        /// 当前绘画类型
        /// </summary>
        public DrawingCanavsGeometries DrawingType { get; set; }

        /// <summary>
        /// 画图配置
        /// </summary>
        public DrawingOptions Options { get; set; }

        /// <summary>
        /// 所有图层
        /// </summary>
        public ObservableCollection<GeometryLayer> Layers { get { return this.layers; } }

        #endregion

        #region 构造方法

        public DarwingCanvasGDI()
        {
            InitializeComponent();

            this.InitializeUserControl();
        }

        #endregion

        #region 实例方法

        private void InitializeUserControl()
        {
            this.Options = new DrawingOptionsGDI()
            {
                PolygonBackgroundColor = Color.Orange,
                PolygonBroderColor = Color.Green,
                PolygonBorderWidth = 3
            };

            // 所有图层
            this.layers = new ObservableCollection<GeometryLayer>();

            // 初始化图层
            this.selectedLayer = this.AddGeometryLayer();

            // 用来画图的Panel
            this.InitializeDrawingLayer();
        }

        #endregion

        #region 重写事件

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(System.Drawing.Color.Transparent);
        }

        #endregion

        #region 事件处理器

        /// <summary>
        /// 画图完成事件
        /// </summary>
        /// <param name="geometry">画上去的图形</param>
        private void DrawingLayer_DrawCompleted(Geometry geometry)
        {
            this.drawingLayer.Visible = false;
            this.drawingLayer.DrawingType = DrawingCanavsGeometries.None;

            if (this.selectedLayer == null)
            {
                this.selectedLayer = this.layers.FirstOrDefault();
            }

            this.selectedLayer.AddGeometry(geometry);
        }

        #endregion

        #region 实例方法

        /// <summary>
        /// 创建一个空的图层并返回
        /// </summary>
        /// <returns></returns>
        private GeometryLayer AddGeometryLayer()
        {
            GeometryLayer layer = new GeometryLayer()
            {
                Options = this.Options,
            };

            this.Controls.Add(layer);
            this.layers.Add(layer);
            layer.Dock = DockStyle.Fill;

            return layer;
        }

        private void InitializeDrawingLayer()
        {
            this.drawingLayer = new DrawingLayer();
            this.drawingLayer.BackColor = System.Drawing.Color.Transparent;
            // 默认状态下隐藏，EnableDrawing设置成True的时候再显示
            this.drawingLayer.Visible = false;
            this.drawingLayer.Options = this.Options;
            this.drawingLayer.DrawCompleted += this.DrawingLayer_DrawCompleted;
            this.Controls.Add(this.drawingLayer);
            this.Controls.SetChildIndex(this.drawingLayer, 0);
        }

        #endregion
    }
}
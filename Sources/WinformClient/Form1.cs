using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformUtility;

namespace WinformClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonAddRectangle_Click(object sender, EventArgs e)
        {
            GeometryRectangle rectangle = new GeometryRectangle()
            {
                OffsetX = 50,
                OffsetY = 50,
                Height = 300,
                Width = 200
            };
            DrawingCanvasGDI.Layers[0].AddGeometry(rectangle);
        }

        private void ButtonEnableDraw_Click(object sender, EventArgs e)
        {
            DrawingCanvasGDI.DrawingType = DrawingCanavsGeometries.Rectangle;
            DrawingCanvasGDI.EnableDrawing = true;
        }

        private void ButtonDrawEllipse_Click(object sender, EventArgs e)
        {
            DrawingCanvasGDI.DrawingType = DrawingCanavsGeometries.Ellipse;
            DrawingCanvasGDI.EnableDrawing = true;
        }

        private void ButtonDrawPolygon_Click(object sender, EventArgs e)
        {
            DrawingCanvasGDI.DrawingType = DrawingCanavsGeometries.Polygon;
            DrawingCanvasGDI.EnableDrawing = true;
        }
    }
}

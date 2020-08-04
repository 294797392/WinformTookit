namespace WinformClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            WinformUtility.DrawingOptionsGDI drawingOptionsGDI5 = new WinformUtility.DrawingOptionsGDI();
            this.ButtonAddRectangle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButtonEnableDraw = new System.Windows.Forms.Button();
            this.DrawingCanvasGDI = new WinformUtility.DarwingCanvasGDI();
            this.ButtonDrawEllipse = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonAddRectangle
            // 
            this.ButtonAddRectangle.Location = new System.Drawing.Point(12, 20);
            this.ButtonAddRectangle.Name = "ButtonAddRectangle";
            this.ButtonAddRectangle.Size = new System.Drawing.Size(75, 23);
            this.ButtonAddRectangle.TabIndex = 1;
            this.ButtonAddRectangle.Text = "添加矩形";
            this.ButtonAddRectangle.UseVisualStyleBackColor = true;
            this.ButtonAddRectangle.Click += new System.EventHandler(this.ButtonAddRectangle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ButtonDrawEllipse);
            this.groupBox1.Controls.Add(this.ButtonEnableDraw);
            this.groupBox1.Controls.Add(this.ButtonAddRectangle);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(791, 74);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // ButtonEnableDraw
            // 
            this.ButtonEnableDraw.Location = new System.Drawing.Point(94, 19);
            this.ButtonEnableDraw.Name = "ButtonEnableDraw";
            this.ButtonEnableDraw.Size = new System.Drawing.Size(75, 23);
            this.ButtonEnableDraw.TabIndex = 2;
            this.ButtonEnableDraw.Text = "画矩形";
            this.ButtonEnableDraw.UseVisualStyleBackColor = true;
            this.ButtonEnableDraw.Click += new System.EventHandler(this.ButtonEnableDraw_Click);
            // 
            // DrawingCanvasGDI
            // 
            this.DrawingCanvasGDI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawingCanvasGDI.BackColor = System.Drawing.Color.Transparent;
            this.DrawingCanvasGDI.DrawingType = WinformUtility.DrawingCanavsGeometries.Rectangle;
            this.DrawingCanvasGDI.EnableDrawing = false;
            this.DrawingCanvasGDI.Location = new System.Drawing.Point(0, 92);
            this.DrawingCanvasGDI.Name = "DrawingCanvasGDI";
            drawingOptionsGDI5.PolygonBackgroundColor = System.Drawing.Color.Black;
            drawingOptionsGDI5.PolygonBorderWidth = 2;
            drawingOptionsGDI5.PolygonBroderColor = System.Drawing.Color.Green;
            this.DrawingCanvasGDI.Options = drawingOptionsGDI5;
            this.DrawingCanvasGDI.Size = new System.Drawing.Size(800, 358);
            this.DrawingCanvasGDI.TabIndex = 0;
            // 
            // ButtonDrawEllipse
            // 
            this.ButtonDrawEllipse.Location = new System.Drawing.Point(175, 20);
            this.ButtonDrawEllipse.Name = "ButtonDrawEllipse";
            this.ButtonDrawEllipse.Size = new System.Drawing.Size(75, 23);
            this.ButtonDrawEllipse.TabIndex = 3;
            this.ButtonDrawEllipse.Text = "画椭圆形";
            this.ButtonDrawEllipse.UseVisualStyleBackColor = true;
            this.ButtonDrawEllipse.Click += new System.EventHandler(this.ButtonDrawEllipse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DrawingCanvasGDI);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WinformUtility.DarwingCanvasGDI DrawingCanvasGDI;
        private System.Windows.Forms.Button ButtonAddRectangle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButtonEnableDraw;
        private System.Windows.Forms.Button ButtonDrawEllipse;
    }
}


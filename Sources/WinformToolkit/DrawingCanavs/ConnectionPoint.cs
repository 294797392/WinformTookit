using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformUtility
{
    /// <summary>
    /// 连接点控件
    /// </summary>
    public partial class ConnectionPoint : UserControl, IInputGeometry
    {
        public ConnectionPoint()
        {
            InitializeComponent();
        }
    }
}

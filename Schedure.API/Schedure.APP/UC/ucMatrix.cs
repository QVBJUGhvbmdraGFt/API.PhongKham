using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedure.APP.UC
{
    public partial class ucMatrix : UserControl
    {
        public ucMatrix()
        {
            InitializeComponent();
        }

        public int LabelWidth { get; set; }

        public class RowMatrix : UserControl
        {
            ucMatrix parent;

            public RowMatrix(ucMatrix parent)
            {
                this.parent = parent;
                Height = 50;
                Dock = DockStyle.Top;
                Label = new Label();
                var panel = new Panel { Dock = DockStyle.Left , Width = parent.LabelWidth };
                panel.Controls.Add(Label);
                this.Controls.Add(panel);
            }
            public Label Label { get; set; }


        }
    }
}

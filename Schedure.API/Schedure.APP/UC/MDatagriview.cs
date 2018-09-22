using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedure.APP.UC
{
    [DefaultEvent("MyCellClick")]
    public class MDataGridView : DataGridViewX
    {
        public MDataGridView()
        {
            AutoGenerateColumns = false;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            BackgroundColor = SystemColors.Control;
            RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CellFormatting += MDataGridView_CellFormatting;
            InitializeComponent();
        }

        private void MDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < _columnFormat.Count)
            {
                var obj = this.Rows[e.RowIndex].DataBoundItem;
                if (obj != null)
                {
                    e.Value = _columnFormat[e.ColumnIndex].Invoke(obj);
                }
            }
        }

        List<Func<object, object>> _columnFormat = new List<Func<object, object>>();

        public void BinDataPropertyName<T>(params ColumnFormat<T>[] columnFormat) where T : class
        {
            int min = Math.Min(columnFormat.Length, this.ColumnCount);
            _columnFormat.Clear();
            for (int i = 0; i < min; i++)
            {
                if (columnFormat[i] != null)
                {
                    var col = this.Columns[i];
                    //col.DataPropertyName = columnFormat[i].DataPropertyName == null ? null : columnFormat[i].DataPropertyName.GetPropertyName();
                    col.DefaultCellStyle.Format = columnFormat[i].Format;
                    col.DefaultCellStyle.BackColor = columnFormat[i].BackColor;
                    col.DefaultCellStyle.Alignment = columnFormat[i].Alignment;
                    col.AutoSizeMode = columnFormat[i].AutoSizeMode;

                    var func = columnFormat[i].DataPropertyName.Compile();
                    _columnFormat.Add(x =>
                    {
                        return func.Invoke(x as T);
                    });
                }
            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // MDataGridView
            // 
            this.BackgroundColor = System.Drawing.SystemColors.Control;
            this.RowTemplate.Height = 24;
            this.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MDataGridView_CellClick);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void MDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MyCellClick != null && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var DataBoundItem = this.Rows[e.RowIndex].DataBoundItem;
                if (DataBoundItem != null)
                {
                    MyCellClick.Invoke(sender, e, DataBoundItem);
                }
            }
        }

        public delegate void Mdata(object sender, DataGridViewCellEventArgs e, object dataBoundItem);
        public event Mdata MyCellClick;
    }
}

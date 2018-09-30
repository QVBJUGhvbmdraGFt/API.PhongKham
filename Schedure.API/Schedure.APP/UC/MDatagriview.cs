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
        public bool IsCellFormatting { get; set; }

        public MDataGridView()
        {
            AutoGenerateColumns = false;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            BackgroundColor = SystemColors.Control;
            RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            IsCellFormatting = true;

            CellFormatting += MDataGridView_CellFormatting;
            InitializeComponent();
        }

        private void MDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (IsCellFormatting)
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

                    col.DefaultCellStyle.Format = columnFormat[i].Format;
                    col.DefaultCellStyle.BackColor = columnFormat[i].BackColor;
                    col.DefaultCellStyle.Alignment = columnFormat[i].Alignment;
                    col.AutoSizeMode = columnFormat[i].AutoSizeMode;

                    if (IsCellFormatting)
                    {
                        var express = columnFormat[i].DataPropertyName;
                        var func = express.Compile();
                        _columnFormat.Add(x =>
                        {
                            try
                            {
                                return func.Invoke(x as T);
                            }
                            catch (NullReferenceException ex)
                            {
                                ex.DebugLog($"({express}) {ex.TryGetMessage()}.");
                            }
                            return "";
                        });
                    }
                    else
                    {
                        col.DataPropertyName = columnFormat[i].DataPropertyName == null ? null : columnFormat[i].DataPropertyName.GetPropertyName();
                    }
                }
            }
        }

        public void SetDataSource<T>(IList<T> data)
        {
            if (IsCellFormatting)
            {
                DataSource = data;
            }
            else
            {
                DataSource = new BindingList<T>(data);
            }
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // MDataGridView
            // 
            this.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
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

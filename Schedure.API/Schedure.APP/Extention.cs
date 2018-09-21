using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedure.APP
{
    public static class Extentionsxxx
    {
        public static string GetPropertyName<T, Y>(this Expression<Func<T, Y>> expression)
        {
            if (expression.Body is MemberExpression)
            {
                var member = (MemberExpression)expression.Body;
                return member.Member.Name;
            }
            if (expression.Body is MethodCallExpression)
            {
                return ((MethodCallExpression)expression.Body).Method.Name;
            }
            return ((expression.Body as UnaryExpression).Operand as MemberExpression).Member.Name;
        }

        public static Type GetPropertyType<T, Y>(this Expression<Func<T, Y>> expression)
        {
            if (expression.Body is MemberExpression)
            {
                var member = (MemberExpression)expression.Body;
                return ((PropertyInfo)member.Member).PropertyType;
            }
            return ((PropertyInfo)((expression.Body as UnaryExpression).Operand as MemberExpression).Member).PropertyType;
        }

        public static bool IsNumericType(this Type o)
        {
            switch (Type.GetTypeCode(o))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public static string Bindata(this string stringFormat, params object[] value)
        {
            return string.Format(stringFormat, value);
        }

        public static string Display(this object value, string format = "#,##0")
        {
            return string.Format("{0:" + format + "}", value);
        }

        public static Y TryGetValue<T, Y>(this T source, Expression<Func<T, Y>> valueMember)
        {
            if (source != null)
            {
                return (Y)source.GetType().GetProperty(valueMember.GetPropertyName()).GetValue(source);
            }
            return default(Y);
        }

        public static string TryGetMessage(this Exception ex)
        {
            string message = ex.Message;
            if (ex.InnerException != null)
            {
                message += ", InnerException: {0}".Bindata(ex.InnerException.TryGetValue(q => q.Message));
            }
            return message;
        }

        public static string GetName<T>(this T source, Expression<Func<T, object>> valueMember)
        {
            return valueMember.GetPropertyName();
        }

        public static Y CopyDeep<T, Y>(this Y target, T source)
        {
            if (source == null) throw new ArgumentNullException("source");

            var pro_target = target.GetType().GetProperties().ToList();
            foreach (var item in source.GetType().GetProperties())
            {
                var math = pro_target.FirstOrDefault(q => q.Name == item.Name);
                if (math != null)
                {
                    if (math.CanWrite && math.PropertyType == item.PropertyType)
                    {
                        math.SetValue(target, item.GetValue(source));
                    }
                    pro_target.Remove(math);
                }
            }
            return target;
        }

        public static Y CopyDeepOnlyValue<T, Y>(this Y target, T source)
        {
            if (source == null) throw new ArgumentNullException("source");

            var pro_target = target.GetType().GetProperties().ToList();
            foreach (var item in source.GetType().GetProperties())
            {
                var math = pro_target.FirstOrDefault(q => q.Name == item.Name);
                if (math != null)
                {
                    if (math.CanWrite && math.PropertyType == item.PropertyType && math.PropertyType.Namespace == "System")
                    {
                        math.SetValue(target, item.GetValue(source));
                    }
                    pro_target.Remove(math);
                }
            }
            return target;
        }

        public static DateTime OnlyDate(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
        }

        public static TimeSpan OnlyTime(this DateTime dateTime)
        {
            return new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
        }
    }

    public static class FormExtentions
    {
        public static DialogResult ThongBao(this string message)
        {
            return MessageBox.Show(message, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult XacNhan(this string message)
        {
            return MessageBox.Show(message, "XÁC NHẬN", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        public static DialogResult Warning(this string message)
        {
            return MessageBox.Show(message, "CẢNH BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        public static DialogResult Error(this string message)
        {
            return MessageBox.Show(message, "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static Binding AddDataBindings<TControl, TPro, YObject, YPro>
            (this TControl control,
            Expression<Func<TControl, TPro>> propertyName,
            YObject value,
            Expression<Func<YObject, YPro>> dataMember,
            object nullValue = null)
            where TControl : Control
        {
            return control.DataBindings.Add(propertyName.GetPropertyName(), value, dataMember.GetPropertyName()
                , true, DataSourceUpdateMode.OnPropertyChanged, nullValue);
        }

        public static void FormatTextFromTag(this Control control, params object[] value)
        {
            string format = control.Tag + "";
            if (string.IsNullOrWhiteSpace(format) == false)
            {
                control.Text = string.Format(format, value);
            }
        }

        public static void Visible(this DataGridViewRow row, Func<object, bool> visible)
        {
            CurrencyManager currencyManager1 = (CurrencyManager)row.DataGridView.BindingContext[row.DataGridView.DataSource];
            currencyManager1.SuspendBinding();
            row.Visible = visible(row.DataBoundItem);
            currencyManager1.ResumeBinding();
        }
       
        public static void BindDataSource<T, TDisplay, TValue>(this ComboBox cmb, IList<T> source, Expression<Func<T, TValue>> ValueMember, Expression<Func<T, TDisplay>> DisplayMember, object valueSelected = null)
        {
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb.DisplayMember = DisplayMember.GetPropertyName();
            cmb.ValueMember = ValueMember.GetPropertyName();
            cmb.DataSource = source;
            if (valueSelected != null) cmb.SelectedValue = valueSelected;
        }

        public static void BindItems<T, TDisplay>(this ComboBox cmb, IList<T> source, Expression<Func<T, TDisplay>> DisplayMember, object valueSelected = null)
        {
            cmb.Items.Clear();
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb.Items.AddRange(source.ToArray() as object[]);
            cmb.DisplayMember = DisplayMember.GetPropertyName();
            if (valueSelected != null) cmb.SelectedItem = valueSelected;
        }

        public static void BackColor(this DataGridViewRow row, Color? color)
        {
            if (color.HasValue) row.DefaultCellStyle.BackColor = color.Value;
            else row.DefaultCellStyle = null;
        }

        public static Image GetImageClone(this string path)
        {
            if (File.Exists(path))
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    var image = Image.FromFile(path);
                    image.Save(memory, image.RawFormat);
                    return image;
                }
            }
            return null;
        }

        public static void InvokeRequired(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke((MethodInvoker)(delegate ()
                {
                    action();
                }));
            }
            else
            {
                action();
            }
        }

        //public static void BinDataPropertyName<T>(this DataGridView gridView, params ColumnFormat<T>[] columnFormat)
        //{
        //    int min = Math.Min(columnFormat.Length, gridView.ColumnCount);
        //    for (int i = 0; i < min; i++)
        //    {
        //        if (columnFormat[i] != null)
        //        {
        //            var col = gridView.Columns[i];
        //            col.Tag = columnFormat[i].DataPropertyName;
        //            col.DataPropertyName = columnFormat[i].DataPropertyName == null ? null : columnFormat[i].DataPropertyName.GetPropertyName();
        //            col.DefaultCellStyle.Format = columnFormat[i].Format;
        //            col.DefaultCellStyle.BackColor = columnFormat[i].BackColor;
        //            col.DefaultCellStyle.Alignment = columnFormat[i].Alignment;
        //            col.AutoSizeMode = columnFormat[i].AutoSizeMode;
        //        }
        //    }
        //}
    }

    public class ColumnFormat<T>
    {
        public ColumnFormat(Expression<Func<T, object>> DataPropertyName = null, string Format = null, DataGridViewAutoSizeColumnMode mode = 0)
        {
            this.DataPropertyName = DataPropertyName;
            this.Format = Format;
            this.AutoSizeMode = mode;
            if (Format == MyFomat.Money || Format == MyFomat.Number)
            {
                Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        public Expression<Func<T, object>> DataPropertyName { get; set; }
        public string Format { get; set; }
        public DataGridViewContentAlignment Alignment { get; set; }
        public Color BackColor { get; set; }
        public DataGridViewAutoSizeColumnMode AutoSizeMode { get; set; }
    }

    public static class MyFomat
    {
        public static string Money = "#,##0 đ";
        public static string Number = "#,###";
    }
}

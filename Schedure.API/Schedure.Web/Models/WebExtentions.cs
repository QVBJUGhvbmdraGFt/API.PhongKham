using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Schedure.Web
{
    public static class Extentions
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

    public static class WebExtentions
    {
        public static SelectList GetSelectList<T>(this IEnumerable<T> items, Expression<Func<T, object>> dataValueField, Expression<Func<T, object>> dataTextField, object selectedValue = null)
        {
            return new SelectList(items, dataValueField.GetPropertyName(), dataTextField.GetPropertyName(), selectedValue);
        }
    }

    public static class LOG
    {
        public static void DebugLog(this object message)
        {
            Debug.WriteLine("|==========Schedure.Web===========");
            Debug.WriteLine(message);
            Debug.WriteLine("==========Schedure.Web===========|");
        }
    }
}
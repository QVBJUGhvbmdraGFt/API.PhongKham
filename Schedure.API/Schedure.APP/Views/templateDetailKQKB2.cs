﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Schedure.APP.Views
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class templateDetailKQKB2 : templateDetailKQKB2Base
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"
<style>
    table {
        width: 100%;
        text-align: center;
    }

    td {
        padding: 5px;
    }
</style>
<h2>KẾT QUẢ KHÁM BỆNH</h2>

<p>
    <fieldset>
        <legend>
            THÔNG TIN PHÒNG KHÁM
        </legend>
        <table class=""table"" border=""1"">
            <tr>
                <td>
                    TenPhongBan
                </td>
                <td>
                    ThoiGianKham
                </td>
            </tr>
            <tr>
                <td>
                    ");
            
            #line 35 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.TenPhongBan); 
            
            #line default
            #line hidden
            this.Write("                </td>\r\n                <td>\r\n                    ");
            
            #line 38 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.ThoiGianKham); 
            
            #line default
            #line hidden
            this.Write("                </td>\r\n            </tr>\r\n        </table>\r\n    </fieldset>\r\n</p>" +
                    "\r\n\r\n\r\n<p>\r\n    <fieldset>\r\n        <legend>\r\n           Bệnh nhân: ");
            
            #line 49 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.TenBenhNhan); 
            
            #line default
            #line hidden
            this.Write("        </legend>\r\n        <table class=\"table\" border=\"1\">\r\n            <tr>\r\n  " +
                    "              <td>\r\n                    Tuổi: <br /> ");
            
            #line 54 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.Tuoi); 
            
            #line default
            #line hidden
            this.Write("                </td>\r\n                <td>\r\n                    Giới tính:<br />" +
                    "  ");
            
            #line 57 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.GioiTinh); 
            
            #line default
            #line hidden
            this.Write("                </td>\r\n                <td>\r\n                    Mã y tế:<br /> ");
            
            #line 60 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.MaYTe); 
            
            #line default
            #line hidden
            this.Write("                </td>\r\n                <td>\r\n                    Số BHYT:<br /> ");
            
            #line 63 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.SoBHYT); 
            
            #line default
            #line hidden
            this.Write("                </td>\r\n            </tr>\r\n            <tr>\r\n                <td>\r" +
                    "\n                    SDT:<br /> ");
            
            #line 68 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.SoDienThoai); 
            
            #line default
            #line hidden
            this.Write("                </td>\r\n                <td colspan=\"3\">\r\n                    Địa " +
                    "chỉ:<br /> ");
            
            #line 71 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.DiaChi); 
            
            #line default
            #line hidden
            this.Write(@"                </td>
            </tr>
        </table>
    </fieldset>
</p>


<p>
    <fieldset>
        <legend>CHỈ SỐ KHÁM</legend>
        <table class=""table"" border=""1"">
            <tr>
                <td>
                    Cân nặng
                </td>
                <td>
                    Chiều cao
                </td>
                <td>
                    Huyết áp
                </td>
                <td>
                    Mạch
                </td>
                <td>
                    Nhiệt độ
                </td>
                <td>
                    Nhịp thở
                </td>
            </tr>
            <tr>
                <td>
                    ");
            
            #line 105 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.CanNang); 
            
            #line default
            #line hidden
            this.Write("                </td>\r\n                <td>\r\n                    ");
            
            #line 108 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.ChieuCao); 
            
            #line default
            #line hidden
            this.Write("                </td>\r\n                <td>\r\n                    ");
            
            #line 111 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.HuyetAp); 
            
            #line default
            #line hidden
            this.Write("                </td>\r\n                <td>\r\n                    ");
            
            #line 114 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.Mach); 
            
            #line default
            #line hidden
            this.Write("                </td>\r\n                <td>\r\n                    ");
            
            #line 117 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.NhietDo); 
            
            #line default
            #line hidden
            this.Write("                </td>\r\n                <td>\r\n                    ");
            
            #line 120 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.NhipTho); 
            
            #line default
            #line hidden
            this.Write(@"                </td>
            </tr>
        </table>
    </fieldset>
</p>


<p>
    <fieldset>
        <legend>CHUẨN ĐOÁN</legend>
        <table class=""table"" border=""1"">
            <tr>
                <td>
                    TrieuChungLamSang
                </td>
                <td>
                    ChanDoanKhoaKham
                </td>
                <td>
                    MaBenh
                </td>
                <td>
                    MaBenhPhu
                </td>
                <td>
                    NgayHenTaiKham
                </td>
                <td>
                    NoiDungKham
                </td>
            </tr>
            <tr>
                <td>
                    ");
            
            #line 154 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.TrieuChungLamSang); 
            
            #line default
            #line hidden
            this.Write("                </td>\r\n                <td>\r\n                    ");
            
            #line 157 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.ChanDoanKhoaKham); 
            
            #line default
            #line hidden
            this.Write("                </td>\r\n                <td>\r\n                    ");
            
            #line 160 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.MaBenh); 
            
            #line default
            #line hidden
            this.Write("                </td>\r\n                <td>\r\n                    ");
            
            #line 163 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.MaBenhPhu); 
            
            #line default
            #line hidden
            this.Write("                </td>\r\n                <td>\r\n                    ");
            
            #line 166 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.NgayHenTaiKham); 
            
            #line default
            #line hidden
            this.Write("                </td>\r\n                <td>\r\n                    ");
            
            #line 169 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	Write(Model.NoiDungKham); 
            
            #line default
            #line hidden
            this.Write(@"                </td>
            </tr>
        </table>
    </fieldset>
</p>

<p>
    <fieldset>
        <legend>
            KẾT QUẢ CHUẨN LÂM SÀN
        </legend>
        <table class=""table"" border=""1"">
            <tr>
                <td>
                    CSBT
                </td>
                <td>
                    DonViTinh
                </td>
                <td>
                    KetQua
                </td>
                <td>
                    ket_luan
                </td>
                <td>
                    mo_ta
                </td>
                <td>
                    ngay_kq
                </td>
                <td>
                    NoiDung
                </td>
                <td>
                    TenNhomDichVu
                </td>
                <td>
                    TienSu
                </td>
            </tr>
            ");
            
            #line 211 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	foreach (var cls in Model.KetQuaCLS)
	{ 
            
            #line default
            #line hidden
            this.Write("                <tr>\r\n                    <td>\r\n                        ");
            
            #line 215 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(cls.CSBT));
            
            #line default
            #line hidden
            this.Write("\r\n                    </td>\r\n                    <td>\r\n                        ");
            
            #line 218 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(cls.DonViTinh));
            
            #line default
            #line hidden
            this.Write("\r\n                    </td>\r\n                    <td>\r\n                        ");
            
            #line 221 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(cls.KetQua));
            
            #line default
            #line hidden
            this.Write("\r\n                    </td>\r\n                    <td>\r\n                        ");
            
            #line 224 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(cls.ket_luan));
            
            #line default
            #line hidden
            this.Write("\r\n                    </td>\r\n                    <td>\r\n                        ");
            
            #line 227 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(cls.mo_ta));
            
            #line default
            #line hidden
            this.Write("\r\n                    </td>\r\n                    <td>\r\n                        ");
            
            #line 230 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(cls.ngay_kq));
            
            #line default
            #line hidden
            this.Write("\r\n                    </td>\r\n                    <td>\r\n                        ");
            
            #line 233 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(cls.NoiDung));
            
            #line default
            #line hidden
            this.Write("\r\n                    </td>\r\n                    <td>\r\n                        ");
            
            #line 236 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(cls.TenNhomDichVu));
            
            #line default
            #line hidden
            this.Write("\r\n                    </td>\r\n                    <td>\r\n                        ");
            
            #line 239 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(cls.TienSu));
            
            #line default
            #line hidden
            this.Write("\r\n                    </td>\r\n                </tr>\r\n           ");
            
            #line 242 "D:\FLANCER\C#\TEMP\Schedure.API-fix02\Schedure.API\Schedure.APP\Views\templateDetailKQKB2.tt"
	} 
            
            #line default
            #line hidden
            this.Write("        </table>\r\n    </fieldset>\r\n</p>\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class templateDetailKQKB2Base
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}

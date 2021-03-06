﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Schedure.API.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SchedureEntities : DbContext
    {
        public SchedureEntities()
            : base("name=SchedureEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account_BenhNhan> Account_BenhNhan { get; set; }
        public virtual DbSet<Account_NhanVien> Account_NhanVien { get; set; }
        public virtual DbSet<ChuyenKhoa> ChuyenKhoas { get; set; }
        public virtual DbSet<InfoHospital> InfoHospitals { get; set; }
        public virtual DbSet<LichLamViec> LichLamViecs { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Register> Registers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TimeSlot> TimeSlots { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<SP_Account_BenhNhan_Insert_Result> SP_Account_BenhNhan_Insert(string password, string email, string maYTe)
        {
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var maYTeParameter = maYTe != null ?
                new ObjectParameter("MaYTe", maYTe) :
                new ObjectParameter("MaYTe", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Account_BenhNhan_Insert_Result>("SP_Account_BenhNhan_Insert", passwordParameter, emailParameter, maYTeParameter);
        }
    
        public virtual int SP_Account_NhanVien_Insert(string password, string maNhanVien, Nullable<int> iDPosition)
        {
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var maNhanVienParameter = maNhanVien != null ?
                new ObjectParameter("MaNhanVien", maNhanVien) :
                new ObjectParameter("MaNhanVien", typeof(string));
    
            var iDPositionParameter = iDPosition.HasValue ?
                new ObjectParameter("IDPosition", iDPosition) :
                new ObjectParameter("IDPosition", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Account_NhanVien_Insert", passwordParameter, maNhanVienParameter, iDPositionParameter);
        }
    
        public virtual ObjectResult<SP_BacSi_GetByPhongBan_Id_Result> SP_BacSi_GetByPhongBan_Id(Nullable<int> phongBan_Id)
        {
            var phongBan_IdParameter = phongBan_Id.HasValue ?
                new ObjectParameter("PhongBan_Id", phongBan_Id) :
                new ObjectParameter("PhongBan_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_BacSi_GetByPhongBan_Id_Result>("SP_BacSi_GetByPhongBan_Id", phongBan_IdParameter);
        }
    
        public virtual ObjectResult<SP_ChuyenKhoa_GetAll_Result> SP_ChuyenKhoa_GetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ChuyenKhoa_GetAll_Result>("SP_ChuyenKhoa_GetAll");
        }
    
        public virtual ObjectResult<SP_DM_BenhNhan_GetByMaYTe_Result> SP_DM_BenhNhan_GetByMaYTe(string maYTe)
        {
            var maYTeParameter = maYTe != null ?
                new ObjectParameter("MaYTe", maYTe) :
                new ObjectParameter("MaYTe", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_DM_BenhNhan_GetByMaYTe_Result>("SP_DM_BenhNhan_GetByMaYTe", maYTeParameter);
        }
    
        public virtual ObjectResult<SP_DM_PhongBan_GetByPhongBan_Id_Result> SP_DM_PhongBan_GetByPhongBan_Id(Nullable<int> phongBan_Id)
        {
            var phongBan_IdParameter = phongBan_Id.HasValue ?
                new ObjectParameter("PhongBan_Id", phongBan_Id) :
                new ObjectParameter("PhongBan_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_DM_PhongBan_GetByPhongBan_Id_Result>("SP_DM_PhongBan_GetByPhongBan_Id", phongBan_IdParameter);
        }
    
        public virtual ObjectResult<SP_BacSi_GetAll_Result> SP_BacSi_GetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_BacSi_GetAll_Result>("SP_BacSi_GetAll");
        }
    
        public virtual ObjectResult<SP_PhongBan_GetAll_Result> SP_PhongBan_GetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_PhongBan_GetAll_Result>("SP_PhongBan_GetAll");
        }
    
        public virtual ObjectResult<SP_PhongBan_GetSource_Result> SP_PhongBan_GetSource()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_PhongBan_GetSource_Result>("SP_PhongBan_GetSource");
        }
    
        public virtual ObjectResult<SP_LichLamViec_GetByPhongBan_Id_Result> SP_LichLamViec_GetByPhongBan_Id(Nullable<int> phongBan_Id, Nullable<System.DateTime> date)
        {
            var phongBan_IdParameter = phongBan_Id.HasValue ?
                new ObjectParameter("PhongBan_Id", phongBan_Id) :
                new ObjectParameter("PhongBan_Id", typeof(int));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_LichLamViec_GetByPhongBan_Id_Result>("SP_LichLamViec_GetByPhongBan_Id", phongBan_IdParameter, dateParameter);
        }
    
        public virtual ObjectResult<SP_Register_GetAllOrBy_Result> SP_Register_GetAllOrBy(Nullable<System.DateTime> start, Nullable<System.DateTime> end, string status, Nullable<int> iDPhongBan, Nullable<int> iDRegiter, Nullable<int> iDAccount)
        {
            var startParameter = start.HasValue ?
                new ObjectParameter("start", start) :
                new ObjectParameter("start", typeof(System.DateTime));
    
            var endParameter = end.HasValue ?
                new ObjectParameter("end", end) :
                new ObjectParameter("end", typeof(System.DateTime));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            var iDPhongBanParameter = iDPhongBan.HasValue ?
                new ObjectParameter("IDPhongBan", iDPhongBan) :
                new ObjectParameter("IDPhongBan", typeof(int));
    
            var iDRegiterParameter = iDRegiter.HasValue ?
                new ObjectParameter("IDRegiter", iDRegiter) :
                new ObjectParameter("IDRegiter", typeof(int));
    
            var iDAccountParameter = iDAccount.HasValue ?
                new ObjectParameter("IDAccount", iDAccount) :
                new ObjectParameter("IDAccount", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Register_GetAllOrBy_Result>("SP_Register_GetAllOrBy", startParameter, endParameter, statusParameter, iDPhongBanParameter, iDRegiterParameter, iDAccountParameter);
        }
    
        public virtual ObjectResult<SP_LichLamViec_GetAllOrID_Result> SP_LichLamViec_GetAllOrID(Nullable<int> iDLich)
        {
            var iDLichParameter = iDLich.HasValue ?
                new ObjectParameter("IDLich", iDLich) :
                new ObjectParameter("IDLich", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_LichLamViec_GetAllOrID_Result>("SP_LichLamViec_GetAllOrID", iDLichParameter);
        }
    
        public virtual int SP_PhongBan_Insert(Nullable<int> iDChuyenKhoa, Nullable<int> phongBan_Id)
        {
            var iDChuyenKhoaParameter = iDChuyenKhoa.HasValue ?
                new ObjectParameter("IDChuyenKhoa", iDChuyenKhoa) :
                new ObjectParameter("IDChuyenKhoa", typeof(int));
    
            var phongBan_IdParameter = phongBan_Id.HasValue ?
                new ObjectParameter("PhongBan_Id", phongBan_Id) :
                new ObjectParameter("PhongBan_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_PhongBan_Insert", iDChuyenKhoaParameter, phongBan_IdParameter);
        }
    
        public virtual int SP_Register_Insert(Nullable<int> iDAccountBN, string maYTe, string message, string status, Nullable<int> iDLich, string phone, Nullable<System.DateTime> ngayKham, string status_Patient, string patient_name, Nullable<int> nhanVien_Id, Nullable<int> iDChuyenKhoa)
        {
            var iDAccountBNParameter = iDAccountBN.HasValue ?
                new ObjectParameter("IDAccountBN", iDAccountBN) :
                new ObjectParameter("IDAccountBN", typeof(int));
    
            var maYTeParameter = maYTe != null ?
                new ObjectParameter("MaYTe", maYTe) :
                new ObjectParameter("MaYTe", typeof(string));
    
            var messageParameter = message != null ?
                new ObjectParameter("Message", message) :
                new ObjectParameter("Message", typeof(string));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            var iDLichParameter = iDLich.HasValue ?
                new ObjectParameter("IDLich", iDLich) :
                new ObjectParameter("IDLich", typeof(int));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var ngayKhamParameter = ngayKham.HasValue ?
                new ObjectParameter("NgayKham", ngayKham) :
                new ObjectParameter("NgayKham", typeof(System.DateTime));
    
            var status_PatientParameter = status_Patient != null ?
                new ObjectParameter("Status_Patient", status_Patient) :
                new ObjectParameter("Status_Patient", typeof(string));
    
            var patient_nameParameter = patient_name != null ?
                new ObjectParameter("Patient_name", patient_name) :
                new ObjectParameter("Patient_name", typeof(string));
    
            var nhanVien_IdParameter = nhanVien_Id.HasValue ?
                new ObjectParameter("NhanVien_Id", nhanVien_Id) :
                new ObjectParameter("NhanVien_Id", typeof(int));
    
            var iDChuyenKhoaParameter = iDChuyenKhoa.HasValue ?
                new ObjectParameter("IDChuyenKhoa", iDChuyenKhoa) :
                new ObjectParameter("IDChuyenKhoa", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Register_Insert", iDAccountBNParameter, maYTeParameter, messageParameter, statusParameter, iDLichParameter, phoneParameter, ngayKhamParameter, status_PatientParameter, patient_nameParameter, nhanVien_IdParameter, iDChuyenKhoaParameter);
        }
    
        public virtual ObjectResult<sp_LayNgayKhamTuNgayDenNgay_Result> sp_LayNgayKhamTuNgayDenNgay(Nullable<int> benhNhan_Id, Nullable<System.DateTime> tuNgay, Nullable<System.DateTime> denNgay)
        {
            var benhNhan_IdParameter = benhNhan_Id.HasValue ?
                new ObjectParameter("BenhNhan_Id", benhNhan_Id) :
                new ObjectParameter("BenhNhan_Id", typeof(int));
    
            var tuNgayParameter = tuNgay.HasValue ?
                new ObjectParameter("TuNgay", tuNgay) :
                new ObjectParameter("TuNgay", typeof(System.DateTime));
    
            var denNgayParameter = denNgay.HasValue ?
                new ObjectParameter("DenNgay", denNgay) :
                new ObjectParameter("DenNgay", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_LayNgayKhamTuNgayDenNgay_Result>("sp_LayNgayKhamTuNgayDenNgay", benhNhan_IdParameter, tuNgayParameter, denNgayParameter);
        }
    
        public virtual ObjectResult<sp_LayChanDoanKhamLS_Result> sp_LayChanDoanKhamLS(Nullable<int> khamBenh_Id)
        {
            var khamBenh_IdParameter = khamBenh_Id.HasValue ?
                new ObjectParameter("KhamBenh_Id", khamBenh_Id) :
                new ObjectParameter("KhamBenh_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_LayChanDoanKhamLS_Result>("sp_LayChanDoanKhamLS", khamBenh_IdParameter);
        }
    
        public virtual ObjectResult<SP_LayKetQuaCLS_Result> SP_LayKetQuaCLS(Nullable<int> khambenh_id)
        {
            var khambenh_idParameter = khambenh_id.HasValue ?
                new ObjectParameter("khambenh_id", khambenh_id) :
                new ObjectParameter("khambenh_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_LayKetQuaCLS_Result>("SP_LayKetQuaCLS", khambenh_idParameter);
        }
    
        public virtual ObjectResult<SP_Account_NhanVien_GetAllOrByID_Result> SP_Account_NhanVien_GetAllOrByID(Nullable<int> iDAccountNV)
        {
            var iDAccountNVParameter = iDAccountNV.HasValue ?
                new ObjectParameter("IDAccountNV", iDAccountNV) :
                new ObjectParameter("IDAccountNV", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Account_NhanVien_GetAllOrByID_Result>("SP_Account_NhanVien_GetAllOrByID", iDAccountNVParameter);
        }
    
        public virtual ObjectResult<SP_Account_NhanVien_GetSource_Result> SP_Account_NhanVien_GetSource()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Account_NhanVien_GetSource_Result>("SP_Account_NhanVien_GetSource");
        }
    }
}

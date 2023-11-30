namespace Data.Context
{
    public partial class VNPTContext : DbContext
    {
        public VNPTContext()
        {
        }
        public VNPTContext(DbContextOptions<VNPTContext> options)
            : base(options)
        {
        }
		public virtual DbSet<Data.Model.EmailConfig> EmailConfig { get; set; }
		public virtual DbSet<Data.Model.DichVu> DichVu { get; set; }
		public virtual DbSet<Data.Model.DichVuChiTieu> DichVuChiTieu { get; set; }
		public virtual DbSet<Data.Model.GoiCuoc> GoiCuoc { get; set; }
		public virtual DbSet<Data.Model.DoanhNghiep> DoanhNghiep { get; set; }
        public virtual DbSet<Data.Model.DoanhNghiepDichVu> DoanhNghiepDichVu { get; set; }
		public virtual DbSet<Data.Model.DoanhNghiepDichVuCA> DoanhNghiepDichVuCA { get; set; }
		public virtual DbSet<Data.Model.DoanhNghiepDichVuLichSu> DoanhNghiepDichVuLichSu { get; set; }
        public virtual DbSet<Data.Model.DoanhNghiepThanhVien> DoanhNghiepThanhVien { get; set; }
        public virtual DbSet<Data.Model.Huyen> Huyen { get; set; }
        public virtual DbSet<Data.Model.LoaiDoanhNghiep> LoaiDoanhNghiep { get; set; }
        public virtual DbSet<Data.Model.LoaiDoanhNghiepThanhVien> LoaiDoanhNghiepThanhVien { get; set; }
        public virtual DbSet<Data.Model.LoaiTrangThai> LoaiTrangThai { get; set; }
        public virtual DbSet<Data.Model.LoaiDichVu> LoaiDichVu { get; set; }
        public virtual DbSet<Data.Model.NganhNgheKinhDoanh> NganhNgheKinhDoanh { get; set; }
        public virtual DbSet<Data.Model.NhanVien> NhanVien { get; set; }
		public virtual DbSet<Data.Model.NhanVienToken> NhanVienToken { get; set; }
		public virtual DbSet<Data.Model.PhongBan> PhongBan { get; set; }
        public virtual DbSet<Data.Model.NhanVienKhuVuc> NhanVienKhuVuc { get; set; }
		public virtual DbSet<Data.Model.NhanVienTaiKhoan> NhanVienTaiKhoan { get; set; }
		public virtual DbSet<Data.Model.PhongBanKhuVuc> PhongBanKhuVuc { get; set; }
        public virtual DbSet<Data.Model.Tinh> Tinh { get; set; }
        public virtual DbSet<Data.Model.Xa> Xa { get; set; }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GlobalHelper.SQLServerConectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

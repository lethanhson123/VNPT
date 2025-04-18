﻿using Data.Repository.Interface;

namespace Business
{
    public static class ConfigureService
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
			services.AddTransient<IDanhMucChucNangBusiness, DanhMucChucNangBusiness>();
			services.AddTransient<IDanhMucGoiCuocBusiness, DanhMucGoiCuocBusiness>();			
            services.AddTransient<IDichVuBusiness, DichVuBusiness>();
			services.AddTransient<IDichVuChiTieuBusiness, DichVuChiTieuBusiness>();
			services.AddTransient<IGoiCuocBusiness, GoiCuocBusiness>();
			services.AddTransient<IDoanhNghiepBusiness, DoanhNghiepBusiness>();
            services.AddTransient<IDoanhNghiepDichVuBusiness, DoanhNghiepDichVuBusiness>();
			services.AddTransient<IDoanhNghiepDichVuCABusiness, DoanhNghiepDichVuCABusiness>();
			services.AddTransient<IDoanhNghiepDichVuLichSuBusiness, DoanhNghiepDichVuLichSuBusiness>();
            services.AddTransient<IDoanhNghiepThanhVienBusiness, DoanhNghiepThanhVienBusiness>();
            services.AddTransient<IHuyenBusiness, HuyenBusiness>();
            services.AddTransient<ILoaiDoanhNghiepBusiness, LoaiDoanhNghiepBusiness>();
            services.AddTransient<ILoaiDoanhNghiepThanhVienBusiness, LoaiDoanhNghiepThanhVienBusiness>();
            services.AddTransient<ILoaiTrangThaiBusiness, LoaiTrangThaiBusiness>();
            services.AddTransient<ILoaiDichVuBusiness, LoaiDichVuBusiness>();
            services.AddTransient<INganhNgheKinhDoanhBusiness, NganhNgheKinhDoanhBusiness>();
            services.AddTransient<INhanVienBusiness, NhanVienBusiness>();
			services.AddTransient<INhanVienTokenBusiness, NhanVienTokenBusiness>();
			services.AddTransient<IPhongBanBusiness, PhongBanBusiness>();
            services.AddTransient<IPhongBanKhuVucBusiness, PhongBanKhuVucBusiness>();
            services.AddTransient<INhanVienChucNangBusiness, NhanVienChucNangBusiness>();
			services.AddTransient<INhanVienKhuVucBusiness, NhanVienKhuVucBusiness>();
			services.AddTransient<INhanVienTaiKhoanBusiness, NhanVienTaiKhoanBusiness>();
			services.AddTransient<INhanVienMenuBusiness, NhanVienMenuBusiness>();
			services.AddTransient<ITinhBusiness, TinhBusiness>();
            services.AddTransient<IXaBusiness, XaBusiness>();
			services.AddTransient<IMenuBusiness, MenuBusiness>();

            services.AddTransient<IEmailConfigBusiness, EmailConfigBusiness>();
            services.AddTransient<IEmailLichSuBusiness, EmailLichSuBusiness>();
            services.AddTransient<IEmailMauBusiness, EmailMauBusiness>();
            services.AddTransient<IEmailMauTapTinDinhKemBusiness, EmailMauTapTinDinhKemBusiness>();
            services.AddTransient<IEmailChienDichBusiness, EmailChienDichBusiness>();
            services.AddTransient<IEmailChienDichChiTietBusiness, EmailChienDichChiTietBusiness>();

            services.AddTransient<IReportBusiness, ReportBusiness>();

            services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));
            return services;
        }
        public static IServiceCollection AddContextService(this IServiceCollection services)
        {
            services.AddDbContext<VNPTContext>(opts =>
            {
            });
            return services;
        }
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
			services.AddTransient<IDanhMucChucNangRepository, DanhMucChucNangRepository>();
			services.AddTransient<IDanhMucGoiCuocRepository, DanhMucGoiCuocRepository>();			
            services.AddTransient<IDichVuRepository, DichVuRepository>();
			services.AddTransient<IDichVuChiTieuRepository, DichVuChiTieuRepository>();
			services.AddTransient<IGoiCuocRepository, GoiCuocRepository>();
            services.AddTransient<IDoanhNghiepDichVuLichSuRepository, DoanhNghiepDichVuLichSuRepository>();
            services.AddTransient<IDoanhNghiepDichVuRepository, DoanhNghiepDichVuRepository>();
			services.AddTransient<IDoanhNghiepDichVuCARepository, DoanhNghiepDichVuCARepository>();
			services.AddTransient<IDoanhNghiepRepository, DoanhNghiepRepository>();
            services.AddTransient<IDoanhNghiepThanhVienRepository, DoanhNghiepThanhVienRepository>();
            services.AddTransient<IHuyenRepository, HuyenRepository>();
            services.AddTransient<ILoaiDoanhNghiepRepository, LoaiDoanhNghiepRepository>();
            services.AddTransient<ILoaiDoanhNghiepThanhVienRepository, LoaiDoanhNghiepThanhVienRepository>();
            services.AddTransient<ILoaiTrangThaiRepository, LoaiTrangThaiRepository>();
            services.AddTransient<ILoaiDichVuRepository, LoaiDichVuRepository>();
            services.AddTransient<INganhNgheKinhDoanhRepository, NganhNgheKinhDoanhRepository>();
            services.AddTransient<INhanVienRepository, NhanVienRepository>();
			services.AddTransient<INhanVienTokenRepository, NhanVienTokenRepository>();
			services.AddTransient<IPhongBanRepository, PhongBanRepository>();
            services.AddTransient<IPhongBanKhuVucRepository, PhongBanKhuVucRepository>();
			services.AddTransient<INhanVienChucNangRepository, NhanVienChucNangRepository>();
			services.AddTransient<INhanVienKhuVucRepository, NhanVienKhuVucRepository>();
			services.AddTransient<INhanVienTaiKhoanRepository, NhanVienTaiKhoanRepository>();
			services.AddTransient<INhanVienMenuRepository, NhanVienMenuRepository>();
			services.AddTransient<ITinhRepository, TinhRepository>();
            services.AddTransient<IXaRepository, XaRepository>();
			services.AddTransient<IMenuRepository, MenuRepository>();

            services.AddTransient<IEmailConfigRepository, EmailConfigRepository>();
            services.AddTransient<IEmailLichSuRepository, EmailLichSuRepository>();
            services.AddTransient<IEmailMauRepository, EmailMauRepository>();
            services.AddTransient<IEmailMauTapTinDinhKemRepository, EmailMauTapTinDinhKemRepository>();
            services.AddTransient<IEmailChienDichRepository, EmailChienDichRepository>();
            services.AddTransient<IEmailChienDichChiTietRepository, EmailChienDichChiTietRepository>();

            services.AddTransient<IReportRepository, ReportRepository>();

            return services;
        }
    }
}

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { TinhComponent } from './tinh/tinh.component';
import { HuyenComponent } from './huyen/huyen.component';
import { XaComponent } from './xa/xa.component';
import { LoaiTrangThaiComponent } from './loai-trang-thai/loai-trang-thai.component';
import { DichVuComponent } from './dich-vu/dich-vu.component';
import { LoaiDoanhNghiepComponent } from './loai-doanh-nghiep/loai-doanh-nghiep.component';
import { LoaiDoanhNghiepThanhVienComponent } from './loai-doanh-nghiep-thanh-vien/loai-doanh-nghiep-thanh-vien.component';
import { NganhNgheKinhDoanhComponent } from './nganh-nghe-kinh-doanh/nganh-nghe-kinh-doanh.component';
import { DoanhNghiepComponent } from './doanh-nghiep/doanh-nghiep.component';
import { UploadComponent } from './upload/upload.component';
import { DoanhNghiepInfoComponent } from './doanh-nghiep/doanh-nghiep-info/doanh-nghiep-info.component';
import { NhanVienComponent } from './nhan-vien/nhan-vien.component';
import { LoaiDichVuComponent } from './loai-dich-vu/loai-dich-vu.component';
import { NhanVienInfoComponent } from './nhan-vien/nhan-vien-info/nhan-vien-info.component';
import { PhongBanInfoComponent } from './phong-ban/phong-ban-info/phong-ban-info.component';
import { PhongBanComponent } from './phong-ban/phong-ban.component';
import { DoanhNghiepMaSoThueKhongTonTaiComponent } from './doanh-nghiep-ma-so-thue-khong-ton-tai/doanh-nghiep-ma-so-thue-khong-ton-tai.component';
import { DashboardCAComponent } from './dashboard-ca/dashboard-ca.component';
import { DashboardTenMienComponent } from './dashboard-ten-mien/dashboard-ten-mien.component';
import { DashboardHoaDonDienTuComponent } from './dashboard-hoa-don-dien-tu/dashboard-hoa-don-dien-tu.component';
import { NhanVienTaiKhoanComponent } from './nhan-vien-tai-khoan/nhan-vien-tai-khoan.component';
import { GoiCuocComponent } from './goi-cuoc/goi-cuoc.component';
import { NhanVienDangNhapComponent } from './nhan-vien-dang-nhap/nhan-vien-dang-nhap.component';
import { CAVNPTComponent } from './cavnpt/cavnpt.component';
import { CASmartComponent } from './casmart/casmart.component';
import { PhanQuyenMenuComponent } from './phan-quyen-menu/phan-quyen-menu.component';
import { KhachHangComponent } from './khach-hang/khach-hang.component';


const routes: Routes = [  
  { path: '', redirectTo: '/Homepage', pathMatch: 'full' },  
  {
    path: 'Homepage', component: HomepageComponent,
  },
  {
    path: 'DashboardCA', component: DashboardCAComponent,
  },     
  {
    path: 'CAVNPT', component: CAVNPTComponent,
  },   
  {
    path: 'CASmart', component: CASmartComponent,
  },   
  {
    path: 'DashboardTenMien', component: DashboardTenMienComponent,
  },  
  {
    path: 'DashboardHoaDonDienTu', component: DashboardHoaDonDienTuComponent,
  },  
  {
    path: 'Tinh', component: TinhComponent,
  },
  {
    path: 'Huyen', component: HuyenComponent,
  },
  {
    path: 'Xa', component: XaComponent,
  },
  {
    path: 'LoaiTrangThai', component: LoaiTrangThaiComponent,
  },
  {
    path: 'GoiCuoc', component: GoiCuocComponent,
  },
  {
    path: 'DichVu', component: DichVuComponent,
  },
  {
    path: 'LoaiDichVu', component: LoaiDichVuComponent,
  },
  {
    path: 'LoaiDoanhNghiep', component: LoaiDoanhNghiepComponent,
  },
  {
    path: 'LoaiDoanhNghiepThanhVien', component: LoaiDoanhNghiepThanhVienComponent,
  },
  {
    path: 'NganhNgheKinhDoanh', component: NganhNgheKinhDoanhComponent,
  },
  {
    path: 'NhanVienTaiKhoan', component: NhanVienTaiKhoanComponent,
  },  
  {
    path: 'NhanVien', component: NhanVienComponent,
  },  
  {
    path: 'NhanVienInfo/:ID', component: NhanVienInfoComponent,
  },
  {
    path: 'NhanVienDangNhap', component: NhanVienDangNhapComponent,
  },
  {
    path: 'DoanhNghiepMaSoThueKhongTonTai', component: DoanhNghiepMaSoThueKhongTonTaiComponent,
  },  
  {
    path: 'DoanhNghiep', component: DoanhNghiepComponent,
  },  
  {
    path: 'DoanhNghiepInfo/:ID', component: DoanhNghiepInfoComponent,
  },
  {
    path: 'KhachHang', component: KhachHangComponent,
  }, 
  {
    path: 'PhongBan', component: PhongBanComponent,
  },  
  {
    path: 'PhongBanInfo/:ID', component: PhongBanInfoComponent,
  },
  {
    path: 'Upload', component: UploadComponent,
  },   
  {
    path: 'PhanQuyenMenu', component: PhanQuyenMenuComponent,
  },  
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true, initialNavigation: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { CKEditorModule } from 'ngx-ckeditor';
import { NotificationService } from './shared/notification.service';
import { CookieService } from 'ngx-cookie-service';
import { ChartsModule } from 'ng2-charts';
import { MAT_DATE_LOCALE } from '@angular/material/core';

import { AppComponent } from './app.component';
import { LoadingComponent } from './loading/loading.component';
import { HomepageComponent } from './homepage/homepage.component';
import { TinhComponent } from './tinh/tinh.component';
import { HuyenComponent } from './huyen/huyen.component';
import { XaComponent } from './xa/xa.component';
import { DichVuComponent } from './dich-vu/dich-vu.component';
import { LoaiDoanhNghiepComponent } from './loai-doanh-nghiep/loai-doanh-nghiep.component';
import { LoaiDoanhNghiepThanhVienComponent } from './loai-doanh-nghiep-thanh-vien/loai-doanh-nghiep-thanh-vien.component';
import { LoaiTrangThaiComponent } from './loai-trang-thai/loai-trang-thai.component';
import { NganhNgheKinhDoanhComponent } from './nganh-nghe-kinh-doanh/nganh-nghe-kinh-doanh.component';
import { DoanhNghiepComponent } from './doanh-nghiep/doanh-nghiep.component';
import { UploadComponent } from './upload/upload.component';
import { DoanhNghiepInfoComponent } from './doanh-nghiep/doanh-nghiep-info/doanh-nghiep-info.component';
import { NhanVienComponent } from './nhan-vien/nhan-vien.component';
import { LoaiDichVuComponent } from './loai-dich-vu/loai-dich-vu.component';
import { PhongBanComponent } from './phong-ban/phong-ban.component';
import { PhongBanInfoComponent } from './Phong-Ban/phong-ban-info/phong-ban-info.component';
import { NhanVienInfoComponent } from './nhan-vien/nhan-vien-info/nhan-vien-info.component';
import { DoanhNghiepMaSoThueKhongTonTaiComponent } from './doanh-nghiep-ma-so-thue-khong-ton-tai/doanh-nghiep-ma-so-thue-khong-ton-tai.component';
import { DashboardCAComponent } from './dashboard-ca/dashboard-ca.component';
import { DashboardHoaDonDienTuComponent } from './dashboard-hoa-don-dien-tu/dashboard-hoa-don-dien-tu.component';
import { DashboardTenMienComponent } from './dashboard-ten-mien/dashboard-ten-mien.component';
import { NhanVienTaiKhoanComponent } from './nhan-vien-tai-khoan/nhan-vien-tai-khoan.component';
import { GoiCuocComponent } from './goi-cuoc/goi-cuoc.component';
import { DoanhNghiepDichVuCAComponent } from './doanh-nghiep-dich-vu-ca/doanh-nghiep-dich-vu-ca.component';
import { DoanhNghiepDichVuCADetailComponent } from './doanh-nghiep-dich-vu-ca/doanh-nghiep-dich-vu-cadetail/doanh-nghiep-dich-vu-cadetail.component';



@NgModule({
  declarations: [
    AppComponent,
    LoadingComponent,
    HomepageComponent,
    TinhComponent,    
    HuyenComponent,
    XaComponent,
    DichVuComponent,
    LoaiDoanhNghiepComponent,
    LoaiDoanhNghiepThanhVienComponent,
    LoaiTrangThaiComponent,
    NganhNgheKinhDoanhComponent,
    DoanhNghiepComponent,
    UploadComponent,
    DoanhNghiepInfoComponent,
    NhanVienComponent,
    LoaiDichVuComponent,
    PhongBanComponent,
    PhongBanInfoComponent,
    NhanVienInfoComponent,
    DoanhNghiepMaSoThueKhongTonTaiComponent,
    DashboardCAComponent,
    DashboardHoaDonDienTuComponent,
    DashboardTenMienComponent,
    NhanVienTaiKhoanComponent,
    GoiCuocComponent,
    DoanhNghiepDichVuCAComponent,
    DoanhNghiepDichVuCADetailComponent,    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'serverApp' }),
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    ChartsModule,
    CKEditorModule,
  ],
  providers: [   
    CookieService,  
    NotificationService,
    {provide: MAT_DATE_LOCALE, useValue: 'en-GB'}
  ],
  bootstrap: [AppComponent],
  entryComponents:[]
})
export class AppModule { }

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

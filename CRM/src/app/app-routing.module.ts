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


const routes: Routes = [  
  { path: '', redirectTo: '/Homepage', pathMatch: 'full' },
  {
    path: 'Homepage', component: HomepageComponent,
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
    path: 'DichVu', component: DichVuComponent,
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
    path: 'DoanhNghiep', component: DoanhNghiepComponent,
  },  
  {
    path: 'DoanhNghiepInfo/:ID', component: DoanhNghiepInfoComponent,
  },
  {
    path: 'Upload', component: UploadComponent,
  },   
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true, initialNavigation: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }

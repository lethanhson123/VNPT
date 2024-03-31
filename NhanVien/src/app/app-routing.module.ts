import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { DoanhNghiepComponent } from './doanh-nghiep/doanh-nghiep.component';
import { DoanhNghiepDichVuCAHoSoComponent } from './doanh-nghiep-dich-vu-caho-so/doanh-nghiep-dich-vu-caho-so.component';


const routes: Routes = [  
  { path: '', redirectTo: '/DoanhNghiep', pathMatch: 'full' },   
  {
    path: 'Homepage', component: HomepageComponent,
  },   
  {
    path: 'DoanhNghiep', component: DoanhNghiepComponent,
  },   
  {
    path: 'DoanhNghiepDichVuCAHoSo', component: DoanhNghiepDichVuCAHoSoComponent,
  },  
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true, initialNavigation: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }

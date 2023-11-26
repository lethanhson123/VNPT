import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { XacThucOTPComponent } from './xac-thuc-otp/xac-thuc-otp.component';


const routes: Routes = [  
  { path: '', redirectTo: '/Homepage', pathMatch: 'full' },  
  {
    path: 'Homepage', component: HomepageComponent,
  },  
  {
    path: 'XacThucOTP', component: XacThucOTPComponent,
  },  
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true, initialNavigation: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }

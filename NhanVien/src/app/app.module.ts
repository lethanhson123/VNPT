import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CKEditorModule } from 'ngx-ckeditor';
import { ChartsModule } from 'ng2-charts';
import { CookieService } from 'ngx-cookie-service';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { MaterialModule } from './material/material.module';
import { GoogleMapsModule } from '@angular/google-maps';

import { NotificationService } from './shared/Notification.service';


import { AppComponent } from './app.component';
import { LoadingComponent } from './loading/loading.component';
import { HomepageComponent } from './homepage/homepage.component';
import { DoanhNghiepComponent } from './doanh-nghiep/doanh-nghiep.component';
import { DoanhNghiepDetailComponent } from './doanh-nghiep-detail/doanh-nghiep-detail.component';
import { DoanhNghiepDichVuCAComponent } from './doanh-nghiep-dich-vu-ca/doanh-nghiep-dich-vu-ca.component';
import { DoanhNghiepDichVuCADetailComponent } from './doanh-nghiep-dich-vu-cadetail/doanh-nghiep-dich-vu-cadetail.component';
import { DoanhNghiepDichVuCAHoSoComponent } from './doanh-nghiep-dich-vu-caho-so/doanh-nghiep-dich-vu-caho-so.component';




@NgModule({
    declarations: [
        AppComponent,
        LoadingComponent,
        HomepageComponent,
        DoanhNghiepComponent,
        DoanhNghiepDetailComponent,
        DoanhNghiepDichVuCAComponent,
        DoanhNghiepDichVuCADetailComponent,
        DoanhNghiepDichVuCAHoSoComponent,     
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'serverApp' }),
        FormsModule,
        HttpClientModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        MaterialModule,
        GoogleMapsModule,
        ChartsModule,
        CKEditorModule,
    ],
    providers: [
        CookieService,
        NotificationService,
        { provide: MAT_DATE_LOCALE, useValue: 'en-GB' }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }

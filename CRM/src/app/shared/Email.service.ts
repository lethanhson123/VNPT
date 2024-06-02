import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { EmailConfig } from './EmailConfig.model';
@Injectable({
    providedIn: 'root'
})
export class EmailService extends BaseService {   
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Email";
    }
    AsyncHetHanDoanhNghiepDichVuCA2024() {       
        let url = this.aPIURL + this.controller + '/AsyncHetHanDoanhNghiepDichVuCA2024';
        const formUpload: FormData = new FormData();    
        formUpload.append('data', JSON.stringify(this.BaseParameter));      
        return this.httpClient.post(url, formUpload);
    }
    AsyncThieuHoSoDoanhNghiepDichVuCA() {       
        let url = this.aPIURL + this.controller + '/AsyncThieuHoSoDoanhNghiepDichVuCA';
        const formUpload: FormData = new FormData();        
        return this.httpClient.post(url, formUpload);
    }
    AsyncThieuHoSoDoanhNghiepDichVuCAIsSmartCA(isSmartCA: boolean) {       
        let url = this.aPIURL + this.controller + '/AsyncThieuHoSoDoanhNghiepDichVuCAIsSmartCA';
        const formUpload: FormData = new FormData();      
        formUpload.append('data', JSON.stringify(isSmartCA));  
        return this.httpClient.post(url, formUpload);
    }
}





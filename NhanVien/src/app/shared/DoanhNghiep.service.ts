import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BaseService } from './Base.service';
import { DoanhNghiep } from './DoanhNghiep.model';



@Injectable({
    providedIn: 'root'
})
export class DoanhNghiepService extends BaseService {

    List: DoanhNghiep[] | undefined;
    ListFilter: DoanhNghiep[] | undefined;
    FormData!: DoanhNghiep;

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "DoanhNghiep";
    }
    GetBySearchStringToListAsync() {        
        let url = this.APIURL + this.Controller + '/GetBySearchStringToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    GetByHuyenIDAndXaIDOrSearchStringToListAsync() {
        if (this.BaseParameter.HuyenID == null) {
            this.BaseParameter.HuyenID = environment.InitializationNumber;
        }
        if (this.BaseParameter.XaID == null) {
            this.BaseParameter.XaID = environment.InitializationNumber;
        }
        let url = this.APIURL + this.Controller + '/GetByHuyenIDAndXaIDOrSearchStringToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
}





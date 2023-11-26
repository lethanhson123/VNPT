import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './Base.service';
import { NhanVien } from './NhanVien.model';
@Injectable({
    providedIn: 'root'
})
export class NhanVienService extends BaseService {
    displayColumns: string[] = ['ParentID', 'Code', 'Name', 'DienThoai', 'CCCD', 'Email'];
    displayColumns001: string[] = ['Code', 'Name', 'DienThoai'];
    list: NhanVien[] | undefined;
    formData!: NhanVien;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "NhanVien";
    }
    AuthenticationAsync(formData: NhanVien) {
        let url = this.aPIURL + this.controller + '/AuthenticationAsync';
        const formUpload: FormData = new FormData();       
        formUpload.append('data', JSON.stringify(formData));       
        return this.httpClient.post(url, formUpload);
    }

}





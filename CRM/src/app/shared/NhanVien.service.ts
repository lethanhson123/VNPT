import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './Base.service';
import { NhanVien } from './NhanVien.model';
@Injectable({
    providedIn: 'root'
})
export class NhanVienService extends BaseService {
    displayColumns: string[] = ['ParentID', 'Code', 'Name', 'DienThoai', 'CCCD', 'Email'];
    list: NhanVien[] | undefined;
    formData!: NhanVien;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "NhanVien";
    }
    GetByIDStringAsync(ID: string) {
        let url = this.aPIURL + this.controller + '/GetByIDStringAsync';
        const params = new HttpParams()
            .set('ID', ID)
        return this.httpClient.get(url, { params }).toPromise();
    }
}





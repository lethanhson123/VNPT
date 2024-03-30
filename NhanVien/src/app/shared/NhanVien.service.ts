import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BaseService } from './Base.service';
import { NhanVien } from './NhanVien.model';

@Injectable({
    providedIn: 'root'
})
export class NhanVienService extends BaseService {
    
    List: NhanVien[] | undefined;
    ListFilter: NhanVien[] | undefined;
    FormData!: NhanVien;

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "NhanVien";
    }
    
}





import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { DanhMucChucNang } from './DanhMucChucNang.model';
@Injectable({
    providedIn: 'root'
})
export class DanhMucChucNangService extends BaseService {        
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "DanhMucChucNang";
    }
}





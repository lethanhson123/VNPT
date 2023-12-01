import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { DanhMucGoiCuoc } from './DanhMucGoiCuoc.model';
@Injectable({
    providedIn: 'root'
})
export class DanhMucGoiCuocService extends BaseService {        
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "DanhMucGoiCuoc";
    }
}





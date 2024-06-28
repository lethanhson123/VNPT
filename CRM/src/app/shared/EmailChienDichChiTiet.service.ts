import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { EmailChienDichChiTiet } from './EmailChienDichChiTiet.model';
@Injectable({
    providedIn: 'root'
})
export class EmailChienDichChiTietService extends BaseService {        
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "EmailChienDichChiTiet";
    }
}





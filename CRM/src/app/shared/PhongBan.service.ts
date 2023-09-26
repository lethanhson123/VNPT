import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class PhongBanService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "PhongBan";
    }    
}





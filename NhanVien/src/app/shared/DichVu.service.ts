import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class DichVuService extends BaseService{
   
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "DichVu";
    }    
}





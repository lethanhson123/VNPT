import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class DoanhNghiepService extends BaseService{
    displayColumnsSub: string[] = ['Code', 'Name']; 
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "DoanhNghiep";
    }    
}





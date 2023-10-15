import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class DichVuService extends BaseService{
    displayColumns: string[] = ['ParentID', 'Code', 'Name', 'Note', 'SortOrder', 'Active', 'Save']; 
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "DichVu";
    }    
}





import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class XaService extends BaseService{
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Xa";
        this.displayColumns = ['ParentID', 'Name', 'Note', 'SortOrder', 'Active', 'Save'];
    }    
}





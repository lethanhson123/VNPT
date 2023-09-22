import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class HuyenService extends BaseService {
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "Huyen";
        this.displayColumns = ['ParentID', 'Name', 'Note', 'SortOrder', 'Active', 'Save'];
    }
}





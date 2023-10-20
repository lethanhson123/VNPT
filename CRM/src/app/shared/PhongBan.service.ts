import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class PhongBanService extends BaseService{
    displayColumns: string[] = ['Code', 'Name', 'Note', 'SortOrder', 'Active'];
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "PhongBan";
    }    
    GetByIDStringAsync(ID: string) {
        let url = this.aPIURL + this.controller + '/GetByIDStringAsync';
        const params = new HttpParams()
            .set('ID', ID)
        return this.httpClient.get(url, { params }).toPromise();
    }
}





import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { EmailLichSu } from './EmailLichSu.model';

@Injectable({
    providedIn: 'root'
})

export class EmailLichSuService extends BaseService {       
    
    displayColumns: string[] = ['No', 'ID', 'Name', 'EmailFrom', 'EmailTo', 'IsSend', 'DateSend', 'IsRead', 'DateRead'];    
    list: EmailLichSu[] | undefined;
    formData!: EmailLichSu;

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "EmailLichSu";
    }
    GetBySearchString_BatDau_KetThucToListAsync() {        
        let url = this.aPIURL + this.controller + '/GetBySearchString_BatDau_KetThucToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
}







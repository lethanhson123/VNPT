import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { EmailChienDich } from './EmailChienDich.model';
@Injectable({
    providedIn: 'root'
})
export class EmailChienDichService extends BaseService {  
    
    displayColumns001: string[] = ['No', 'ParentID', 'Code', 'Name', 'Note', 'SortOrder', 'Active', 'Save'];
    list: EmailChienDich[] | undefined;
    list001: EmailChienDich[] | undefined;
    formData!: EmailChienDich;    

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "EmailChienDich";
    }
}





import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { EmailConfig } from './EmailConfig.model';
@Injectable({
    providedIn: 'root'
})
export class EmailConfigService extends BaseService {
    displayColumns: string[] = ['No', 'MasterEmailUser', 'MasterEmailPassword', 'MasterEmailDisplay', 'SMTPServer', 'SMTPPort', 'IsMailUsingSSL', 'IsMailBodyHtml', 'SortOrder', 'Active', 'Save'];    
    list: EmailConfig[] | undefined;
    formData!: EmailConfig;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "EmailConfig";
    }
}





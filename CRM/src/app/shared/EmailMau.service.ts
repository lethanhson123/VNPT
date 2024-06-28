import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BaseService } from './Base.service';
import { EmailMau } from './EmailMau.model';
@Injectable({
    providedIn: 'root'
})
export class EmailMauService extends BaseService {

    displayColumns001: string[] = ['No', 'ID', 'Name', 'SortOrder', 'Active', 'Save'];
    list: EmailMau[] | undefined;
    list001: EmailMau[] | undefined;
    formData!: EmailMau;
    FileToUpload: FileList

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "EmailMau";
    }
    SaveAndUploadFileAsync() {
        this.formData.Description = environment.TokenAPI;
        var lastUpdatedMembershipID = localStorage.getItem(environment.NhanVienID);
        if (lastUpdatedMembershipID) {
            this.formData.LastUpdatedMembershipID = Number(lastUpdatedMembershipID);
        }
        let url = this.aPIURL + this.controller + '/SaveAndUploadFileAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.formData));
        if (this.FileToUpload) {
            if (this.FileToUpload.length > 0) {
                for (var i = 0; i < this.FileToUpload.length; i++) {
                    formUpload.append('file[]', this.FileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload);
    }
}





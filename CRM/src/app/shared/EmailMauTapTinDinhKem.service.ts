import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BaseService } from './Base.service';
import { EmailMauTapTinDinhKem } from './EmailMauTapTinDinhKem.model';
@Injectable({
    providedIn: 'root'
})
export class EmailMauTapTinDinhKemService extends BaseService {



    FileToUpload: FileList

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "EmailMauTapTinDinhKem";
    }
    SaveAndUploadFilesAsync() {
        this.formData.ID = environment.InitializationNumber;
        this.formData.Description = environment.TokenAPI;
        var lastUpdatedMembershipID = localStorage.getItem(environment.NhanVienID);
        if (lastUpdatedMembershipID) {
            this.formData.LastUpdatedMembershipID = Number(lastUpdatedMembershipID);
        }
        let url = this.aPIURL + this.controller + '/SaveAndUploadFilesAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.formData));
        if (this.FileToUpload) {
            if (this.FileToUpload.length > 0) {
                for (var i = 0; i < this.FileToUpload.length; i++) {
                    formUpload.append('file[]', this.FileToUpload[i]);
                }
            }
        }
        console.log(this.formData);
        return this.httpClient.post(url, formUpload);
    }
}





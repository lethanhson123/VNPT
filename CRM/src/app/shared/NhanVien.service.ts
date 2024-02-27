import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './Base.service';
import { NhanVien } from './NhanVien.model';
import { environment } from 'src/environments/environment';
@Injectable({
    providedIn: 'root'
})
export class NhanVienService extends BaseService {
    displayColumns: string[] = ['No', 'ParentID', 'Name', 'DienThoai', 'Email', 'Active', 'Save'];
    displayColumns001: string[] = ['Code', 'Name', 'DienThoai'];
    list: NhanVien[] | undefined;
    formData!: NhanVien;
    formDataLogin!: NhanVien;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "NhanVien";
        this.GetLogin();
    }

    GetLogin() {
        this.formDataLogin = {
        }
        this.formDataLogin.Name = localStorage.getItem(environment.NhanVienName);
        this.formDataLogin.Email = localStorage.getItem(environment.NhanVienEmail);
        this.formDataLogin.Note = localStorage.getItem(environment.NhanVienNote);
        var lastUpdatedMembershipID = localStorage.getItem(environment.NhanVienID);
        if (lastUpdatedMembershipID) {
            this.formDataLogin.ID = Number(lastUpdatedMembershipID);
        }
    }
    SaveAndUploadFileAsync(formData: NhanVien, fileToUpload: FileList) {
        formData.Description = environment.TokenAPI;
        var lastUpdatedMembershipID = localStorage.getItem(environment.NhanVienID);
        if (lastUpdatedMembershipID) {
            formData.LastUpdatedMembershipID = Number(lastUpdatedMembershipID);
        }
        let url = this.aPIURL + this.controller + '/SaveAndUploadFileAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(formData));
        if (fileToUpload) {
            if (fileToUpload.length > 0) {
                for (var i = 0; i < fileToUpload.length; i++) {
                    formUpload.append('file[]', fileToUpload[i]);
                }
            }
        }
        return this.httpClient.post(url, formUpload);
    }
    GetByIDStringAsync(ID: string) {
        this.BaseParameter.IDString = ID;
        let url = this.aPIURL + this.controller + '/GetByIDStringAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
}





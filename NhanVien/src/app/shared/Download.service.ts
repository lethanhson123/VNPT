import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BaseParameter } from './BaseParameter.model';

@Injectable({
    providedIn: 'root'
})
export class DownloadService {
    baseParameter!: BaseParameter;
    aPIURL: string = environment.APIUploadURL;
    controller: string = "Download";

    IPAddress: string = environment.InitializationString;


    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
        this.GetIPAddress();
    }
    initializationFormData() {
        this.baseParameter = {
        };
    }
    GetRandomColor(count) {
        var arr = [];
        for (var i = 0; i < count; i++) {
            var letters = '0123456789ABCDEF'.split('');
            var color = '#';
            for (var x = 0; x < 6; x++) {
                color += letters[Math.floor(Math.random() * 16)];
            }
        }
        return color;
    }
    GetIPAddress() {
        // if (this.IPAddress.length == 0) {
        //     this.httpClient.get(environment.IPRegistry).toPromise().then(res => {
        //         this.IPAddress = res["ip"];
        //     });
        // }      

        return this.httpClient.get(environment.IPRegistry).toPromise();
    }
    ExportToChucQuyTrinhSanXuatToExcelAsync() {
        let url = this.aPIURL + this.controller + '/ExportToChucQuyTrinhSanXuatToExcelAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }

    ExportDanhMucNguyenVatLieuToExcelAsync() {
        let url = this.aPIURL + this.controller + '/ExportDanhMucNguyenVatLieuToExcelAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ExportDanhMucNguyenVatLieuToHTMLAsync() {
        let url = this.aPIURL + this.controller + '/ExportDanhMucNguyenVatLieuToHTMLAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ExportHopTacXaByIDToHTMLAsync() {
        var lastUpdatedMembershipID = localStorage.getItem(environment.ThanhVienID);
        if (lastUpdatedMembershipID) {
            this.baseParameter.LastUpdatedMembershipID = Number(lastUpdatedMembershipID);
        }
        let url = this.aPIURL + this.controller + '/ExportHopTacXaByIDToHTMLAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.baseParameter));
        return this.httpClient.post(url, formUpload);
    }


}


import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './Base.service';
import { DoanhNghiep } from './DoanhNghiep.model';
@Injectable({
    providedIn: 'root'
})
export class DoanhNghiepService extends BaseService{
    displayColumns: string[] = ['No', 'Name', 'Code', 'UserName', 'Description']; 
    displayColumns001: string[] = ['No', 'Name', 'Code', 'DienThoai', 'Email']; 
    displayColumns002: string[] = ['No', 'HuyenName', 'XaName', 'Code', 'Name', 'DienThoai', 'Email', 'NgayCap', 'NhanVienName']; 
    displayColumnsSub: string[] = ['Code', 'Name', 'DienThoai']; 
    displayColumnsNhanVien: string[] = ['Code', 'Name', 'HuyenID', 'XaID', 'NhanVienID'];
    displayColumnsPhongBan: string[] = ['Code', 'Name', 'HuyenID', 'XaID', 'PhongBanID'];
    list: DoanhNghiep[] | undefined;        
    listSearch: DoanhNghiep[] | undefined;   
    listView: DoanhNghiep[] | undefined;      
    formData!: DoanhNghiep;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "DoanhNghiep";
    }    
    GetMaSoThueKhongTonTaiToListAsync() {
        let url = this.aPIURL + this.controller + '/GetMaSoThueKhongTonTaiToListAsync';
        const formUpload: FormData = new FormData(); 
        formUpload.append('data', JSON.stringify(this.BaseParameter));              
        return this.httpClient.post(url, formUpload);
    }
    GetBySearchStringToListAsync(searchString: string) {
        this.BaseParameter.SearchString = searchString;
        let url = this.aPIURL + this.controller + '/GetBySearchStringToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));      
        return this.httpClient.post(url, formUpload);
    }
    GetByHuyenIDAndXaIDOrSearchStringToListAsync(huyenID: number, xaID: number, searchString: string) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.XaID = xaID;
        this.BaseParameter.SearchString = searchString;
        let url = this.aPIURL + this.controller + '/GetByHuyenIDAndXaIDOrSearchStringToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));       
        return this.httpClient.post(url, formUpload);
    }
    GetCAByHuyenIDAndXaIDOrSearchStringToListAsync(huyenID: number, xaID: number, searchString: string) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.XaID = xaID;
        this.BaseParameter.SearchString = searchString;
        let url = this.aPIURL + this.controller + '/GetCAByHuyenIDAndXaIDOrSearchStringToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));           
        return this.httpClient.post(url, formUpload);
    }
    GetByNhanVienIDOrSearchStringToListAsync(nhanVienID: number, searchString: string) {
        this.BaseParameter.NhanVienID = nhanVienID;
        this.BaseParameter.SearchString = searchString;
        let url = this.aPIURL + this.controller + '/GetByNhanVienIDOrSearchStringToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));              
        return this.httpClient.post(url, formUpload);
    }
    GetByPhongBanIDOrSearchStringToListAsync(phongBanID: number, searchString: string) {
        this.BaseParameter.PhongBanID = phongBanID;
        this.BaseParameter.SearchString = searchString;
        let url = this.aPIURL + this.controller + '/GetByPhongBanIDOrSearchStringToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));      
        return this.httpClient.post(url, formUpload);
    }
    GetByIDStringAsync(ID: string) {
        this.BaseParameter.IDString = ID;        
        let url = this.aPIURL + this.controller + '/GetByIDStringAsync';
        const formUpload: FormData = new FormData();                  
        formUpload.append('data', JSON.stringify(this.BaseParameter));           
        return this.httpClient.post(url, formUpload);
    }
    GetSQLBySearchString_HuyenIDToListTranferAsync(searchString: string, huyenID: number) {
        this.BaseParameter.HuyenID = huyenID;
        this.BaseParameter.SearchString = searchString;
        let url = this.aPIURL + this.controller + '/GetSQLBySearchString_HuyenIDToListTranferAsync';
        const formUpload: FormData = new FormData();                  
        formUpload.append('data', JSON.stringify(this.BaseParameter));           
        return this.httpClient.post(url, formUpload);
    }
}





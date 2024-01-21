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
        return this.httpClient.post(url, formUpload);
    }
    GetBySearchStringToListAsync(searchString: string) {
        let url = this.aPIURL + this.controller + '/GetBySearchStringToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('searchString', JSON.stringify(searchString));        
        return this.httpClient.post(url, formUpload);
    }
    GetByHuyenIDAndXaIDOrSearchStringToListAsync(huyenID: number, xaID: number, searchString: string) {
        let url = this.aPIURL + this.controller + '/GetByHuyenIDAndXaIDOrSearchStringToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('huyenID', JSON.stringify(huyenID));
        formUpload.append('xaID', JSON.stringify(xaID));
        formUpload.append('searchString', JSON.stringify(searchString));        
        return this.httpClient.post(url, formUpload);
    }
    GetCAByHuyenIDAndXaIDOrSearchStringToListAsync(huyenID: number, xaID: number, searchString: string) {
        let url = this.aPIURL + this.controller + '/GetCAByHuyenIDAndXaIDOrSearchStringToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('huyenID', JSON.stringify(huyenID));
        formUpload.append('xaID', JSON.stringify(xaID));
        formUpload.append('searchString', JSON.stringify(searchString));        
        return this.httpClient.post(url, formUpload);
    }
    GetByNhanVienIDOrSearchStringToListAsync(nhanVienID: number, searchString: string) {
        let url = this.aPIURL + this.controller + '/GetByNhanVienIDOrSearchStringToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('nhanVienID', JSON.stringify(nhanVienID));        
        formUpload.append('searchString', JSON.stringify(searchString));        
        return this.httpClient.post(url, formUpload);
    }
    GetByPhongBanIDOrSearchStringToListAsync(phongBanID: number, searchString: string) {
        let url = this.aPIURL + this.controller + '/GetByPhongBanIDOrSearchStringToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('phongBanID', JSON.stringify(phongBanID));        
        formUpload.append('searchString', JSON.stringify(searchString));        
        return this.httpClient.post(url, formUpload);
    }
    GetByIDStringAsync(ID: string) {
        let url = this.aPIURL + this.controller + '/GetByIDStringAsync';
        const params = new HttpParams()
            .set('ID', ID)
        return this.httpClient.get(url, { params }).toPromise();
    }
    GetSQLBySearchString_HuyenIDToListTranferAsync(searchString: string, huyenID: number) {
        let url = this.aPIURL + this.controller + '/GetSQLBySearchString_HuyenIDToListTranferAsync';
        const formUpload: FormData = new FormData();                  
        formUpload.append('searchString', JSON.stringify(searchString));        
        formUpload.append('huyenID', JSON.stringify(huyenID));      
        return this.httpClient.post(url, formUpload);
    }
}





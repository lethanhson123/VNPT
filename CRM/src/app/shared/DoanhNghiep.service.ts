import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './Base.service';
import { DoanhNghiep } from './DoanhNghiep.model';
@Injectable({
    providedIn: 'root'
})
export class DoanhNghiepService extends BaseService{
    displayColumnsSub: string[] = ['Code', 'Name', 'DienThoai']; 
    displayColumnsNhanVien: string[] = ['Code', 'Name', 'HuyenID', 'XaID', 'NhanVienID'];
    displayColumnsPhongBan: string[] = ['Code', 'Name', 'HuyenID', 'XaID', 'PhongBanID'];
    list: DoanhNghiep[] | undefined;        
    listSearch: DoanhNghiep[] | undefined;        
    formData!: DoanhNghiep;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "DoanhNghiep";
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
}





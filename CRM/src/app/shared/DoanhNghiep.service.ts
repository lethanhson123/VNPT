import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './Base.service';
import { DoanhNghiep } from './DoanhNghiep.model';
@Injectable({
    providedIn: 'root'
})
export class DoanhNghiepService extends BaseService{
    displayColumnsSub: string[] = ['Code', 'Name', 'DienThoai']; 
    list: DoanhNghiep[] | undefined;        
    formData!: DoanhNghiep;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "DoanhNghiep";
    }    
    GetByHuyenIDAndXaIDOrSearchStringToListAsync(huyenID: number, xaID: number, searchString: string) {
        let url = this.aPIURL + this.controller + '/GetByHuyenIDAndXaIDOrSearchStringToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('huyenID', JSON.stringify(huyenID));
        formUpload.append('xaID', JSON.stringify(xaID));
        formUpload.append('searchString', searchString);        
        return this.httpClient.post(url, formUpload);
    }
    GetByIDStringAsync(ID: string) {
        let url = this.aPIURL + this.controller + '/GetByIDStringAsync';
        const params = new HttpParams()
            .set('ID', ID)
        return this.httpClient.get(url, { params }).toPromise();
    }
}





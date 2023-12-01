import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { DichVuChiTieu } from 'src/app/shared/DichVuChiTieu.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class DichVuChiTieuService extends BaseService {
    displayColumns: string[] = ['Nam', 'PhongBanID', 'PhongBanPhatTrien', 'PhongBanGiaHan','SmartCAPhongBanPhatTrien', 'SmartCAPhongBanGiaHan', 'NhanVienID', 'PhatTrien', 'GiaHan','SmartCAPhatTrien', 'SmartCAGiaHan', 'Save']; 
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "DichVuChiTieu";
    }
    GetByNam_ThangToListAsync(nam: number, thang: number) {
        let url = this.aPIURL + this.controller + '/GetByNam_ThangToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('nam', JSON.stringify(nam));        
        formUpload.append('thang', JSON.stringify(thang));        
        return this.httpClient.post(url, formUpload);
    }
}


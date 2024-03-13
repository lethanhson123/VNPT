import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { DichVuChiTieu } from 'src/app/shared/DichVuChiTieu.model';
import { BaseService } from './Base.service';
@Injectable({
    providedIn: 'root'
})
export class DichVuChiTieuService extends BaseService {
    displayColumns: string[] = ['Nam', 'PhongBanID', 'PhongBanPhatTrien', 'PhongBanGiaHan', 'SmartCAPhongBanPhatTrien', 'SmartCAPhongBanGiaHan', 'CACapBuPhongBan', 'SmartCACapBuPhongBan', 'PhongBanDoanhThu', 'NhanVienID', 'PhatTrien', 'GiaHan', 'SmartCAPhatTrien', 'SmartCAGiaHan', 'CACapBu','SmartCACapBu', 'DoanhThu', 'Save'];
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "DichVuChiTieu";
    }
    GetByNam_ThangToListAsync(nam: number, thang: number) {
        this.BaseParameter.Year = nam;
        this.BaseParameter.Month = thang;
        let url = this.aPIURL + this.controller + '/GetByNam_ThangToListAsync';
        const formUpload: FormData = new FormData();
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
}


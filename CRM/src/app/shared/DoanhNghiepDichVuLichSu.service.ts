import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { DoanhNghiepDichVuLichSu } from './DoanhNghiepDichVuLichSu.model';
@Injectable({
    providedIn: 'root'
})
export class DoanhNghiepDichVuLichSuService extends BaseService{
    displayColumns: string[] = ['DichVuID', 'Year', 'Month', 'GiaTien','Note']; 
    list: DoanhNghiepDichVuLichSu[] | undefined;        
    formData!: DoanhNghiepDichVuLichSu;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "DoanhNghiepDichVuLichSu";
    }    
    GetByDoanhNghiepIDAndYearAndMonthToListAsync(doanhNghiepID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/GetByDoanhNghiepIDAndYearAndMonthToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('doanhNghiepID', JSON.stringify(doanhNghiepID));
        formUpload.append('year', JSON.stringify(year));
        formUpload.append('month', JSON.stringify(month));        
        return this.httpClient.post(url, formUpload);
    }
}





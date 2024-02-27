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
        this.BaseParameter.DoanhNghiepID = doanhNghiepID;      
        this.BaseParameter.Year = year;      
        this.BaseParameter.Month = month;      
        let url = this.aPIURL + this.controller + '/GetByDoanhNghiepIDAndYearAndMonthToListAsync';
        const formUpload: FormData = new FormData();        
        formUpload.append('data', JSON.stringify(this.BaseParameter));                  
        return this.httpClient.post(url, formUpload);
    }
}





import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './Base.service';
import { DoanhNghiepDichVu } from './DoanhNghiepDichVu.model';
@Injectable({
    providedIn: 'root'
})
export class DoanhNghiepDichVuService extends BaseService{
    
    List: DoanhNghiepDichVu[] | undefined;
    ListFilter: DoanhNghiepDichVu[] | undefined;
    FormData!: DoanhNghiepDichVu;

    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.Controller = "DoanhNghiepDichVu";
    }
}





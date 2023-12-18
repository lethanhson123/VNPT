import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { DanhMucChucNang } from 'src/app/shared/DanhMucChucNang.model';
import { BaseService } from './Base.service';

@Injectable({
    providedIn: 'root'
})
export class DanhMucChucNangService extends BaseService {
    displayColumns: string[] = ['ParentID', 'Name', 'Code', 'Note', 'SortOrder', 'Active', 'Save'];
    listChild: DanhMucChucNang[] | undefined;    
    listParent: DanhMucChucNang[] | undefined;
    listParentSave: DanhMucChucNang[] | undefined;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "DanhMucChucNang";
    }
    GetByThanhVienIDToListAsync() {
        let thanhVienIDString = localStorage.getItem(environment.ThanhVienID);
        if (thanhVienIDString) {
            let thanhVienID = Number(thanhVienIDString);
            let url = this.aPIURL + this.controller + '/GetByThanhVienIDToListAsync';
            const formUpload: FormData = new FormData();
            formUpload.append('thanhVienID', JSON.stringify(thanhVienID));
            return this.httpClient.post(url, formUpload);
        }
    }
}


import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { YearMonth } from './YearMonth.model';
import { BaseParameter } from './BaseParameter.model';
@Injectable({
    providedIn: 'root'
})
export class DownloadService {
    listYear: YearMonth[] | undefined;
    listMonth: YearMonth[] | undefined;
    aPIURL: string = environment.APIUploadURL;
    controller: string = "Download";
    BaseParameter!: BaseParameter;
    constructor(private httpClient: HttpClient) {
        this.initializationFormData();
    }
    initializationFormData() {
        this.BaseParameter = {
            Token: environment.TokenAPI,
        };
    }
    GetRandomColor(count) {
        var arr = [];
        for (var i = 0; i < count; i++) {
            var letters = '0123456789ABCDEF'.split('');
            var color = '#';
            for (var x = 0; x < 6; x++) {
                color += letters[Math.floor(Math.random() * 16)];
            }
        }
        return color;
    }
    GetMonthToList() {
        let url = this.aPIURL + this.controller + '/GetMonthToList';
        return this.httpClient.get(url).toPromise();
    }
    GetYearToList() {
        let url = this.aPIURL + this.controller + '/GetYearToList';        
        return this.httpClient.get(url).toPromise();
    }
    Report0004ToExcelAsync(huyenID: number, xaID: number, searchString: string) {
        let url = this.aPIURL + this.controller + '/Report0004ToExcelAsync';
        const formUpload: FormData = new FormData();       
        this.BaseParameter.HuyenID=huyenID;
        this.BaseParameter.XaID=xaID;
        this.BaseParameter.SearchString=searchString;        
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT001ToExcelAsync(huyenID: number, xaID: number, searchString: string, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportVNPT001ToExcelAsync';
        const formUpload: FormData = new FormData();
   
        this.BaseParameter.HuyenID=huyenID;
        this.BaseParameter.XaID=xaID;
        this.BaseParameter.SearchString=searchString;        
        this.BaseParameter.Year=year;   
        this.BaseParameter.Month=month;   
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT003ToExcelAsync(huyenID: number, xaID: number, searchString: string, dichVuID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportVNPT003ToExcelAsync';
        const formUpload: FormData = new FormData();
      

        this.BaseParameter.HuyenID=huyenID;
        this.BaseParameter.XaID=xaID;
        this.BaseParameter.SearchString=searchString;        
        this.BaseParameter.DichVuID=dichVuID;   
        this.BaseParameter.Year=year;   
        this.BaseParameter.Month=month;   
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT004ToExcelAsync(phongBanID: number, year: number) {
        let url = this.aPIURL + this.controller + '/ReportVNPT004ToExcelAsync';
        const formUpload: FormData = new FormData();
      
        this.BaseParameter.PhongBanID=phongBanID;       
        this.BaseParameter.Year=year;          
        formUpload.append('data', JSON.stringify(this.BaseParameter));

        return this.httpClient.post(url, formUpload);
    }
    ReportVNPT005ToExcelAsync(nhanVienID: number, year: number) {
        let url = this.aPIURL + this.controller + '/ReportVNPT005ToExcelAsync';
        const formUpload: FormData = new FormData();
    

        this.BaseParameter.NhanVienID=nhanVienID;       
        this.BaseParameter.Year=year;          
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    DoanhNghiepMaSoThueKhongTonTaiToExcelAsync() {
        let url = this.aPIURL + this.controller + '/DoanhNghiepMaSoThueKhongTonTaiToExcelAsync';
        const formUpload: FormData = new FormData();        
        return this.httpClient.post(url, formUpload);
    }
    ReportCA001ToExcelAsync(huyenID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportCA001ToExcelAsync';
        const formUpload: FormData = new FormData();    

        this.BaseParameter.HuyenID=huyenID;      
        this.BaseParameter.Year=year;   
        this.BaseParameter.Month=month;   
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA002ToExcelAsync(huyenID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportCA002ToExcelAsync';
        const formUpload: FormData = new FormData();
        this.BaseParameter.HuyenID=huyenID;      
        this.BaseParameter.Year=year;   
        this.BaseParameter.Month=month;   
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA003ToExcelAsync(huyenID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportCA003ToExcelAsync';
        const formUpload: FormData = new FormData();
        this.BaseParameter.HuyenID=huyenID;      
        this.BaseParameter.Year=year;   
        this.BaseParameter.Month=month;   
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA004ToExcelAsync(huyenID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportCA004ToExcelAsync';
        const formUpload: FormData = new FormData();
        this.BaseParameter.HuyenID=huyenID;      
        this.BaseParameter.Year=year;   
        this.BaseParameter.Month=month;   
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA005ToExcelAsync(huyenID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportCA005ToExcelAsync';
        const formUpload: FormData = new FormData();
        this.BaseParameter.HuyenID=huyenID;      
        this.BaseParameter.Year=year;   
        this.BaseParameter.Month=month;   
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA006ToExcelAsync(huyenID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportCA006ToExcelAsync';
        const formUpload: FormData = new FormData();
        this.BaseParameter.HuyenID=huyenID;      
        this.BaseParameter.Year=year;   
        this.BaseParameter.Month=month;   
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA007ToExcelAsync(huyenID: number, year: number, month: number) {
        let url = this.aPIURL + this.controller + '/ReportCA007ToExcelAsync';
        const formUpload: FormData = new FormData();
        this.BaseParameter.HuyenID=huyenID;      
        this.BaseParameter.Year=year;   
        this.BaseParameter.Month=month;   
        formUpload.append('data', JSON.stringify(this.BaseParameter));
        return this.httpClient.post(url, formUpload);
    }
    ReportCA101ToExcelAsync(huyenID: number, year: number, month: number, nhanVienID: number) {
        let url = this.aPIURL + this.controller + '/ReportCA101ToExcelAsync';
        const formUpload: FormData = new FormData();
        this.BaseParameter.HuyenID=huyenID;      
        this.BaseParameter.Year=year;   
        this.BaseParameter.Month=month;   
        this.BaseParameter.NhanVienID=nhanVienID;   
        formUpload.append('data', JSON.stringify(this.BaseParameter));      
        return this.httpClient.post(url, formUpload);
    }
    ReportCA401ToExcelAsync(huyenID: number, year: number, month: number, nhanVienID: number, isSmartCA: boolean) {
        let url = this.aPIURL + this.controller + '/ReportCA401ToExcelAsync';
        const formUpload: FormData = new FormData();
    
        this.BaseParameter.HuyenID=huyenID;      
        this.BaseParameter.Year=year;   
        this.BaseParameter.Month=month;   
        this.BaseParameter.NhanVienID=nhanVienID;   
        this.BaseParameter.IsSmartCA=isSmartCA;  
        formUpload.append('data', JSON.stringify(this.BaseParameter));      
        return this.httpClient.post(url, formUpload);
    }
    ReportCA102ToExcelAsync(huyenID: number, year: number, month: number, nhanVienID: number) {
        let url = this.aPIURL + this.controller + '/ReportCA102ToExcelAsync';
        const formUpload: FormData = new FormData();

        this.BaseParameter.HuyenID=huyenID;      
        this.BaseParameter.Year=year;   
        this.BaseParameter.Month=month;   
        this.BaseParameter.NhanVienID=nhanVienID;              
        formUpload.append('data', JSON.stringify(this.BaseParameter));         
        return this.httpClient.post(url, formUpload);
    }
    ReportCA402ToExcelAsync(huyenID: number, year: number, month: number, nhanVienID: number, isSmartCA: boolean) {
        let url = this.aPIURL + this.controller + '/ReportCA402ToExcelAsync';
        const formUpload: FormData = new FormData();
        this.BaseParameter.HuyenID=huyenID;      
        this.BaseParameter.Year=year;   
        this.BaseParameter.Month=month;   
        this.BaseParameter.NhanVienID=nhanVienID;   
        this.BaseParameter.IsSmartCA=isSmartCA;  
        formUpload.append('data', JSON.stringify(this.BaseParameter));            
        return this.httpClient.post(url, formUpload);
    }
    ReportCA105ToExcelAsync(huyenID: number, year: number, month: number, nhanVienID: number, hetHan: number) {
        let url = this.aPIURL + this.controller + '/ReportCA105ToExcelAsync';
        const formUpload: FormData = new FormData();
        this.BaseParameter.HuyenID=huyenID;      
        this.BaseParameter.Year=year;   
        this.BaseParameter.Month=month;   
        this.BaseParameter.NhanVienID=nhanVienID;   
        this.BaseParameter.HetHan=hetHan;  
        formUpload.append('data', JSON.stringify(this.BaseParameter));      
        return this.httpClient.post(url, formUpload);
    }
    ReportCA405ToExcelAsync(huyenID: number, year: number, month: number, nhanVienID: number, hetHan: number, isSmartCA: boolean) {
        let url = this.aPIURL + this.controller + '/ReportCA405ToExcelAsync';
        const formUpload: FormData = new FormData();
        this.BaseParameter.HuyenID=huyenID;      
        this.BaseParameter.Year=year;   
        this.BaseParameter.Month=month;   
        this.BaseParameter.NhanVienID=nhanVienID;   
        this.BaseParameter.HetHan=hetHan;  
        this.BaseParameter.IsSmartCA=isSmartCA;  
        formUpload.append('data', JSON.stringify(this.BaseParameter));    
        return this.httpClient.post(url, formUpload);
    }
    ReportCA108ToExcelAsync(huyenID: number, year: number, month: number, nhanVienID: number, isKetLuan: boolean) {
        let url = this.aPIURL + this.controller + '/ReportCA108ToExcelAsync';
        const formUpload: FormData = new FormData();
        this.BaseParameter.HuyenID=huyenID;      
        this.BaseParameter.Year=year;   
        this.BaseParameter.Month=month;   
        this.BaseParameter.NhanVienID=nhanVienID;           
        this.BaseParameter.IsKetLuan=isKetLuan;  
        formUpload.append('data', JSON.stringify(this.BaseParameter));    
        return this.httpClient.post(url, formUpload);
    }
    ReportCA408ToExcelAsync(huyenID: number, year: number, month: number, nhanVienID: number, isKetLuan: boolean, isSmartCA: boolean) {
        let url = this.aPIURL + this.controller + '/ReportCA408ToExcelAsync';
        const formUpload: FormData = new FormData();
        this.BaseParameter.HuyenID=huyenID;      
        this.BaseParameter.Year=year;   
        this.BaseParameter.Month=month;   
        this.BaseParameter.NhanVienID=nhanVienID;           
        this.BaseParameter.IsKetLuan=isKetLuan;  
        this.BaseParameter.IsSmartCA=isSmartCA;  
        formUpload.append('data', JSON.stringify(this.BaseParameter));    
        return this.httpClient.post(url, formUpload);
    }
    ReportCA203_204_206_207ToHTMLAsync(year: number, month: number) {
        
        let url = this.aPIURL + this.controller + '/ReportCA203_204_206_207ToHTMLAsync';
        const formUpload: FormData = new FormData();        
        this.BaseParameter.Year=year;   
        this.BaseParameter.Month=month;        
        formUpload.append('data', JSON.stringify(this.BaseParameter));    
        return this.httpClient.post(url, formUpload);
    }
    ReportCA503_504_506_507ToHTMLAsync(year: number, month: number, isSmartCA: boolean) {
        let url = this.aPIURL + this.controller + '/ReportCA503_504_506_507ToHTMLAsync';
        const formUpload: FormData = new FormData();        
        this.BaseParameter.Year=year;   
        this.BaseParameter.Month=month;        
        this.BaseParameter.IsSmartCA=isSmartCA;  
        formUpload.append('data', JSON.stringify(this.BaseParameter));     
        return this.httpClient.post(url, formUpload);
    }
}


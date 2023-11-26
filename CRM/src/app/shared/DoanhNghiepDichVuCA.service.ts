import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BaseService } from './Base.service';
import { DoanhNghiepDichVuCA } from './DoanhNghiepDichVuCA.model';
@Injectable({
    providedIn: 'root'
})
export class DoanhNghiepDichVuCAService extends BaseService{
    displayColumns: string[] = ['NhanVienID','DichVuID','NgayKyHopDong', 'Code', 'MaThueBao', 'GiaTien', 'SoThang', 'Note', 'SortOrder', 'Active', 'Save']; 
    list: DoanhNghiepDichVuCA[] | undefined;        
    formData!: DoanhNghiepDichVuCA;
    constructor(public httpClient: HttpClient) {
        super(httpClient);
        this.controller = "DoanhNghiepDichVuCA";
    }    
    SaveAndUploadFilesAsync(formData: DoanhNghiepDichVuCA, fileHopDong: File, fileDonXinCapChungThuSo: File, fileGiayPhepKinhDoanh: File, fileBienBanNghiemThu: File, fileHoaDon: File, fileCCCD: File) {
        var lastUpdatedMembershipID = localStorage.getItem(environment.NhanVienID);
        if (lastUpdatedMembershipID) {
            formData.LastUpdatedMembershipID = Number(lastUpdatedMembershipID);
        }
        let url = this.aPIURL + this.controller + '/SaveAndUploadFilesAsync';
        const formUpload: FormData = new FormData();
        if (fileHopDong == null) {
            fileHopDong = new File(["fileHopDong"], "fileHopDong.txt", {
                type: "text/plain",
            });
        }
        if (fileDonXinCapChungThuSo == null) {
            fileDonXinCapChungThuSo = new File(["fileDonXinCapChungThuSo"], "fileDonXinCapChungThuSo.txt", {
                type: "text/plain",
            });
        }
        if (fileGiayPhepKinhDoanh == null) {
            fileGiayPhepKinhDoanh = new File(["fileGiayPhepKinhDoanh"], "fileGiayPhepKinhDoanh.txt", {
                type: "text/plain",
            });
        }
        if (fileBienBanNghiemThu == null) {
            fileBienBanNghiemThu = new File(["fileBienBanNghiemThu"], "fileBienBanNghiemThu.txt", {
                type: "text/plain",
            });
        }
        if (fileHoaDon == null) {
            fileHoaDon = new File(["fileHoaDon"], "fileHoaDon.txt", {
                type: "text/plain",
            });
        }
        if (fileCCCD == null) {
            fileCCCD = new File(["fileCCCD"], "fileCCCD.txt", {
                type: "text/plain",
            });
        }
        formUpload.append('data', JSON.stringify(formData));
        formUpload.append('file[]', fileHopDong);
        formUpload.append('file[]', fileDonXinCapChungThuSo);        
        formUpload.append('file[]', fileGiayPhepKinhDoanh);
        formUpload.append('file[]', fileBienBanNghiemThu);
        formUpload.append('file[]', fileHoaDon);        
        formUpload.append('file[]', fileCCCD);
        return this.httpClient.post(url, formUpload);
    }
}





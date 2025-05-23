import { Base } from "./Base.model";

export class DoanhNghiep extends Base{   
    DienThoai?: string;     
    Email?: string;     
    DiaChi?: string;     
    Website?: string;     
    NganhNgheKinhDoanh?: string;         
    HuyenID?: number; 
    XaID?: number; 
    NganhNgheKinhDoanhChinhID?: number;
    LoaiTrangThaiID?: number;
    LoaiDoanhNghiepID?: number;    
    NhanVienID?: number;   
    PhongBanID?: number;  
    VonDieuLe?: number;
    SoLuongLaoDong?: number;
    NgayCap?: Date; 
    NgayDangKyThayDoi?: Date; 
    KHACHHANG_ID?: string;  
    CodeCA?: string;  
    UserName?: string;  
    HuyenName?: string;  
    XaName?: string;  
    NhanVienName?: string;  
}

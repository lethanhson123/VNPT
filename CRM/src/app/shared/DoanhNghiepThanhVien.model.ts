import { Base } from "./Base.model";

export class DoanhNghiepThanhVien extends Base{  
    LoaiDoanhNghiepThanhVienID?: number;     
    DienThoai?: string;     
    Email?: string;     
    CCCD?: string;           
    CCCD_NgayCap?: Date;     
    CCCD_NoiCap?: string;     
    NgaySinh?: Date;     
}

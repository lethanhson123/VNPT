import { Base } from "./Base.model";

export class DoanhNghiepDichVu extends Base{  
    NhanVienID?: number;           
    DichVuID?: number;    
    NgayKyHopDong?: Date;    
    GiaTien?: number;
    SoThang?: number;
}

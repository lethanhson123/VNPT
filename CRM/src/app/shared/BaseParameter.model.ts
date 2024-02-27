import { Base } from "./Base.model";
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

export class BaseParameter extends Base{
    IsSmartCA?: boolean;
    IsKetLuan?: boolean;
    IDString?: string; 
    Token?: string;
    APIMessage?: string;
    SearchString?: string;   
    Year?: number;    
    Month?: number;    
    HetHan?: number;    
    HuyenID?: number;    
    XaID?: number;    
    NhanVienID?: number;    
    PhongBanID?: number;    
    DoanhNghiepID?: number;    
    LoaiDichVuID?: number;    
    DichVuID?: number;    
}

import { Base } from "./Base.model";
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

export class BaseParameter extends Base{
    MatSort?: MatSort;    
    MatPaginator?: MatPaginator;    
    SearchString?: string;
    Token?: string;    
    HuyenID?: number;        
    XaID?: number;        
    NhanVienID?: number;     
}

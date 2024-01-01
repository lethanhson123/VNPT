import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { NhanVien } from 'src/app/shared/NhanVien.model';
import { NhanVienService } from 'src/app/shared/NhanVien.service';
import { NhanVienMenu } from 'src/app/shared/NhanVienMenu.model';
import { NhanVienMenuService } from 'src/app/shared/NhanVienMenu.service';
import { Menu } from 'src/app/shared/Menu.model';
import { MenuService } from 'src/app/shared/Menu.service';

@Component({
  selector: 'app-phan-quyen-menu',
  templateUrl: './phan-quyen-menu.component.html',
  styleUrls: ['./phan-quyen-menu.component.css']
})
export class PhanQuyenMenuComponent implements OnInit {

  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  nhanVienID: number = environment.InitializationNumber;

  constructor(
    public NhanVienService: NhanVienService,  
    public NhanVienMenuService: NhanVienMenuService,    
    public MenuService: MenuService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.GetNhanVienToListAsync();
    this.GetMenuToListAsync();
  }
  GetNhanVienToListAsync() {
    this.isShowLoading = true;
    this.NhanVienService.GetAllToListAsync().subscribe(
      res => {
        this.NhanVienService.list = (res as NhanVien[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  GetMenuToListAsync() {
    this.isShowLoading = true;
    this.MenuService.GetAllToListAsync().subscribe(
      res => {
        this.MenuService.list = (res as Menu[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));        
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  GetNhanVienMenuToListAsync() {
    this.isShowLoading = true;
    this.NhanVienMenuService.GetByParentIDToListAsync(this.nhanVienID).subscribe(
      res => {
        this.NhanVienMenuService.list = (res as NhanVienMenu[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onNhanVienMenuActiveChange(element: NhanVienMenu) {
    this.NhanVienMenuService.SaveAsync(element).subscribe(
      res => {
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
}

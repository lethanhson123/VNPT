import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
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

  dataSourceMenu: MatTableDataSource<any>;
  @ViewChild('sortMenu') sortMenu: MatSort;
  @ViewChild('paginatorMenu') paginatorMenu: MatPaginator;

  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  queryString: string = environment.InitializationString;
  nhanVienID: number = environment.InitializationNumber;
  NhanVienMenuActiveAll: boolean = false;

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

  MenuGetToList() {
    this.isShowLoading = true;
    this.MenuService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.MenuService.list = (res as Menu[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.MenuService.list001 = this.MenuService.list.filter(item => item.ID > 0);
        this.dataSourceMenu = new MatTableDataSource(this.MenuService.list);
        this.dataSourceMenu.sort = this.sortMenu;
        this.dataSourceMenu.paginator = this.paginatorMenu;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchMenu() {
    if (this.searchString.length > 0) {
      this.dataSourceMenu.filter = this.searchString.toLowerCase();
    }
    else {
      this.MenuGetToList();
    }
  }
  onSaveMenu(element: Menu) {
    this.MenuService.SaveAsync(element).subscribe(
      res => {
        this.onSearchMenu();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDeleteMenu(element: Menu) {
    if (confirm(environment.DeleteConfirm)) {
      this.MenuService.RemoveAsync(element.ID).subscribe(
        res => {
          this.onSearchMenu();
          this.NotificationService.warn(environment.DeleteSuccess);
        },
        err => {
          this.NotificationService.warn(environment.DeleteNotSuccess);
        }
      );
    }
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

  NhanVienMenuActiveAllChange() {
    this.isShowLoading = true;
    for (let i = 0; i < this.NhanVienMenuService.list.length; i++) {
      this.isShowLoading = true;
      this.NhanVienMenuService.list[i].Active = this.NhanVienMenuActiveAll;      
    }    
    this.NhanVienMenuService.SaveListAsync(this.NhanVienMenuService.list).subscribe(
      res => {      
        this.isShowLoading = false;   
        this.NotificationService.warn(environment.SaveSuccess); 
      },
      err => {
        this.isShowLoading = false;
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
}

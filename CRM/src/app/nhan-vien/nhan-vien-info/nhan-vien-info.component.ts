import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { NgForm } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { NhanVien } from 'src/app/shared/NhanVien.model';
import { NhanVienService } from 'src/app/shared/NhanVien.service';
import { NhanVienKhuVuc } from 'src/app/shared/NhanVienKhuVuc.model';
import { NhanVienKhuVucService } from 'src/app/shared/NhanVienKhuVuc.service';
import { NhanVienTaiKhoan } from 'src/app/shared/NhanVienTaiKhoan.model';
import { NhanVienTaiKhoanService } from 'src/app/shared/NhanVienTaiKhoan.service';
import { NhanVienMenu } from 'src/app/shared/NhanVienMenu.model';
import { NhanVienMenuService } from 'src/app/shared/NhanVienMenu.service';
import { PhongBan } from 'src/app/shared/PhongBan.model';
import { PhongBanService } from 'src/app/shared/PhongBan.service';
import { Huyen } from 'src/app/shared/Huyen.model';
import { HuyenService } from 'src/app/shared/Huyen.service';
import { Xa } from 'src/app/shared/Xa.model';
import { XaService } from 'src/app/shared/Xa.service';
import { DoanhNghiep } from 'src/app/shared/DoanhNghiep.model';
import { DoanhNghiepService } from 'src/app/shared/DoanhNghiep.service';
import { Menu } from 'src/app/shared/Menu.model';
import { MenuService } from 'src/app/shared/Menu.service';

@Component({
  selector: 'app-nhan-vien-info',
  templateUrl: './nhan-vien-info.component.html',
  styleUrls: ['./nhan-vien-info.component.css']
})
export class NhanVienInfoComponent implements OnInit {

  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  searchString: string = environment.InitializationString;
  URLSub: string = environment.DomainDestination + "NhanVienInfo";
  URLSubDoanhNghiep: string = environment.DomainDestination + "DoanhNghiepInfo";


  dataSourceNhanVienKhuVuc: MatTableDataSource<any>;
  @ViewChild('sortNhanVienKhuVuc') sortNhanVienKhuVuc: MatSort;
  @ViewChild('paginatorNhanVienKhuVuc') paginatorNhanVienKhuVuc: MatPaginator;

  dataSourceDoanhNghiep: MatTableDataSource<any>;
  @ViewChild('sortDoanhNghiep') sortDoanhNghiep: MatSort;
  @ViewChild('paginatorDoanhNghiep') paginatorDoanhNghiep: MatPaginator;

  constructor(
    public router: Router,
    public NhanVienService: NhanVienService,
    public PhongBanService: PhongBanService,
    public NhanVienKhuVucService: NhanVienKhuVucService,
    public NhanVienTaiKhoanService: NhanVienTaiKhoanService,
    public NhanVienMenuService: NhanVienMenuService,
    public HuyenService: HuyenService,
    public XaService: XaService,
    public DoanhNghiepService: DoanhNghiepService,
    public MenuService: MenuService,
    public NotificationService: NotificationService,
  ) {
    this.router.events.forEach((event) => {
      if (event instanceof NavigationEnd) {
        this.queryString = event.url;
        this.GetByQueryString();
      }
    });
  }

  ngOnInit(): void {
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
  GetHuyenToListAsync() {
    this.isShowLoading = true;
    this.HuyenService.GetAllToListAsync().subscribe(
      res => {
        this.HuyenService.list = (res as Huyen[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  GetXaToListAsync() {
    this.isShowLoading = true;
    this.XaService.GetAllToListAsync().subscribe(
      res => {
        this.XaService.list = (res as Xa[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  GetPhongBanToListAsync() {
    this.isShowLoading = true;
    this.PhongBanService.GetAllToListAsync().subscribe(
      res => {
        this.PhongBanService.list = (res as PhongBan[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  GetNhanVienKhuVucToListAsync() {
    this.isShowLoading = true;
    this.NhanVienKhuVucService.GetSQLByParentIDAsync(this.NhanVienService.formData.ID).subscribe(
      res => {
        this.NhanVienKhuVucService.list = (res as NhanVienKhuVuc[]);
        this.dataSourceNhanVienKhuVuc = new MatTableDataSource(this.NhanVienKhuVucService.list);
        this.dataSourceNhanVienKhuVuc.sort = this.sortNhanVienKhuVuc;
        this.dataSourceNhanVienKhuVuc.paginator = this.paginatorNhanVienKhuVuc;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  GetNhanVienTaiKhoanToListAsync() {
    this.isShowLoading = true;
    this.NhanVienTaiKhoanService.GetByParentIDAndEmptyToListAsync(this.NhanVienService.formData.ID).subscribe(
      res => {
        this.NhanVienTaiKhoanService.list = (res as NhanVienTaiKhoan[]);
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  GetNhanVienMenuToListAsync() {
    this.isShowLoading = true;
    this.NhanVienMenuService.GetByParentIDToListAsync(this.NhanVienService.formData.ID).subscribe(
      res => {
        this.NhanVienMenuService.list = (res as NhanVienMenu[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  GetDoanhNghiepToListAsync() {
    this.isShowLoading = true;
    this.DoanhNghiepService.GetBySearchStringToListAsync(this.searchString).subscribe(
      res => {
        this.DoanhNghiepService.listSearch = (res as DoanhNghiep[]);
        this.dataSourceDoanhNghiep = new MatTableDataSource(this.DoanhNghiepService.listSearch.sort((a, b) => (a.HuyenID > b.HuyenID ? 1 : -1)));
        this.dataSourceDoanhNghiep.sort = this.sortDoanhNghiep;
        this.dataSourceDoanhNghiep.paginator = this.paginatorDoanhNghiep;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  GetByQueryString() {
    this.isShowLoading = true;
    this.NhanVienService.GetByIDStringAsync(this.queryString).then(res => {
      this.NhanVienService.formData = res as NhanVien;
      this.GetNhanVienToListAsync();
      this.GetPhongBanToListAsync();
      this.GetHuyenToListAsync();
      this.GetXaToListAsync();
      this.GetMenuToListAsync();
      this.GetDoanhNghiepToListAsync();
      if (this.NhanVienService.formData) {
        this.GetNhanVienKhuVucToListAsync();
        this.GetNhanVienTaiKhoanToListAsync();
        this.GetNhanVienMenuToListAsync();
        this.isShowLoading = false;
      }
      this.isShowLoading = false;
    });
  }
  onSubmit(form: NgForm) {
    this.isShowLoading = true;
    this.NhanVienService.SaveAndUploadFileAsync(this.NhanVienService.formData, this.fileToUpload).subscribe(
      res => {
        if (this.NhanVienService.formData.ID == 0) {
          this.NhanVienService.formData = res as NhanVien;
          if (this.NhanVienService.formData.ID > 0) {
            window.location.href = this.URLSub + "/" + this.NhanVienService.formData.ID;
          }
          else {
            this.NotificationService.warn(environment.SaveSuccess);
          }
        }
        else {
          this.NotificationService.warn(environment.SaveSuccess);
        }
        this.isShowLoading = false;
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onNhanVienKhuVucActiveChange(element: NhanVienKhuVuc) {
    this.NhanVienKhuVucService.SaveAsync(element).subscribe(
      res => {
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
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
  onSearch() {
    this.GetDoanhNghiepToListAsync();
  }
  onSave() {
    if (this.DoanhNghiepService.listSearch) {
      if (this.DoanhNghiepService.listSearch.length > 0) {
        this.isShowLoading = true;
        for (let i = 0; i < this.DoanhNghiepService.listSearch.length; i++) {
          this.DoanhNghiepService.listSearch[i].NhanVienID = this.NhanVienService.formData.ID;
        }
        this.DoanhNghiepService.SaveListAsync(this.DoanhNghiepService.listSearch).subscribe(
          res => {
            this.GetDoanhNghiepToListAsync();
            this.NotificationService.warn(environment.SaveSuccess);
            this.isShowLoading = false;
          },
          err => {
            this.NotificationService.warn(environment.SaveNotSuccess);
          }
        );
      }
      else {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    }
    else {
      this.NotificationService.warn(environment.SaveNotSuccess);
    }
  }
  onSaveNhanVienTaiKhoan(element: NhanVienTaiKhoan) {
    element.ParentID = this.NhanVienService.formData.ID;
    this.NhanVienTaiKhoanService.SaveAsync(element).subscribe(
      res => {
        this.GetNhanVienTaiKhoanToListAsync();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDeleteNhanVienTaiKhoan(element: NhanVienTaiKhoan) {
    if (confirm(environment.DeleteConfirm)) {
      this.NhanVienTaiKhoanService.RemoveAsync(element.ID).subscribe(
        res => {
          this.GetNhanVienTaiKhoanToListAsync();
          this.NotificationService.warn(environment.DeleteSuccess);
        },
        err => {
          this.NotificationService.warn(environment.DeleteNotSuccess);
        }
      );
    }
  }
  fileToUpload: any;
  fileToUpload0: File = null;
  changeImage(files: FileList) {
    if (files) {
      this.fileToUpload = files;
      this.fileToUpload0 = files.item(0);
      var reader = new FileReader();
      reader.onload = (event: any) => {
        this.NhanVienService.formData.Note = event.target.result;
      };
      reader.readAsDataURL(this.fileToUpload0);
    }
  }
}

import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Tinh } from 'src/app/shared/Tinh.model';
import { TinhService } from 'src/app/shared/Tinh.service';
import { Huyen } from 'src/app/shared/Huyen.model';
import { HuyenService } from 'src/app/shared/Huyen.service';
import { Xa } from 'src/app/shared/Xa.model';
import { XaService } from 'src/app/shared/Xa.service';
import { LoaiDoanhNghiep } from 'src/app/shared/LoaiDoanhNghiep.model';
import { LoaiDoanhNghiepService } from 'src/app/shared/LoaiDoanhNghiep.service';
import { NganhNgheKinhDoanh } from 'src/app/shared/NganhNgheKinhDoanh.model';
import { NganhNgheKinhDoanhService } from 'src/app/shared/NganhNgheKinhDoanh.service';
import { LoaiDoanhNghiepThanhVien } from 'src/app/shared/LoaiDoanhNghiepThanhVien.model';
import { LoaiDoanhNghiepThanhVienService } from 'src/app/shared/LoaiDoanhNghiepThanhVien.service';
import { LoaiDichVu } from 'src/app/shared/LoaiDichVu.model';
import { LoaiDichVuService } from 'src/app/shared/LoaiDichVu.service';
import { DichVu } from 'src/app/shared/DichVu.model';
import { DichVuService } from 'src/app/shared/DichVu.service';
import { GoiCuoc } from 'src/app/shared/GoiCuoc.model';
import { GoiCuocService } from 'src/app/shared/GoiCuoc.service';
import { EmailConfig } from 'src/app/shared/EmailConfig.model';
import { EmailConfigService } from 'src/app/shared/EmailConfig.service';
import { NhanVien } from 'src/app/shared/NhanVien.model';
import { NhanVienService } from 'src/app/shared/NhanVien.service';
import { NhanVienTaiKhoan } from 'src/app/shared/NhanVienTaiKhoan.model';
import { NhanVienTaiKhoanService } from 'src/app/shared/NhanVienTaiKhoan.service';
import { DichVuChiTieu } from 'src/app/shared/DichVuChiTieu.model';
import { DichVuChiTieuService } from 'src/app/shared/DichVuChiTieu.service';
import { DanhMucGoiCuoc } from 'src/app/shared/DanhMucGoiCuoc.model';
import { DanhMucGoiCuocService } from 'src/app/shared/DanhMucGoiCuoc.service';
import { YearMonth } from 'src/app/shared/YearMonth.model';
import { DownloadService } from 'src/app/shared/Download.service';

import { Menu } from 'src/app/shared/Menu.model';
import { MenuService } from 'src/app/shared/Menu.service';

@Component({
  selector: 'app-tinh',
  templateUrl: './tinh.component.html',
  styleUrls: ['./tinh.component.css']
})
export class TinhComponent implements OnInit {

  dataSource1: MatTableDataSource<any>;
  @ViewChild('sort1') sort1: MatSort;
  @ViewChild('paginator1') paginator1: MatPaginator;

  dataSource2: MatTableDataSource<any>;
  @ViewChild('sort2') sort2: MatSort;
  @ViewChild('paginator2') paginator2: MatPaginator;

  dataSource3: MatTableDataSource<any>;
  @ViewChild('sort3') sort3: MatSort;
  @ViewChild('paginator3') paginator3: MatPaginator;

  dataSource4: MatTableDataSource<any>;
  @ViewChild('sort4') sort4: MatSort;
  @ViewChild('paginator4') paginator4: MatPaginator;

  dataSource5: MatTableDataSource<any>;
  @ViewChild('sort5') sort5: MatSort;
  @ViewChild('paginator5') paginator5: MatPaginator;

  dataSource6: MatTableDataSource<any>;
  @ViewChild('sort6') sort6: MatSort;
  @ViewChild('paginator6') paginator6: MatPaginator;

  dataSource7: MatTableDataSource<any>;
  @ViewChild('sort7') sort7: MatSort;
  @ViewChild('paginator7') paginator7: MatPaginator;

  dataSource8: MatTableDataSource<any>;
  @ViewChild('sort8') sort8: MatSort;
  @ViewChild('paginator8') paginator8: MatPaginator;

  dataSource9: MatTableDataSource<any>;
  @ViewChild('sort9') sort9: MatSort;
  @ViewChild('paginator9') paginator9: MatPaginator;

  dataSource10: MatTableDataSource<any>;
  @ViewChild('sort10') sort10: MatSort;
  @ViewChild('paginator10') paginator10: MatPaginator;

  dataSource11: MatTableDataSource<any>;
  @ViewChild('sort11') sort11: MatSort;
  @ViewChild('paginator11') paginator11: MatPaginator;

  dataSource12: MatTableDataSource<any>;
  @ViewChild('sort12') sort12: MatSort;
  @ViewChild('paginator12') paginator12: MatPaginator;

  dataSource13: MatTableDataSource<any>;
  @ViewChild('sort13') sort13: MatSort;
  @ViewChild('paginator13') paginator13: MatPaginator;

  dataSourceMenu: MatTableDataSource<any>;
  @ViewChild('sortMenu') sortMenu: MatSort;
  @ViewChild('paginatorMenu') paginatorMenu: MatPaginator;


  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  year: number = new Date().getFullYear();
  month: number = new Date().getMonth() + 1;
  constructor(
    public TinhService: TinhService,
    public HuyenService: HuyenService,
    public XaService: XaService,
    public LoaiDoanhNghiepService: LoaiDoanhNghiepService,
    public NganhNgheKinhDoanhService: NganhNgheKinhDoanhService,
    public LoaiDoanhNghiepThanhVienService: LoaiDoanhNghiepThanhVienService,
    public LoaiDichVuService: LoaiDichVuService,
    public DichVuService: DichVuService,
    public GoiCuocService: GoiCuocService,
    public EmailConfigService: EmailConfigService,
    public NhanVienService: NhanVienService,
    public NhanVienTaiKhoanService: NhanVienTaiKhoanService,
    public DichVuChiTieuService: DichVuChiTieuService,
    public DanhMucGoiCuocService: DanhMucGoiCuocService,
    public MenuService: MenuService,
    public DownloadService: DownloadService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.onSearchTinh();
    this.onSearchHuyen();
    this.NhanVienGetToList();
    this.GetYearToList();
    this.GetMonthToList();
  }

  DanhMucGoiCuocGetToList() {
    this.isShowLoading = true;
    this.DanhMucGoiCuocService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.DanhMucGoiCuocService.list = (res as DanhMucGoiCuoc[]);
        this.dataSource13 = new MatTableDataSource(this.DanhMucGoiCuocService.list);
        this.dataSource13.sort = this.sort13;
        this.dataSource13.paginator = this.paginator13;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchDanhMucGoiCuoc() {
    if (this.searchString.length > 0) {
      this.dataSource13.filter = this.searchString.toLowerCase();
    }
    else {
      this.DanhMucGoiCuocGetToList();
    }
  }
  onSaveDanhMucGoiCuoc(element: DanhMucGoiCuoc) {
    this.DanhMucGoiCuocService.SaveAsync(element).subscribe(
      res => {
        this.onSearchDanhMucGoiCuoc();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDeleteDanhMucGoiCuoc(element: DanhMucGoiCuoc) {
    if (confirm(environment.DeleteConfirm)) {
      this.DanhMucGoiCuocService.RemoveAsync(element.ID).subscribe(
        res => {
          this.onSearchDanhMucGoiCuoc();
          this.NotificationService.warn(environment.DeleteSuccess);
        },
        err => {
          this.NotificationService.warn(environment.DeleteNotSuccess);
        }
      );
    }
  }

  GetYearToList() {
    this.DownloadService.GetYearToList().then(res => {
      this.DownloadService.listYear = res as YearMonth[];
    });
  }
  GetMonthToList() {
    this.DownloadService.GetMonthToList().then(res => {
      this.DownloadService.listMonth = res as YearMonth[];      
    });
  }

  MenuGetToList() {
    this.isShowLoading = true;
    this.MenuService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.MenuService.list = (res as Menu[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
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

  DichVuChiTieuGetToList() {
    this.isShowLoading = true;
    this.DichVuChiTieuService.GetByNam_ThangToListAsync(this.year, this.month).subscribe(
      res => {
        this.DichVuChiTieuService.list = (res as DichVuChiTieu[]);
        this.dataSource12 = new MatTableDataSource(this.DichVuChiTieuService.list);
        this.dataSource12.sort = this.sort12;
        this.dataSource12.paginator = this.paginator12;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchDichVuChiTieu() {
    if (this.searchString.length > 0) {
      this.dataSource12.filter = this.searchString.toLowerCase();
    }
    else {
      this.DichVuChiTieuGetToList();
    }
  }
  onSaveDichVuChiTieu(element: DichVuChiTieu) {
    this.DichVuChiTieuService.SaveAsync(element).subscribe(
      res => {
        this.onSearchDichVuChiTieu();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDeleteDichVuChiTieu(element: DichVuChiTieu) {
    if (confirm(environment.DeleteConfirm)) {
      this.DichVuChiTieuService.RemoveAsync(element.ID).subscribe(
        res => {
          this.onSearchDichVuChiTieu();
          this.NotificationService.warn(environment.DeleteSuccess);
        },
        err => {
          this.NotificationService.warn(environment.DeleteNotSuccess);
        }
      );
    }
  }

  NhanVienGetToList() {
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

  NhanVienTaiKhoanGetToList() {
    this.isShowLoading = true;
    this.NhanVienTaiKhoanService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.NhanVienTaiKhoanService.list = (res as NhanVienTaiKhoan[]).sort((a, b) => (a.ParentID > b.ParentID ? 1 : -1));
        this.dataSource11 = new MatTableDataSource(this.NhanVienTaiKhoanService.list);
        this.dataSource11.sort = this.sort11;
        this.dataSource11.paginator = this.paginator11;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchNhanVienTaiKhoan() {
    if (this.searchString.length > 0) {
      this.dataSource11.filter = this.searchString.toLowerCase();
    }
    else {
      this.NhanVienTaiKhoanGetToList();
    }
  }
  onSaveNhanVienTaiKhoan(element: NhanVienTaiKhoan) {
    this.NhanVienTaiKhoanService.SaveAsync(element).subscribe(
      res => {
        this.onSearchNhanVienTaiKhoan();
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
          this.onSearchNhanVienTaiKhoan();
          this.NotificationService.warn(environment.DeleteSuccess);
        },
        err => {
          this.NotificationService.warn(environment.DeleteNotSuccess);
        }
      );
    }
  }

  EmailConfigGetToList() {
    this.isShowLoading = true;
    this.EmailConfigService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.EmailConfigService.list = (res as EmailConfig[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.dataSource10 = new MatTableDataSource(this.EmailConfigService.list);
        this.dataSource10.sort = this.sort10;
        this.dataSource10.paginator = this.paginator10;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchEmailConfig() {
    if (this.searchString.length > 0) {
      this.dataSource10.filter = this.searchString.toLowerCase();
    }
    else {
      this.EmailConfigGetToList();
    }
  }
  onSaveEmailConfig(element: EmailConfig) {
    this.EmailConfigService.SaveAsync(element).subscribe(
      res => {
        this.onSearchEmailConfig();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDeleteEmailConfig(element: EmailConfig) {
    if (confirm(environment.DeleteConfirm)) {
      this.EmailConfigService.RemoveAsync(element.ID).subscribe(
        res => {
          this.onSearchEmailConfig();
          this.NotificationService.warn(environment.DeleteSuccess);
        },
        err => {
          this.NotificationService.warn(environment.DeleteNotSuccess);
        }
      );
    }
  }

  GoiCuocGetToList() {
    this.isShowLoading = true;
    this.GoiCuocService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.GoiCuocService.list = (res as GoiCuoc[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.dataSource9 = new MatTableDataSource(this.GoiCuocService.list);
        this.dataSource9.sort = this.sort9;
        this.dataSource9.paginator = this.paginator9;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchGoiCuoc() {
    if (this.searchString.length > 0) {
      this.dataSource9.filter = this.searchString.toLowerCase();
    }
    else {
      this.GoiCuocGetToList();
    }
  }
  onSaveGoiCuoc(element: GoiCuoc) {
    this.GoiCuocService.SaveAsync(element).subscribe(
      res => {
        this.onSearchGoiCuoc();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDeleteGoiCuoc(element: GoiCuoc) {
    if (confirm(environment.DeleteConfirm)) {
      this.GoiCuocService.RemoveAsync(element.ID).subscribe(
        res => {
          this.onSearchGoiCuoc();
          this.NotificationService.warn(environment.DeleteSuccess);
        },
        err => {
          this.NotificationService.warn(environment.DeleteNotSuccess);
        }
      );
    }
  }

  DichVuGetToList() {
    this.isShowLoading = true;
    this.DichVuService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.DichVuService.list = (res as DichVu[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.dataSource5 = new MatTableDataSource(this.DichVuService.list);
        this.dataSource5.sort = this.sort5;
        this.dataSource5.paginator = this.paginator5;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchDichVu() {
    if (this.searchString.length > 0) {
      this.dataSource5.filter = this.searchString.toLowerCase();
    }
    else {
      this.DichVuGetToList();
    }
  }
  onSaveDichVu(element: DichVu) {
    this.DichVuService.SaveAsync(element).subscribe(
      res => {
        this.onSearchDichVu();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDeleteDichVu(element: DichVu) {
    if (confirm(environment.DeleteConfirm)) {
      this.DichVuService.RemoveAsync(element.ID).subscribe(
        res => {
          this.onSearchDichVu();
          this.NotificationService.warn(environment.DeleteSuccess);
        },
        err => {
          this.NotificationService.warn(environment.DeleteNotSuccess);
        }
      );
    }
  }

  LoaiDichVuGetToList() {
    this.isShowLoading = true;
    this.LoaiDichVuService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.LoaiDichVuService.list = (res as LoaiDichVu[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.dataSource6 = new MatTableDataSource(this.LoaiDichVuService.list);
        this.dataSource6.sort = this.sort6;
        this.dataSource6.paginator = this.paginator6;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchLoaiDichVu() {
    if (this.searchString.length > 0) {
      this.dataSource6.filter = this.searchString.toLowerCase();
    }
    else {
      this.LoaiDichVuGetToList();
    }
  }
  onSaveLoaiDichVu(element: LoaiDichVu) {
    this.LoaiDichVuService.SaveAsync(element).subscribe(
      res => {
        this.onSearchLoaiDichVu();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDeleteLoaiDichVu(element: LoaiDichVu) {
    if (confirm(environment.DeleteConfirm)) {
      this.LoaiDichVuService.RemoveAsync(element.ID).subscribe(
        res => {
          this.onSearchLoaiDichVu();
          this.NotificationService.warn(environment.DeleteSuccess);
        },
        err => {
          this.NotificationService.warn(environment.DeleteNotSuccess);
        }
      );
    }
  }

  LoaiDoanhNghiepThanhVienGetToList() {
    this.isShowLoading = true;
    this.LoaiDoanhNghiepThanhVienService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.LoaiDoanhNghiepThanhVienService.list = (res as LoaiDoanhNghiepThanhVien[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.dataSource7 = new MatTableDataSource(this.LoaiDoanhNghiepThanhVienService.list);
        this.dataSource7.sort = this.sort7;
        this.dataSource7.paginator = this.paginator7;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchLoaiDoanhNghiepThanhVien() {
    if (this.searchString.length > 0) {
      this.dataSource7.filter = this.searchString.toLowerCase();
    }
    else {
      this.LoaiDoanhNghiepThanhVienGetToList();
    }
  }
  onSaveLoaiDoanhNghiepThanhVien(element: LoaiDoanhNghiepThanhVien) {
    this.LoaiDoanhNghiepThanhVienService.SaveAsync(element).subscribe(
      res => {
        this.onSearchLoaiDoanhNghiepThanhVien();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDeleteLoaiDoanhNghiepThanhVien(element: LoaiDoanhNghiepThanhVien) {
    if (confirm(environment.DeleteConfirm)) {
      this.LoaiDoanhNghiepThanhVienService.RemoveAsync(element.ID).subscribe(
        res => {
          this.onSearchLoaiDoanhNghiepThanhVien();
          this.NotificationService.warn(environment.DeleteSuccess);
        },
        err => {
          this.NotificationService.warn(environment.DeleteNotSuccess);
        }
      );
    }
  }

  NganhNgheKinhDoanhGetToList() {
    this.isShowLoading = true;
    this.NganhNgheKinhDoanhService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.NganhNgheKinhDoanhService.list = (res as NganhNgheKinhDoanh[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.dataSource8 = new MatTableDataSource(this.NganhNgheKinhDoanhService.list);
        this.dataSource8.sort = this.sort8;
        this.dataSource8.paginator = this.paginator8;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchNganhNgheKinhDoanh() {
    if (this.searchString.length > 0) {
      this.dataSource8.filter = this.searchString.toLowerCase();
    }
    else {
      this.NganhNgheKinhDoanhGetToList();
    }
  }
  onSaveNganhNgheKinhDoanh(element: NganhNgheKinhDoanh) {
    this.NganhNgheKinhDoanhService.SaveAsync(element).subscribe(
      res => {
        this.onSearchNganhNgheKinhDoanh();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDeleteNganhNgheKinhDoanh(element: NganhNgheKinhDoanh) {
    if (confirm(environment.DeleteConfirm)) {
      this.NganhNgheKinhDoanhService.RemoveAsync(element.ID).subscribe(
        res => {
          this.onSearchNganhNgheKinhDoanh();
          this.NotificationService.warn(environment.DeleteSuccess);
        },
        err => {
          this.NotificationService.warn(environment.DeleteNotSuccess);
        }
      );
    }
  }

  TinhGetToList() {
    this.isShowLoading = true;
    this.TinhService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.TinhService.list = (res as Tinh[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.dataSource1 = new MatTableDataSource(this.TinhService.list);
        this.dataSource1.sort = this.sort1;
        this.dataSource1.paginator = this.paginator1;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchTinh() {
    if (this.searchString.length > 0) {
      this.dataSource1.filter = this.searchString.toLowerCase();
    }
    else {
      this.TinhGetToList();
    }
  }
  onSaveTinh(element: Tinh) {
    this.TinhService.SaveAsync(element).subscribe(
      res => {
        this.onSearchTinh();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDeleteTinh(element: Tinh) {
    if (confirm(environment.DeleteConfirm)) {
      this.TinhService.RemoveAsync(element.ID).subscribe(
        res => {
          this.onSearchTinh();
          this.NotificationService.warn(environment.DeleteSuccess);
        },
        err => {
          this.NotificationService.warn(environment.DeleteNotSuccess);
        }
      );
    }
  }
  HuyenGetToList() {
    this.isShowLoading = true;
    this.HuyenService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.HuyenService.list = (res as Huyen[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.dataSource2 = new MatTableDataSource(this.HuyenService.list);
        this.dataSource2.sort = this.sort2;
        this.dataSource2.paginator = this.paginator2;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchHuyen() {
    if (this.searchString.length > 0) {
      this.dataSource2.filter = this.searchString.toLowerCase();
    }
    else {
      this.HuyenGetToList();
    }
  }
  onSaveHuyen(element: Huyen) {
    this.HuyenService.SaveAsync(element).subscribe(
      res => {
        this.onSearchHuyen();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDeleteHuyen(element: Huyen) {
    if (confirm(environment.DeleteConfirm)) {
      this.HuyenService.RemoveAsync(element.ID).subscribe(
        res => {
          this.onSearchHuyen();
          this.NotificationService.warn(environment.DeleteSuccess);
        },
        err => {
          this.NotificationService.warn(environment.DeleteNotSuccess);
        }
      );
    }
  }
  XaGetToList() {
    this.isShowLoading = true;
    this.XaService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.XaService.list = (res as Xa[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.dataSource3 = new MatTableDataSource(this.XaService.list);
        this.dataSource3.sort = this.sort3;
        this.dataSource3.paginator = this.paginator3;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchXa() {
    if (this.searchString.length > 0) {
      this.dataSource3.filter = this.searchString.toLowerCase();
    }
    else {
      this.XaGetToList();
    }
  }
  onSaveXa(element: Xa) {
    this.XaService.SaveAsync(element).subscribe(
      res => {
        this.onSearchXa();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDeleteXa(element: Xa) {
    if (confirm(environment.DeleteConfirm)) {
      this.XaService.RemoveAsync(element.ID).subscribe(
        res => {
          this.onSearchXa();
          this.NotificationService.warn(environment.DeleteSuccess);
        },
        err => {
          this.NotificationService.warn(environment.DeleteNotSuccess);
        }
      );
    }
  }
  LoaiDoanhNghiepGetToList() {
    this.isShowLoading = true;
    this.LoaiDoanhNghiepService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.LoaiDoanhNghiepService.list = (res as LoaiDoanhNghiep[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.dataSource4 = new MatTableDataSource(this.LoaiDoanhNghiepService.list);
        this.dataSource4.sort = this.sort4;
        this.dataSource4.paginator = this.paginator4;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchLoaiDoanhNghiep() {
    if (this.searchString.length > 0) {
      this.dataSource4.filter = this.searchString.toLowerCase();
    }
    else {
      this.LoaiDoanhNghiepGetToList();
    }
  }
  onSaveLoaiDoanhNghiep(element: LoaiDoanhNghiep) {
    this.LoaiDoanhNghiepService.SaveAsync(element).subscribe(
      res => {
        this.onSearchLoaiDoanhNghiep();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDeleteLoaiDoanhNghiep(element: Xa) {
    if (confirm(environment.DeleteConfirm)) {
      this.LoaiDoanhNghiepService.RemoveAsync(element.ID).subscribe(
        res => {
          this.onSearchLoaiDoanhNghiep();
          this.NotificationService.warn(environment.DeleteSuccess);
        },
        err => {
          this.NotificationService.warn(environment.DeleteNotSuccess);
        }
      );
    }
  }
}

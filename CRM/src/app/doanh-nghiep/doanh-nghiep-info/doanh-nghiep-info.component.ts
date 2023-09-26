import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { NotificationService } from 'src/app/shared/notification.service';
import { Huyen } from 'src/app/shared/Huyen.model';
import { HuyenService } from 'src/app/shared/Huyen.service';
import { Xa } from 'src/app/shared/Xa.model';
import { XaService } from 'src/app/shared/Xa.service';
import { LoaiDoanhNghiep } from 'src/app/shared/LoaiDoanhNghiep.model';
import { LoaiDoanhNghiepService } from 'src/app/shared/LoaiDoanhNghiep.service';
import { NganhNgheKinhDoanh } from 'src/app/shared/NganhNgheKinhDoanh.model';
import { NganhNgheKinhDoanhService } from 'src/app/shared/NganhNgheKinhDoanh.service';
import { LoaiTrangThai } from 'src/app/shared/LoaiTrangThai.model';
import { LoaiTrangThaiService } from 'src/app/shared/LoaiTrangThai.service';
import { LoaiDoanhNghiepThanhVien } from 'src/app/shared/LoaiDoanhNghiepThanhVien.model';
import { LoaiDoanhNghiepThanhVienService } from 'src/app/shared/LoaiDoanhNghiepThanhVien.service';
import { DichVu } from 'src/app/shared/DichVu.model';
import { DichVuService } from 'src/app/shared/DichVu.service';
import { NhanVien } from 'src/app/shared/NhanVien.model';
import { NhanVienService } from 'src/app/shared/NhanVien.service';
import { DoanhNghiep } from 'src/app/shared/DoanhNghiep.model';
import { DoanhNghiepService } from 'src/app/shared/DoanhNghiep.service';
import { DoanhNghiepThanhVien } from 'src/app/shared/DoanhNghiepThanhVien.model';
import { DoanhNghiepThanhVienService } from 'src/app/shared/DoanhNghiepThanhVien.service';
import { DoanhNghiepDichVu } from 'src/app/shared/DoanhNghiepDichVu.model';
import { DoanhNghiepDichVuService } from 'src/app/shared/DoanhNghiepDichVu.service';

@Component({
  selector: 'app-doanh-nghiep-info',
  templateUrl: './doanh-nghiep-info.component.html',
  styleUrls: ['./doanh-nghiep-info.component.css']
})
export class DoanhNghiepInfoComponent implements OnInit {

  dataSourceDoanhNghiepThanhVien: MatTableDataSource<any>;
  @ViewChild(MatSort) sortDoanhNghiepThanhVien: MatSort;
  @ViewChild(MatPaginator) paginatorDoanhNghiepThanhVien: MatPaginator;

  dataSourceDoanhNghiepDichVu: MatTableDataSource<any>;
  @ViewChild(MatSort) sortDoanhNghiepDichVu: MatSort;
  @ViewChild(MatPaginator) paginatorDoanhNghiepDichVu: MatPaginator;

  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  URLSub: string = environment.DomainDestination + "DoanhNghiepInfo";
  constructor(
    public router: Router,
    public DoanhNghiepService: DoanhNghiepService,
    public DoanhNghiepThanhVienService: DoanhNghiepThanhVienService,
    public HuyenService: HuyenService,
    public XaService: XaService,
    public LoaiDoanhNghiepService: LoaiDoanhNghiepService,
    public NganhNgheKinhDoanhService: NganhNgheKinhDoanhService,
    public LoaiTrangThaiService: LoaiTrangThaiService,
    public NhanVienService: NhanVienService,
    public LoaiDoanhNghiepThanhVienService: LoaiDoanhNghiepThanhVienService,
    public DoanhNghiepDichVuService: DoanhNghiepDichVuService,
    public DichVuService: DichVuService,
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
  GetDichVuToListAsync() {
    this.DichVuService.GetAllToListAsync().subscribe(
      res => {
        this.DichVuService.list = (res as DichVu[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));              
      },
      err => {
      }
    );
  }
  GetLoaiDoanhNghiepThanhVienToListAsync() {
    this.LoaiDoanhNghiepThanhVienService.GetAllToListAsync().subscribe(
      res => {
        this.LoaiDoanhNghiepThanhVienService.list = (res as LoaiDoanhNghiepThanhVien[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));              
      },
      err => {
      }
    );
  }
  GetNhanVienToListAsync() {
    this.NhanVienService.GetAllToListAsync().subscribe(
      res => {
        this.NhanVienService.list = (res as NhanVien[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));              
      },
      err => {
      }
    );
  }
  GetHuyenToListAsync() {
    this.HuyenService.GetAllToListAsync().subscribe(
      res => {
        this.HuyenService.list = (res as Huyen[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));              
      },
      err => {
      }
    );
  }
  GetXaToListAsync() {
    this.XaService.GetAllToListAsync().subscribe(
      res => {
        this.XaService.list = (res as Xa[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
      },
      err => {
      }
    );
  }
  GetNganhNgheKinhDoanhToListAsync() {
    this.NganhNgheKinhDoanhService.GetAllToListAsync().subscribe(
      res => {
        this.NganhNgheKinhDoanhService.list = (res as NganhNgheKinhDoanh[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
      },
      err => {
      }
    );
  }
  GetLoaiDoanhNghiepToListAsync() {
    this.LoaiDoanhNghiepService.GetAllToListAsync().subscribe(
      res => {
        this.LoaiDoanhNghiepService.list = (res as LoaiDoanhNghiep[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
      },
      err => {
      }
    );
  }
  GetLoaiTrangThaiToListAsync() {
    this.LoaiTrangThaiService.GetAllToListAsync().subscribe(
      res => {
        this.LoaiTrangThaiService.list = (res as LoaiTrangThai[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
      },
      err => {
      }
    );
  }
  GetDoanhNghiepThanhVienToListAsync() {
    this.DoanhNghiepThanhVienService.GetByParentIDAndEmptyToListAsync(this.DoanhNghiepService.formData.ID).subscribe(
      res => {
        this.DoanhNghiepThanhVienService.list = (res as DoanhNghiepThanhVien[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.dataSourceDoanhNghiepThanhVien = new MatTableDataSource(this.DoanhNghiepThanhVienService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
        this.dataSourceDoanhNghiepThanhVien.sort = this.sortDoanhNghiepThanhVien;
        this.dataSourceDoanhNghiepThanhVien.paginator = this.paginatorDoanhNghiepThanhVien;
      },
      err => {
      }
    );
  }
  GetDoanhNghiepDichVuToListAsync() {
    this.DoanhNghiepDichVuService.GetByParentIDAndEmptyToListAsync(this.DoanhNghiepService.formData.ID).subscribe(
      res => {
        this.DoanhNghiepDichVuService.list = (res as DoanhNghiepDichVu[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.dataSourceDoanhNghiepDichVu = new MatTableDataSource(this.DoanhNghiepDichVuService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
        this.dataSourceDoanhNghiepDichVu.sort = this.sortDoanhNghiepDichVu;
        this.dataSourceDoanhNghiepDichVu.paginator = this.paginatorDoanhNghiepDichVu;
      },
      err => {
      }
    );
  }
  GetByQueryString() {
    this.isShowLoading = true;
    this.DoanhNghiepService.GetByIDStringAsync(this.queryString).then(res => {
      this.DoanhNghiepService.formData = res as DoanhNghiep;
      if (this.DoanhNghiepService.formData) {
        this.GetHuyenToListAsync();
        this.GetXaToListAsync();
        this.GetNganhNgheKinhDoanhToListAsync();
        this.GetLoaiDoanhNghiepToListAsync();
        this.GetLoaiTrangThaiToListAsync();
        this.GetNhanVienToListAsync();
        this.GetDoanhNghiepThanhVienToListAsync();
        this.GetLoaiDoanhNghiepThanhVienToListAsync();
        this.GetDoanhNghiepDichVuToListAsync();
        this.GetDichVuToListAsync();
      }
      this.isShowLoading = false;
    });
  }
  onSubmit(form: NgForm) {
    this.isShowLoading = true;
    this.DoanhNghiepService.SaveAsync(form.value).subscribe(
      res => {
        this.GetByQueryString();
        this.NotificationService.warn(environment.SaveSuccess);
        this.isShowLoading = false;
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onChangeNgayCap(value) {
    this.DoanhNghiepService.formData.NgayCap = new Date(value);
  }
  onChangeNgayDangKyThayDoi(value) {
    this.DoanhNghiepService.formData.NgayDangKyThayDoi = new Date(value);
  }
  onChangeDoanhNghiepThanhVienNgaySinh(element: DoanhNghiepThanhVien, value) {
    element.NgaySinh = new Date(value);
  }
  onChangeDoanhNghiepThanhVienCCCD_NgayCap(element: DoanhNghiepThanhVien, value) {
    element.CCCD_NgayCap = new Date(value);
  }
  onChangeDoanhNghiepDichVuNgayKyHopDong(element: DoanhNghiepDichVu, value) {
    element.NgayKyHopDong = new Date(value);
  }
  onSaveDoanhNghiepThanhVien(element: DoanhNghiepThanhVien) {    
    this.DoanhNghiepThanhVienService.SaveAsync(element).subscribe(
      res => {
        this.GetDoanhNghiepThanhVienToListAsync();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onSaveDoanhNghiepDichVu(element: DoanhNghiepDichVu) {    
    this.DoanhNghiepDichVuService.SaveAsync(element).subscribe(
      res => {
        this.GetDoanhNghiepDichVuToListAsync();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
}

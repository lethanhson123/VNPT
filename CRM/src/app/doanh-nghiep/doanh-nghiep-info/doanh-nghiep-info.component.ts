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
import { DoanhNghiep } from 'src/app/shared/DoanhNghiep.model';
import { DoanhNghiepService } from 'src/app/shared/DoanhNghiep.service';

@Component({
  selector: 'app-doanh-nghiep-info',
  templateUrl: './doanh-nghiep-info.component.html',
  styleUrls: ['./doanh-nghiep-info.component.css']
})
export class DoanhNghiepInfoComponent implements OnInit {

  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  URLSub: string = environment.DomainDestination + "DoanhNghiepInfo";
  constructor(
    public router: Router,
    public DoanhNghiepService: DoanhNghiepService,
    public HuyenService: HuyenService,
    public XaService: XaService,
    public LoaiDoanhNghiepService: LoaiDoanhNghiepService,
    public NganhNgheKinhDoanhService: NganhNgheKinhDoanhService,
    public LoaiTrangThaiService: LoaiTrangThaiService,
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
}

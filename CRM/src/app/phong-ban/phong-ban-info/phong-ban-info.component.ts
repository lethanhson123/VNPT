import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { NgForm } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { PhongBanKhuVuc } from 'src/app/shared/PhongBanKhuVuc.model';
import { PhongBanKhuVucService } from 'src/app/shared/PhongBanKhuVuc.service';
import { PhongBan } from 'src/app/shared/PhongBan.model';
import { PhongBanService } from 'src/app/shared/PhongBan.service';
import { Huyen } from 'src/app/shared/Huyen.model';
import { HuyenService } from 'src/app/shared/Huyen.service';
import { Xa } from 'src/app/shared/Xa.model';
import { XaService } from 'src/app/shared/Xa.service';
import { DoanhNghiep } from 'src/app/shared/DoanhNghiep.model';
import { DoanhNghiepService } from 'src/app/shared/DoanhNghiep.service';
import { NhanVien } from 'src/app/shared/NhanVien.model';
import { NhanVienService } from 'src/app/shared/NhanVien.service';

@Component({
  selector: 'app-phong-ban-info',
  templateUrl: './phong-ban-info.component.html',
  styleUrls: ['./phong-ban-info.component.css']
})
export class PhongBanInfoComponent implements OnInit {

  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  searchString: string = environment.InitializationString;
  URLSub: string = environment.DomainDestination + "PhongBanInfo";
  URLSubDoanhNghiep: string = environment.DomainDestination + "DoanhNghiepInfo";
  URLSubNhanVien: string = environment.DomainDestination + "NhanVienInfo";


  dataSourcePhongBanKhuVuc: MatTableDataSource<any>;
  @ViewChild('sortPhongBanKhuVuc') sortPhongBanKhuVuc: MatSort;
  @ViewChild('paginatorPhongBanKhuVuc') paginatorPhongBanKhuVuc: MatPaginator;

  dataSourceDoanhNghiep: MatTableDataSource<any>;
  @ViewChild('sortDoanhNghiep') sortDoanhNghiep: MatSort;
  @ViewChild('paginatorDoanhNghiep') paginatorDoanhNghiep: MatPaginator;

  dataSourceNhanVien: MatTableDataSource<any>;
  @ViewChild('sortNhanVien') sortNhanVien: MatSort;
  @ViewChild('paginatorNhanVien') paginatorNhanVien: MatPaginator;

  constructor(
    public router: Router,
    public NhanVienService: NhanVienService,
    public PhongBanService: PhongBanService,
    public PhongBanKhuVucService: PhongBanKhuVucService,
    public HuyenService: HuyenService,
    public XaService: XaService,
    public DoanhNghiepService: DoanhNghiepService,
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
  GetNhanVienToListAsync() {
    this.isShowLoading = true;
    this.NhanVienService.GetByParentIDToListAsync(this.PhongBanService.formData.ID).subscribe(
      res => {
        this.NhanVienService.list = (res as NhanVien[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.dataSourceNhanVien = new MatTableDataSource(this.NhanVienService.list);
        this.dataSourceNhanVien.sort = this.sortNhanVien;
        this.dataSourceNhanVien.paginator = this.paginatorNhanVien;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  GetPhongBanKhuVucToListAsync() {
    this.isShowLoading = true;
    this.PhongBanKhuVucService.GetSQLByParentIDAsync(this.PhongBanService.formData.ID).subscribe(
      res => {
        this.PhongBanKhuVucService.list = (res as PhongBanKhuVuc[]);
        this.dataSourcePhongBanKhuVuc = new MatTableDataSource(this.PhongBanKhuVucService.list);
        this.dataSourcePhongBanKhuVuc.sort = this.sortPhongBanKhuVuc;
        this.dataSourcePhongBanKhuVuc.paginator = this.paginatorPhongBanKhuVuc;
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
    this.PhongBanService.GetByIDStringAsync(this.queryString).then(res => {
      this.PhongBanService.formData = res as PhongBan;
      this.GetHuyenToListAsync();
      this.GetXaToListAsync();
      this.GetPhongBanToListAsync();
      this.GetDoanhNghiepToListAsync();
      if (this.PhongBanService.formData) {
        this.GetPhongBanKhuVucToListAsync();
        this.GetNhanVienToListAsync();
        this.isShowLoading = false;
      }
      this.isShowLoading = false;
    });
  }
  onSubmit(form: NgForm) {
    this.isShowLoading = true;
    this.PhongBanService.SaveAsync(this.PhongBanService.formData).subscribe(
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
  onPhongBanKhuVucActiveChange(element: PhongBanKhuVuc) {
    this.PhongBanKhuVucService.SaveAsync(element).subscribe(
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
          this.DoanhNghiepService.listSearch[i].PhongBanID = this.PhongBanService.formData.ID;
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
}
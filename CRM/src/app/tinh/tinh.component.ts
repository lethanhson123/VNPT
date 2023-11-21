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
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public TinhService: TinhService,
    public HuyenService: HuyenService,
    public XaService: XaService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.onSearchTinh();
    this.onSearchHuyen();
    this.onSearchXa();
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
}

import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { NhanVien } from 'src/app/shared/NhanVien.model';
import { NhanVienService } from 'src/app/shared/NhanVien.service';
import { NhanVienTaiKhoan } from 'src/app/shared/NhanVienTaiKhoan.model';
import { NhanVienTaiKhoanService } from 'src/app/shared/NhanVienTaiKhoan.service';

@Component({
  selector: 'app-nhan-vien-tai-khoan',
  templateUrl: './nhan-vien-tai-khoan.component.html',
  styleUrls: ['./nhan-vien-tai-khoan.component.css']
})
export class NhanVienTaiKhoanComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public NhanVienService: NhanVienService,
    public NhanVienTaiKhoanService: NhanVienTaiKhoanService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.getNhanVienToList();
    this.onSearch();
  }
  getNhanVienToList() {
    this.isShowLoading = true;
    this.NhanVienService.GetAllToListAsync().subscribe(
      res => {
        this.NhanVienService.list = (res as NhanVien[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  getToList() {
    this.isShowLoading = true;
    this.NhanVienTaiKhoanService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.NhanVienTaiKhoanService.list = (res as NhanVienTaiKhoan[]).sort((a, b) => (a.ParentID > b.ParentID ? 1 : -1));
        this.dataSource = new MatTableDataSource(this.NhanVienTaiKhoanService.list);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearch() {
    if (this.searchString.length > 0) {
      this.dataSource.filter = this.searchString.toLowerCase();
      this.NhanVienTaiKhoanService.list = this.dataSource.filteredData;
    }
    else {
      this.getToList();
    }
  }
  onSave(element: NhanVienTaiKhoan) {
    this.NhanVienTaiKhoanService.SaveAsync(element).subscribe(
      res => {
        this.onSearch();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDelete(element: NhanVienTaiKhoan) {
    if (confirm(environment.DeleteConfirm)) {
      this.NhanVienTaiKhoanService.RemoveAsync(element.ID).subscribe(
        res => {
          this.onSearch();
          this.NotificationService.warn(environment.DeleteSuccess);
        },
        err => {
          this.NotificationService.warn(environment.DeleteNotSuccess);
        }
      );
    }
  }
}
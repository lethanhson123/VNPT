import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { LoaiDoanhNghiepThanhVien } from 'src/app/shared/LoaiDoanhNghiepThanhVien.model';
import { LoaiDoanhNghiepThanhVienService } from 'src/app/shared/LoaiDoanhNghiepThanhVien.service';

@Component({
  selector: 'app-loai-doanh-nghiep-thanh-vien',
  templateUrl: './loai-doanh-nghiep-thanh-vien.component.html',
  styleUrls: ['./loai-doanh-nghiep-thanh-vien.component.css']
})
export class LoaiDoanhNghiepThanhVienComponent implements OnInit {

  dataSource: MatTableDataSource<any>;  
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public LoaiDoanhNghiepThanhVienService: LoaiDoanhNghiepThanhVienService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.onSearch();
  }
  getToList() {
    this.isShowLoading = true;
    this.LoaiDoanhNghiepThanhVienService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.LoaiDoanhNghiepThanhVienService.list = res as LoaiDoanhNghiepThanhVien[];
        this.dataSource = new MatTableDataSource(this.LoaiDoanhNghiepThanhVienService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
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
    }
    else {
      this.getToList();
    }
  }
  onSave(element: LoaiDoanhNghiepThanhVien) {    
    this.LoaiDoanhNghiepThanhVienService.SaveAsync(element).subscribe(
      res => {        
        this.onSearch();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDelete(element: LoaiDoanhNghiepThanhVien) {
    if (confirm(environment.DeleteConfirm)) {
      this.LoaiDoanhNghiepThanhVienService.RemoveAsync(element.ID).subscribe(
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
  onSaveList() {    
    this.LoaiDoanhNghiepThanhVienService.SaveListAsync(this.LoaiDoanhNghiepThanhVienService.list).subscribe(
      res => {
        this.onSearch();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
}
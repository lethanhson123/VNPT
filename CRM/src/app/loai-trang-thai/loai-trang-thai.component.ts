import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { LoaiTrangThai } from 'src/app/shared/LoaiTrangThai.model';
import { LoaiTrangThaiService } from 'src/app/shared/LoaiTrangThai.service';

@Component({
  selector: 'app-loai-trang-thai',
  templateUrl: './loai-trang-thai.component.html',
  styleUrls: ['./loai-trang-thai.component.css']
})
export class LoaiTrangThaiComponent implements OnInit {

  dataSource: MatTableDataSource<any>;  
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public LoaiTrangThaiService: LoaiTrangThaiService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.onSearch();
  }
  getToList() {
    this.isShowLoading = true;
    this.LoaiTrangThaiService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.LoaiTrangThaiService.list = res as LoaiTrangThai[];
        this.dataSource = new MatTableDataSource(this.LoaiTrangThaiService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
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
  onSave(element: LoaiTrangThai) {    
    this.LoaiTrangThaiService.SaveAsync(element).subscribe(
      res => {        
        this.onSearch();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDelete(element: LoaiTrangThai) {
    if (confirm(environment.DeleteConfirm)) {
      this.LoaiTrangThaiService.RemoveAsync(element.ID).subscribe(
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
    this.LoaiTrangThaiService.SaveListAsync(this.LoaiTrangThaiService.list).subscribe(
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
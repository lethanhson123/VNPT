import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { LoaiDoanhNghiep } from 'src/app/shared/LoaiDoanhNghiep.model';
import { LoaiDoanhNghiepService } from 'src/app/shared/LoaiDoanhNghiep.service';

@Component({
  selector: 'app-loai-doanh-nghiep',
  templateUrl: './loai-doanh-nghiep.component.html',
  styleUrls: ['./loai-doanh-nghiep.component.css']
})
export class LoaiDoanhNghiepComponent implements OnInit {

  dataSource: MatTableDataSource<any>;  
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public LoaiDoanhNghiepService: LoaiDoanhNghiepService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.onSearch();
  }
  getToList() {
    this.isShowLoading = true;
    this.LoaiDoanhNghiepService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.LoaiDoanhNghiepService.list = res as LoaiDoanhNghiep[];
        this.dataSource = new MatTableDataSource(this.LoaiDoanhNghiepService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
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
  onSave(element: LoaiDoanhNghiep) {    
    this.LoaiDoanhNghiepService.SaveAsync(element).subscribe(
      res => {        
        this.onSearch();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDelete(element: LoaiDoanhNghiep) {
    if (confirm(environment.DeleteConfirm)) {
      this.LoaiDoanhNghiepService.RemoveAsync(element.ID).subscribe(
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
    this.LoaiDoanhNghiepService.SaveListAsync(this.LoaiDoanhNghiepService.list).subscribe(
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

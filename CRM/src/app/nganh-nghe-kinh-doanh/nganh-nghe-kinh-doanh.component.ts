import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { NganhNgheKinhDoanh } from 'src/app/shared/NganhNgheKinhDoanh.model';
import { NganhNgheKinhDoanhService } from 'src/app/shared/NganhNgheKinhDoanh.service';

@Component({
  selector: 'app-nganh-nghe-kinh-doanh',
  templateUrl: './nganh-nghe-kinh-doanh.component.html',
  styleUrls: ['./nganh-nghe-kinh-doanh.component.css']
})
export class NganhNgheKinhDoanhComponent implements OnInit {

  dataSource: MatTableDataSource<any>;  
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public NganhNgheKinhDoanhService: NganhNgheKinhDoanhService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.onSearch();
  }
  getToList() {
    this.isShowLoading = true;
    this.NganhNgheKinhDoanhService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.NganhNgheKinhDoanhService.list = res as NganhNgheKinhDoanh[];
        this.dataSource = new MatTableDataSource(this.NganhNgheKinhDoanhService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
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
  onSave(element: NganhNgheKinhDoanh) {    
    this.NganhNgheKinhDoanhService.SaveAsync(element).subscribe(
      res => {        
        this.onSearch();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDelete(element: NganhNgheKinhDoanh) {
    if (confirm(environment.DeleteConfirm)) {
      this.NganhNgheKinhDoanhService.RemoveAsync(element.ID).subscribe(
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
    this.NganhNgheKinhDoanhService.SaveListAsync(this.NganhNgheKinhDoanhService.list).subscribe(
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


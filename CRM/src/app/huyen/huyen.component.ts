import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Huyen } from 'src/app/shared/Huyen.model';
import { HuyenService } from 'src/app/shared/Huyen.service';
import { Tinh } from 'src/app/shared/Tinh.model';
import { TinhService } from 'src/app/shared/Tinh.service';

@Component({
  selector: 'app-huyen',
  templateUrl: './huyen.component.html',
  styleUrls: ['./huyen.component.css']
})
export class HuyenComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public HuyenService: HuyenService,
    public TinhService: TinhService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.getTinhToList();
    this.onSearch();
  }
  getTinhToList() {
    this.isShowLoading = true;
    this.TinhService.GetAllToListAsync().subscribe(
      res => {
        this.TinhService.list = (res as Tinh[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  getToList() {
    this.isShowLoading = true;
    this.HuyenService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.HuyenService.list = (res as Huyen[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.dataSource = new MatTableDataSource(this.HuyenService.list);
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
      this.HuyenService.list = this.dataSource.filteredData as Huyen[];
    }
    else {
      this.getToList();
    }
  }
  onSave(element: Huyen) {
    this.HuyenService.SaveAsync(element).subscribe(
      res => {
        this.onSearch();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDelete(element: Huyen) {
    if (confirm(environment.DeleteConfirm)) {
      this.HuyenService.RemoveAsync(element.ID).subscribe(
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
    this.HuyenService.SaveListAsync(this.HuyenService.list).subscribe(
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

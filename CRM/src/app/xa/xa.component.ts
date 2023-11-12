import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Huyen } from 'src/app/shared/Huyen.model';
import { HuyenService } from 'src/app/shared/Huyen.service';
import { Xa } from 'src/app/shared/Xa.model';
import { XaService } from 'src/app/shared/Xa.service';

@Component({
  selector: 'app-xa',
  templateUrl: './xa.component.html',
  styleUrls: ['./xa.component.css']
})
export class XaComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public HuyenService: HuyenService,
    public XaService: XaService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.getHuyenToList();
    this.onSearch();
  }
  getHuyenToList() {
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
  getToList() {
    this.isShowLoading = true;
    this.XaService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.XaService.list = (res as Xa[]).sort((a, b) => (a.ParentID > b.ParentID ? 1 : -1));
        this.dataSource = new MatTableDataSource(this.XaService.list);
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
      this.XaService.list = this.dataSource.filteredData as Huyen[];
    }
    else {
      this.getToList();
    }
  }
  onSave(element: Xa) {
    this.XaService.SaveAsync(element).subscribe(
      res => {
        this.onSearch();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDelete(element: Xa) {
    if (confirm(environment.DeleteConfirm)) {
      this.XaService.RemoveAsync(element.ID).subscribe(
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
    this.XaService.SaveListAsync(this.XaService.list).subscribe(
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

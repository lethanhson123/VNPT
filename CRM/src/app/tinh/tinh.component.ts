import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Tinh } from 'src/app/shared/Tinh.model';
import { TinhService } from 'src/app/shared/Tinh.service';

@Component({
  selector: 'app-tinh',
  templateUrl: './tinh.component.html',
  styleUrls: ['./tinh.component.css']
})
export class TinhComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public TinhService: TinhService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.onSearch();
  }
  getToList() {
    this.isShowLoading = true;
    this.TinhService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.TinhService.list = (res as Tinh[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.dataSource = new MatTableDataSource(this.TinhService.list);
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
      this.TinhService.list = this.dataSource.filteredData as Tinh[];
    }
    else {
      this.getToList();
    }
  }
  onSave(element: Tinh) {
    this.TinhService.SaveAsync(element).subscribe(
      res => {
        this.onSearch();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDelete(element: Tinh) {
    if (confirm(environment.DeleteConfirm)) {
      this.TinhService.RemoveAsync(element.ID).subscribe(
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
    this.TinhService.SaveListAsync(this.TinhService.list).subscribe(
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

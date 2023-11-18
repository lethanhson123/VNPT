import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { GoiCuoc } from 'src/app/shared/GoiCuoc.model';
import { GoiCuocService } from 'src/app/shared/GoiCuoc.service';
import { DichVu } from 'src/app/shared/DichVu.model';
import { DichVuService } from 'src/app/shared/DichVu.service';

@Component({
  selector: 'app-goi-cuoc',
  templateUrl: './goi-cuoc.component.html',
  styleUrls: ['./goi-cuoc.component.css']
})
export class GoiCuocComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  constructor(
    public GoiCuocService: GoiCuocService,
    public DichVuService: DichVuService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.getDichVuToList();
    this.onSearch();
  }
  getDichVuToList() {
    this.isShowLoading = true;
    this.DichVuService.GetAllToListAsync().subscribe(
      res => {
        this.DichVuService.list = (res as DichVu[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  getToList() {
    this.isShowLoading = true;
    this.GoiCuocService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.GoiCuocService.list = (res as GoiCuoc[]).sort((a, b) => (a.Thang > b.Thang ? 1 : -1));
        this.dataSource = new MatTableDataSource(this.GoiCuocService.list);
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
      this.GoiCuocService.list = this.dataSource.filteredData;
    }
    else {
      this.getToList();
    }
  }
  onSave(element: GoiCuoc) {
    this.GoiCuocService.SaveAsync(element).subscribe(
      res => {
        this.onSearch();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onDelete(element: GoiCuoc) {
    if (confirm(environment.DeleteConfirm)) {
      this.GoiCuocService.RemoveAsync(element.ID).subscribe(
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
import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { PhongBan } from 'src/app/shared/PhongBan.model';
import { PhongBanService } from 'src/app/shared/PhongBan.service';

@Component({
  selector: 'app-phong-ban',
  templateUrl: './phong-ban.component.html',
  styleUrls: ['./phong-ban.component.css']
})
export class PhongBanComponent implements OnInit {

  dataSource: MatTableDataSource<any>;  
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  URLSub: string = environment.DomainDestination + "PhongBanInfo";
  constructor(    
    public PhongBanService: PhongBanService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {    
    this.onSearch();
  }
  getToList() {
    this.isShowLoading = true;
    this.PhongBanService.GetAllToListAsync().subscribe(
      res => {
        this.PhongBanService.list = res as PhongBan[];
        this.dataSource = new MatTableDataSource(this.PhongBanService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
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
}

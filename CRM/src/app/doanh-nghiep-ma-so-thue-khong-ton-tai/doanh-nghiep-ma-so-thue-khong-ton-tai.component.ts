import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { DoanhNghiep } from 'src/app/shared/DoanhNghiep.model';
import { DoanhNghiepService } from 'src/app/shared/DoanhNghiep.service';
import { DownloadService } from 'src/app/shared/Download.service';

@Component({
  selector: 'app-doanh-nghiep-ma-so-thue-khong-ton-tai',
  templateUrl: './doanh-nghiep-ma-so-thue-khong-ton-tai.component.html',
  styleUrls: ['./doanh-nghiep-ma-so-thue-khong-ton-tai.component.css']
})
export class DoanhNghiepMaSoThueKhongTonTaiComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;  
  URLSub: string = environment.DomainDestination + "DoanhNghiepInfo";
  constructor(
    public DoanhNghiepService: DoanhNghiepService,    
    public DownloadService: DownloadService, 
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.onSearch();    
  }
  onSearch() {
    if (this.searchString.length > 0) {
      this.dataSource.filter = this.searchString.toLowerCase();
      this.DoanhNghiepService.list = this.dataSource.filteredData as DoanhNghiep[];
    }
    else {
      this.GetToList();
    }
  }
  GetToList() {
    this.isShowLoading = true;
    this.DoanhNghiepService.GetMaSoThueKhongTonTaiToListAsync().subscribe(
      res => {
        this.DoanhNghiepService.list = (res as DoanhNghiep[]).sort((a, b) => (a.HuyenID > b.HuyenID ? 1 : -1));

        if (this.DoanhNghiepService.list.length > environment.ItemCount) {
          this.DoanhNghiepService.listView = this.DoanhNghiepService.list.slice(0, environment.ItemCount);
        }
        else {
          this.DoanhNghiepService.listView = this.DoanhNghiepService.list;
        }
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onDownloadExcelFileDoanhNghiep() {
    this.isShowLoading = true;
    this.DownloadService.DoanhNghiepMaSoThueKhongTonTaiToExcelAsync().subscribe(
      res => {
        window.open(res.toString(), "_blank");
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
}

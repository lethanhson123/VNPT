import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/Notification.service';
import { DownloadService } from 'src/app/shared/Download.service';

import { Huyen } from 'src/app/shared/Huyen.model';
import { HuyenService } from 'src/app/shared/Huyen.service';
import { Xa } from 'src/app/shared/Xa.model';
import { XaService } from 'src/app/shared/Xa.service';

import { DoanhNghiep } from 'src/app/shared/DoanhNghiep.model';
import { DoanhNghiepService } from 'src/app/shared/DoanhNghiep.service';

@Component({
  selector: 'app-doanh-nghiep',
  templateUrl: './doanh-nghiep.component.html',
  styleUrls: ['./doanh-nghiep.component.css']
})
export class DoanhNghiepComponent implements OnInit {

  @ViewChild('DoanhNghiepSort') DoanhNghiepSort: MatSort;
  @ViewChild('DoanhNghiepPaginator') DoanhNghiepPaginator: MatPaginator;

  IsShowSearch: boolean = false;

  constructor(
    private dialog: MatDialog,

    public NotificationService: NotificationService,
    public DownloadService: DownloadService,

    public HuyenService: HuyenService,
    public XaService: XaService,

    public DoanhNghiepService: DoanhNghiepService,
  ) { }

  ngOnInit(): void {  
    this.HuyenSearch();
    this.XaSearch();
  }

  HuyenSearch() {
    this.HuyenService.ComponentGetAllToListAsync();
  }
  XaSearch() {
    this.XaService.ComponentGetAllToListAsync();
  }

  
  DoanhNghiepSearch() {
    this.DoanhNghiepService.IsShowLoading = true;    
    this.DoanhNghiepService.GetBySearchStringToListAsync().subscribe(
      res => {
        this.DoanhNghiepService.List = (res as DoanhNghiep[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
        this.DoanhNghiepService.DataSource = new MatTableDataSource(this.DoanhNghiepService.List);
        this.DoanhNghiepService.DataSource.sort = this.DoanhNghiepSort;
        this.DoanhNghiepService.DataSource.paginator = this.DoanhNghiepPaginator;
        this.DoanhNghiepService.IsShowLoading = false;
      },
      err => {
        this.DoanhNghiepService.IsShowLoading = false;
      }
    );
  }
  DoanhNghiepAdd(ID: number) {

  }

  SetIsShowSearch() {
    this.IsShowSearch = !this.IsShowSearch;
  }

}

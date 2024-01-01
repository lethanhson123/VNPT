import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { DoanhNghiep } from 'src/app/shared/DoanhNghiep.model';
import { DoanhNghiepService } from 'src/app/shared/DoanhNghiep.service';
import { Huyen } from 'src/app/shared/Huyen.model';
import { HuyenService } from 'src/app/shared/Huyen.service';
import { Xa } from 'src/app/shared/Xa.model';
import { XaService } from 'src/app/shared/Xa.service';

@Component({
  selector: 'app-doanh-nghiep',
  templateUrl: './doanh-nghiep.component.html',
  styleUrls: ['./doanh-nghiep.component.css']
})
export class DoanhNghiepComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  xaID: number = environment.InitializationNumber;
  huyenID: number = environment.InitializationNumber;
  URLSub: string = environment.DomainDestination + "DoanhNghiepCA";
  constructor(
    public DoanhNghiepService: DoanhNghiepService,
    public HuyenService: HuyenService,
    public XaService: XaService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.GetHuyenToListAsync();
    
  }
  GetHuyenToListAsync() {
    this.HuyenService.GetAllToListAsync().subscribe(
      res => {
        this.HuyenService.list = (res as Huyen[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.GetXaToListAsync();
      },
      err => {
      }
    );
  }
  GetXaToListAsync() {
    this.XaService.GetByParentIDToListAsync(this.huyenID).subscribe(
      res => {
        this.XaService.list = (res as Xa[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)); 
        this.onSearch();       
      },
      err => {
      }
    );
  }
  GetToList() {
    this.isShowLoading = true;
    this.DoanhNghiepService.GetCAByHuyenIDAndXaIDOrSearchStringToListAsync(this.huyenID, this.xaID, this.searchString).subscribe(
      res => {
        this.DoanhNghiepService.list = (res as DoanhNghiep[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.dataSource = new MatTableDataSource(this.DoanhNghiepService.list);
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
    this.GetToList();
  }
  onChangeHuyenID() {
    this.GetXaToListAsync();
  }
}

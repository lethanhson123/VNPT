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
import { Report } from 'src/app/shared/Report.model';
import { ReportService } from 'src/app/shared/Report.service';
import { YearMonth } from 'src/app/shared/YearMonth.model';
import { DownloadService } from 'src/app/shared/Download.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  dataSourceReport004: MatTableDataSource<any>;
  @ViewChild(MatSort) sortReport004: MatSort;
  @ViewChild(MatPaginator) paginatorReport004: MatPaginator;

  isShowLoading: boolean = false;  
  huyenID: number = 1;
  xaID: number = 1;
  searchString: string = environment.InitializationString;
  URLSub: string = environment.DomainDestination + "DoanhNghiepInfo";
  doanhThu: number = environment.InitializationNumber;
  constructor(    
    public HuyenService: HuyenService,
    public XaService: XaService,
    public ReportService: ReportService,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,
  ) { }

  ngOnInit(): void {
    this.GetHuyenToListAsync();
  }
  onSearch() {
    this.Report004Async();
  }
  Report004Async() {
    this.isShowLoading = true;
    this.ReportService.Report004Async(this.huyenID, this.xaID, this.searchString).subscribe(
      res => {
        this.ReportService.listReport004 = (res as Report[]).sort((a, b) => (a.DoanhThu < b.DoanhThu ? 1 : -1));
        this.dataSourceReport004 = new MatTableDataSource(this.ReportService.listReport004.sort((a, b) => (a.DoanhThu < b.DoanhThu ? 1 : -1)));
        this.dataSourceReport004.sort = this.sortReport004;
        this.dataSourceReport004.paginator = this.paginatorReport004;
        for (let i = 0; i < this.ReportService.listReport004.length; i++) {
          this.doanhThu = this.doanhThu + this.ReportService.listReport004[i].DoanhThu;
        }
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onChangeHuyenID() {
    this.GetXaToListAsync();
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
  onDownloadExcelFile() {
    this.isShowLoading = true;    
    this.DownloadService.Report0004ToExcelAsync(this.huyenID, this.xaID, this.searchString).subscribe(
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

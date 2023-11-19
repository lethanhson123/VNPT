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
  selector: 'app-dashboard-ca',
  templateUrl: './dashboard-ca.component.html',
  styleUrls: ['./dashboard-ca.component.css']
})
export class DashboardCAComponent implements OnInit {


  dataSourceReportVNPT003: MatTableDataSource<any>;
  @ViewChild('sortReportVNPT003') sortReportVNPT003: MatSort;
  @ViewChild('paginatorReportVNPT003') paginatorReportVNPT003: MatPaginator;


  isShowLoading: boolean = false;
  huyenID: number = 1;
  xaID: number = 1;
  dichVuID: number = environment.CAID;
  phongBanID: number = 1;
  nhanVienID: number = 1;
  searchString: string = environment.InitializationString;
  URLSub: string = environment.DomainDestination + "DoanhNghiepInfo";
  doanhThuTongHop: number = environment.InitializationNumber;
  doanhThuDichVu: number = environment.InitializationNumber;
  doanhThuPhongBan: number = environment.InitializationNumber;
  doanhThuNhanVien: number = environment.InitializationNumber;
  year: number = new Date().getFullYear();
  month: number = new Date().getMonth();
  constructor(
    public HuyenService: HuyenService,
    public XaService: XaService,
    public ReportService: ReportService,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,
  ) { }

  ngOnInit(): void {
    this.GetHuyenToListAsync();
    this.GetYearToList();
    this.GetMonthToList();        
  }

  GetYearToList() {
    this.DownloadService.GetYearToList().then(res => {
      this.DownloadService.listYear = res as YearMonth[];
    });
  }
  GetMonthToList() {
    this.DownloadService.GetMonthToList().then(res => {
      this.DownloadService.listMonth = res as YearMonth[];
    });
  }
  ReportVNPT003Async() {
    this.isShowLoading = true;
    this.ReportService.ReportVNPT003Async(this.huyenID, this.xaID, this.searchString, this.dichVuID, this.year, this.month).subscribe(
      res => {
        this.ReportService.listReportVNPT003 = (res as Report[]).sort((a, b) => (a.DoanhThu < b.DoanhThu ? 1 : -1));
        this.dataSourceReportVNPT003 = new MatTableDataSource(this.ReportService.listReportVNPT003);
        this.dataSourceReportVNPT003.sort = this.sortReportVNPT003;
        this.dataSourceReportVNPT003.paginator = this.paginatorReportVNPT003;
        for (let i = 0; i < this.ReportService.listReportVNPT003.length; i++) {
          this.doanhThuDichVu = this.doanhThuDichVu + this.ReportService.listReportVNPT003[i].DoanhThu;
        }        
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  
 
  GetHuyenToListAsync() {
    this.HuyenService.GetAllToListAsync().subscribe(
      res => {
        this.HuyenService.list = (res as Huyen[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));        
      },
      err => {
      }
    );
  }
  GetXaToListAsync() {
    this.XaService.GetByParentIDToListAsync(this.huyenID).subscribe(
      res => {
        this.XaService.list = (res as Xa[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.ReportVNPT003Async();
      },
      err => {
      }
    );
  }
  onSearchReportVNPT003() {
    this.ReportVNPT003Async();
  }
  
  onDownloadExcelFileReportVNPT003() {
    this.isShowLoading = true;
    this.DownloadService.ReportVNPT003ToExcelAsync(this.huyenID, this.xaID, this.searchString, this.dichVuID, this.year, this.month).subscribe(
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
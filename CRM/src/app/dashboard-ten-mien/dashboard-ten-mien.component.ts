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
  selector: 'app-dashboard-ten-mien',
  templateUrl: './dashboard-ten-mien.component.html',
  styleUrls: ['./dashboard-ten-mien.component.css']
})
export class DashboardTenMienComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  isShowLoading: boolean = false;
  huyenID: number = 1;
  xaID: number = 1;
  dichVuID: number = environment.TenMienID;
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
        this.dataSource = new MatTableDataSource(this.ReportService.listReportVNPT003.sort((a, b) => (a.DoanhThu < b.DoanhThu ? 1 : -1)));
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        for (let i = 0; i < this.ReportService.listReportVNPT003.length; i++) {
          this.doanhThuDichVu = this.doanhThuDichVu + this.ReportService.listReportVNPT003[i].DoanhThu;
        }
        if (this.ReportService.listReportVNPT003.length > environment.ItemCount) {
          this.ReportService.listReportVNPT003View = this.ReportService.listReportVNPT003.slice(0, environment.ItemCount);
        }
        else {
          this.ReportService.listReportVNPT003View = this.ReportService.listReportVNPT003;
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
        if (this.HuyenService.list) {
          if (this.HuyenService.list.length > 0) {
            this.huyenID = this.HuyenService.list[0].ID;
          }
        }
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
        if (this.XaService.list) {
          if (this.XaService.list.length > 0) {
            this.xaID = this.XaService.list[0].ID;
          }
        }
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
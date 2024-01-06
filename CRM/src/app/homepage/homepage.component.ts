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
import { DichVu } from 'src/app/shared/DichVu.model';
import { DichVuService } from 'src/app/shared/DichVu.service';
import { NhanVien } from 'src/app/shared/NhanVien.model';
import { NhanVienService } from 'src/app/shared/NhanVien.service';
import { PhongBan } from 'src/app/shared/PhongBan.model';
import { PhongBanService } from 'src/app/shared/PhongBan.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  dataSourceReportVNPT001: MatTableDataSource<any>;
  @ViewChild('sortReportVNPT001') sortReportVNPT001: MatSort;
  @ViewChild('paginatorReportVNPT001') paginatorReportVNPT001: MatPaginator;

  dataSourceReportVNPT003: MatTableDataSource<any>;
  @ViewChild('sortReportVNPT003') sortReportVNPT003: MatSort;
  @ViewChild('paginatorReportVNPT003') paginatorReportVNPT003: MatPaginator;

  dataSourceReportVNPT004: MatTableDataSource<any>;
  @ViewChild('sortReportVNPT004') sortReportVNPT004: MatSort;
  @ViewChild('paginatorReportVNPT004') paginatorReportVNPT004: MatPaginator;

  dataSourceReportVNPT005: MatTableDataSource<any>;
  @ViewChild('sortReportVNPT005') sortReportVNPT005: MatSort;
  @ViewChild('paginatorReportVNPT005') paginatorReportVNPT005: MatPaginator;

  isShowLoading: boolean = false;
  huyenID: number = 1;
  xaID: number = 1;
  dichVuID: number = 20;
  phongBanID: number = 1;
  nhanVienID: number = 1;
  searchString: string = environment.InitializationString;
  URLSub: string = environment.DomainDestination + "DoanhNghiepInfo";
  doanhThuTongHop: number = environment.InitializationNumber;
  doanhThuDichVu: number = environment.InitializationNumber;
  doanhThuPhongBan: number = environment.InitializationNumber;
  doanhThuNhanVien: number = environment.InitializationNumber;
  year: number = environment.InitializationNumber;
  month: number = environment.InitializationNumber;
  constructor(
    public HuyenService: HuyenService,
    public XaService: XaService,
    public ReportService: ReportService,
    public DichVuService: DichVuService,
    public NhanVienService: NhanVienService,
    public PhongBanService: PhongBanService,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,
  ) { }

  ngOnInit(): void {
    this.GetHuyenToListAsync();
    this.GetYearToList();
    this.GetMonthToList();
    this.GetDichVuToListAsync();
    this.GetPhongBanToListAsync();
    this.GetNhanVienToListAsync();
  }
  GetYearAndMonth() {
    this.year = new Date().getFullYear();
    this.month = new Date().getMonth();
    if (this.month == 0) {
      this.month = 12;
      this.year = this.year - 1;
    }
  }
  GetYearToList() {
    this.DownloadService.GetYearToList().then(res => {
      this.DownloadService.listYear = res as YearMonth[];
      this.GetYearAndMonth();
    });
  }
  GetMonthToList() {
    this.DownloadService.GetMonthToList().then(res => {
      this.DownloadService.listMonth = res as YearMonth[];
      this.GetYearAndMonth();
    });
  }
  GetDichVuToListAsync() {
    this.DichVuService.GetAllToListAsync().subscribe(
      res => {
        this.DichVuService.list = (res as DichVu[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
      },
      err => {
      }
    );
  }
  GetNhanVienToListAsync() {
    this.NhanVienService.GetAllToListAsync().subscribe(
      res => {
        this.NhanVienService.list = (res as NhanVien[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
      },
      err => {
      }
    );
  }
  GetPhongBanToListAsync() {
    this.PhongBanService.GetAllToListAsync().subscribe(
      res => {
        this.PhongBanService.list = (res as PhongBan[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
      },
      err => {
      }
    );
  }
  ReportVNPT001Async() {
    this.isShowLoading = true;
    this.ReportService.ReportVNPT001Async(this.huyenID, this.xaID, this.searchString, this.year, this.month).subscribe(
      res => {
        this.ReportService.listReportVNPT001 = (res as Report[]).sort((a, b) => (a.DoanhThu < b.DoanhThu ? 1 : -1));
        this.dataSourceReportVNPT001 = new MatTableDataSource(this.ReportService.listReportVNPT001);
        this.dataSourceReportVNPT001.sort = this.sortReportVNPT001;
        this.dataSourceReportVNPT001.paginator = this.paginatorReportVNPT001;
        for (let i = 0; i < this.ReportService.listReportVNPT001.length; i++) {
          this.doanhThuTongHop = this.doanhThuTongHop + this.ReportService.listReportVNPT001[i].DoanhThu;
        }        
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
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
  ReportVNPT004Async() {
    this.isShowLoading = true;
    this.ReportService.ReportVNPT004Async(this.phongBanID, this.year).subscribe(
      res => {
        this.ReportService.listReportVNPT004 = (res as Report[]).sort((a, b) => (a.DoanhThu < b.DoanhThu ? 1 : -1));
        this.dataSourceReportVNPT004 = new MatTableDataSource(this.ReportService.listReportVNPT004);
        this.dataSourceReportVNPT004.sort = this.sortReportVNPT004;
        this.dataSourceReportVNPT004.paginator = this.paginatorReportVNPT004;
        for (let i = 0; i < this.ReportService.listReportVNPT004.length; i++) {
          this.doanhThuPhongBan = this.doanhThuPhongBan + this.ReportService.listReportVNPT004[i].DoanhThu;
        }        
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  ReportVNPT005Async() {
    this.isShowLoading = true;
    this.ReportService.ReportVNPT005Async(this.nhanVienID, this.year).subscribe(
      res => {
        this.ReportService.listReportVNPT005 = (res as Report[]).sort((a, b) => (a.DoanhThu < b.DoanhThu ? 1 : -1));
        this.dataSourceReportVNPT005 = new MatTableDataSource(this.ReportService.listReportVNPT005);
        this.dataSourceReportVNPT005.sort = this.sortReportVNPT005;
        this.dataSourceReportVNPT005.paginator = this.paginatorReportVNPT005;
        for (let i = 0; i < this.ReportService.listReportVNPT005.length; i++) {
          this.doanhThuNhanVien = this.doanhThuNhanVien + this.ReportService.listReportVNPT005[i].DoanhThu;
        }        
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onChangeHuyenID() {
    //this.onSearchReportVNPT001();
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
        //this.onSearchReportVNPT001();
      },
      err => {
      }
    );
  }
  GetXaToListAsync() {
    this.XaService.GetByParentIDToListAsync(this.huyenID).subscribe(
      res => {
        this.XaService.list = (res as Xa[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        //this.onSearchReportVNPT001();
      },
      err => {
      }
    );
  }
  onSearchReportVNPT001() {
    this.ReportVNPT001Async();
  }
  onSearchReportVNPT003() {
    this.ReportVNPT003Async();
  }
  onSearchReportVNPT004() {
    if (this.searchString.length > 0) {
      this.dataSourceReportVNPT004.filter = this.searchString.toLowerCase();
    }
    else {
      this.ReportVNPT004Async();
    }
  }
  onSearchReportVNPT005() {
    if (this.searchString.length > 0) {
      this.dataSourceReportVNPT005.filter = this.searchString.toLowerCase();
    }
    else {
      this.ReportVNPT005Async();
    }
  }
  onDownloadExcelFileReportVNPT001() {
    this.isShowLoading = true;
    this.DownloadService.ReportVNPT001ToExcelAsync(this.huyenID, this.xaID, this.searchString, this.year, this.month).subscribe(
      res => {
        window.open(res.toString(), "_blank");
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
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
  onDownloadExcelFileReportVNPT004() {
    this.isShowLoading = true;
    this.DownloadService.ReportVNPT004ToExcelAsync(this.phongBanID, this.year).subscribe(
      res => {
        window.open(res.toString(), "_blank");
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onDownloadExcelFileReportVNPT005() {
    this.isShowLoading = true;
    this.DownloadService.ReportVNPT005ToExcelAsync(this.nhanVienID, this.year).subscribe(
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

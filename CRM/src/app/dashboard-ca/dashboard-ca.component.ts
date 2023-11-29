import { Component, OnInit, ViewChild } from '@angular/core';
import { ChartOptions, ChartType, ChartDataSets, Chart, ChartConfiguration, ChartData } from 'chart.js';
import { Color, Label, SingleDataSet, monkeyPatchChartJsLegend, monkeyPatchChartJsTooltip } from 'ng2-charts';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
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
import { NhanVien } from 'src/app/shared/NhanVien.model';
import { NhanVienService } from 'src/app/shared/NhanVien.service';
import { PhongBan } from 'src/app/shared/PhongBan.model';
import { PhongBanService } from 'src/app/shared/PhongBan.service';
import { NhanVienTaiKhoan } from 'src/app/shared/NhanVienTaiKhoan.model';
import { NhanVienTaiKhoanService } from 'src/app/shared/NhanVienTaiKhoan.service';
import { DoanhNghiepDichVuCA } from 'src/app/shared/DoanhNghiepDichVuCA.model';
import { DoanhNghiepDichVuCAService } from 'src/app/shared/DoanhNghiepDichVuCA.service';
import { DichVuChiTieu } from 'src/app/shared/DichVuChiTieu.model';
import { DichVuChiTieuService } from 'src/app/shared/DichVuChiTieu.service';
import { DoanhNghiepDichVuCADetailComponent } from '../doanh-nghiep-dich-vu-ca/doanh-nghiep-dich-vu-cadetail/doanh-nghiep-dich-vu-cadetail.component';

@Component({
  selector: 'app-dashboard-ca',
  templateUrl: './dashboard-ca.component.html',
  styleUrls: ['./dashboard-ca.component.css']
})
export class DashboardCAComponent implements OnInit {


  dataSourceReportVNPT003: MatTableDataSource<any>;
  @ViewChild('sortReportVNPT003') sortReportVNPT003: MatSort;
  @ViewChild('paginatorReportVNPT003') paginatorReportVNPT003: MatPaginator;

  dataSource1: MatTableDataSource<any>;
  @ViewChild('sort1') sort1: MatSort;
  @ViewChild('paginator1') paginator1: MatPaginator;

  dataSource2: MatTableDataSource<any>;
  @ViewChild('sort2') sort2: MatSort;
  @ViewChild('paginator2') paginator2: MatPaginator;

  dataSource3: MatTableDataSource<any>;
  @ViewChild('sort3') sort3: MatSort;
  @ViewChild('paginator3') paginator3: MatPaginator;

  dataSource4: MatTableDataSource<any>;
  @ViewChild('sort4') sort4: MatSort;
  @ViewChild('paginator4') paginator4: MatPaginator;

  dataSource5: MatTableDataSource<any>;
  @ViewChild('sort5') sort5: MatSort;
  @ViewChild('paginator5') paginator5: MatPaginator;

  dataSource6: MatTableDataSource<any>;
  @ViewChild('sort6') sort6: MatSort;
  @ViewChild('paginator6') paginator6: MatPaginator;

  dataSource7: MatTableDataSource<any>;
  @ViewChild('sort7') sort7: MatSort;
  @ViewChild('paginator7') paginator7: MatPaginator;

  dataSource8: MatTableDataSource<any>;
  @ViewChild('sort8') sort8: MatSort;
  @ViewChild('paginator8') paginator8: MatPaginator;

  dataSource9: MatTableDataSource<any>;
  @ViewChild('sort9') sort9: MatSort;
  @ViewChild('paginator9') paginator9: MatPaginator;


  isShowLoading: boolean = false;
  huyenID: number = 1;
  xaID: number = 1;
  dichVuID: number = environment.CAID;
  phongBanID: number = 1;
  nhanVienID: number = environment.InitializationNumber;
  searchString: string = environment.InitializationString;
  searchString1: string = environment.InitializationString;
  searchString2: string = environment.InitializationString;
  searchString3: string = environment.InitializationString;
  searchString4: string = environment.InitializationString;
  searchString5: string = environment.InitializationString;
  searchString6: string = environment.InitializationString;
  searchString7: string = environment.InitializationString;
  searchString8: string = environment.InitializationString;
  URLSub: string = environment.DomainDestination + "DoanhNghiepInfo";
  URLNhanVien: string = environment.DomainDestination + "NhanVienInfo";
  doanhThuTongHop: number = environment.InitializationNumber;
  doanhThuDichVu: number = environment.InitializationNumber;
  doanhThuPhongBan: number = environment.InitializationNumber;
  doanhThuNhanVien: number = environment.InitializationNumber;
  year: number = new Date().getFullYear();
  month: number = new Date().getMonth() + 1;
  constructor(
    public HuyenService: HuyenService,
    public XaService: XaService,
    public ReportService: ReportService,
    public NhanVienService: NhanVienService,
    public PhongBanService: PhongBanService,
    public NhanVienTaiKhoanService: NhanVienTaiKhoanService,
    public DoanhNghiepDichVuCAService: DoanhNghiepDichVuCAService,
    public DichVuChiTieuService: DichVuChiTieuService,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,
    private dialog: MatDialog
  ) {
    var lastUpdatedMembershipID = localStorage.getItem(environment.NhanVienID);
    if (lastUpdatedMembershipID) {
      this.nhanVienID = Number(lastUpdatedMembershipID);
    }
  }

  ngOnInit(): void {
    this.GetHuyenToListAsync();
    this.GetYearToList();
    this.GetMonthToList();
    this.NhanVienGetToList();
    this.PhongBanGetToList();
    this.NhanVienTaiKhoanGetToList();
    this.onSearchReportCA201();
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

  ReportCA201Async() {
    this.isShowLoading = true;
    this.ReportService.ReportCA201Async(this.year, this.month).subscribe(
      res => {
        this.ReportService.formData = (res as Report);
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );  
  }
  ReportCA202Async() {
    this.isShowLoading = true;
    this.ReportService.ReportCA202Async(this.year, this.month).subscribe(
      res => {
        this.ReportService.listReportCA202 = (res as Report[]);
        let labelArray = [];
        let dataArray001 = [];
        let dataArray002 = [];
        let dataArray003 = [];
        let dataArray004 = [];
        for (let i = 0; i < this.ReportService.listReportCA202.length; i++) {
          labelArray.push(this.ReportService.listReportCA202[i].PhongBanName);
          dataArray001.push(this.ReportService.listReportCA202[i].PhatTrien);
          dataArray002.push(this.ReportService.listReportCA202[i].PhatTrienChiTieu);
          dataArray003.push(this.ReportService.listReportCA202[i].GiaHan);
          dataArray004.push(this.ReportService.listReportCA202[i].GiaHanChiTieu);
        }
        let label001: string = 'Phát triển mới';
        let label002: string = 'Chỉ tiêu';
        let label003: string = 'Gia hạn';
        let label004: string = 'Chỉ tiêu';
        this.ChartLabelsReportCA202PhatTrien = labelArray;
        this.ChartDataReportCA202PhatTrien = [
          { data: dataArray001, label: label001, stack: 'a' },
          { data: dataArray002, label: label002, stack: 'b' }
        ];
        this.ChartLabelsReportCA202GiaHan = labelArray;
        this.ChartDataReportCA202GiaHan = [
          { data: dataArray003, label: label003, stack: 'a' },
          { data: dataArray004, label: label004, stack: 'b' }
        ];
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchReportCA201() {
    this.ReportCA201Async();
    this.ReportCA202Async();
  }

  public ChartOptionsReportCA202PhatTrien: ChartOptions = {
    responsive: true,
    tooltips: {
      callbacks: {
        label: function (tooltipItem, data) {
          return Number(tooltipItem.yLabel).toFixed(0).replace(/./g, function (c, i, a) {
            return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "." + c : c;
          });
        }
      }
    }
  };
  public ChartColorsReportCA202PhatTrien: Color[] = [
    { backgroundColor: 'blue' },
  ]
  public ChartLabelsReportCA202PhatTrien: Label[] = [];
  public ChartTypeReportCA202PhatTrien: ChartType = 'bar';
  public ChartLegendReportCA202PhatTrien = true;
  public ChartPluginsReportCA202PhatTrien = [];

  public ChartDataReportCA202PhatTrien: ChartDataSets[] = [
  ];

  public ChartOptionsReportCA202GiaHan: ChartOptions = {
    responsive: true,
    tooltips: {
      callbacks: {
        label: function (tooltipItem, data) {
          return Number(tooltipItem.yLabel).toFixed(0).replace(/./g, function (c, i, a) {
            return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "." + c : c;
          });
        }
      }
    }
  };
  public ChartColorsReportCA202GiaHan: Color[] = [
    { backgroundColor: 'blue' },
  ]
  public ChartLabelsReportCA202GiaHan: Label[] = [];
  public ChartTypeReportCA202GiaHan: ChartType = 'bar';
  public ChartLegendReportCA202GiaHan = true;
  public ChartPluginsReportCA202GiaHan = [];

  public ChartDataReportCA202GiaHan: ChartDataSets[] = [
  ];




  NhanVienTaiKhoanGetToList() {
    this.isShowLoading = true;
    this.NhanVienTaiKhoanService.GetAllAndEmptyToListAsync().subscribe(
      res => {
        this.NhanVienTaiKhoanService.list = (res as NhanVienTaiKhoan[]).sort((a, b) => (a.ParentID > b.ParentID ? 1 : -1));
        this.dataSource8 = new MatTableDataSource(this.NhanVienTaiKhoanService.list);
        this.dataSource8.sort = this.sort8;
        this.dataSource8.paginator = this.paginator8;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  NhanVienGetToList() {
    this.isShowLoading = true;
    this.NhanVienService.GetAllToListAsync().subscribe(
      res => {
        this.NhanVienService.list = (res as NhanVien[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  PhongBanGetToList() {
    this.isShowLoading = true;
    this.PhongBanService.GetAllToListAsync().subscribe(
      res => {
        this.PhongBanService.list = (res as PhongBan[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  GetHuyenToListAsync() {
    this.HuyenService.GetSQLByNhanVienID_ActiveAsync().subscribe(
      res => {
        this.HuyenService.list = (res as Huyen[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.onSearchReportCA001();
      },
      err => {
      }
    );
  }
  GetXaToListAsync() {
    this.XaService.GetByParentIDToListAsync(this.huyenID).subscribe(
      res => {
        this.XaService.list = (res as Xa[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
      },
      err => {
      }
    );
  }
  onSearchReportVNPT003() {
    if (this.searchString.length > 0) {
      this.dataSourceReportVNPT003.filter = this.searchString.toLowerCase();
    }
    else {
      this.ReportVNPT003Async();
    }
  }
  ReportCA001Async() {
    this.isShowLoading = true;
    this.ReportService.ReportCA101Async(this.huyenID, this.year, this.month, this.nhanVienID).subscribe(
      res => {
        this.ReportService.listReportCA001 = (res as Report[]);
        this.dataSource1 = new MatTableDataSource(this.ReportService.listReportCA001);
        this.dataSource1.sort = this.sort1;
        this.dataSource1.paginator = this.paginator1;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchReportCA001() {
    if (this.searchString.length > 0) {
      this.dataSource1.filter = this.searchString.toLowerCase();
    }
    else {
      this.ReportCA001Async();
    }
  }
  onDownloadExcelFileReportCA001() {
    this.isShowLoading = true;
    this.DownloadService.ReportCA001ToExcelAsync(this.huyenID, this.year, this.month).subscribe(
      res => {
        window.open(res.toString(), "_blank");
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  ReportCA002Async() {
    this.isShowLoading = true;
    this.ReportService.ReportCA102Async(this.huyenID, this.year, this.month, this.nhanVienID).subscribe(
      res => {
        this.ReportService.listReportCA002 = (res as Report[]);
        this.dataSource2 = new MatTableDataSource(this.ReportService.listReportCA002);
        this.dataSource2.sort = this.sort2;
        this.dataSource2.paginator = this.paginator2;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchReportCA002() {
    if (this.searchString.length > 0) {
      this.dataSource2.filter = this.searchString.toLowerCase();
    }
    else {
      this.ReportCA002Async();
    }
  }
  onDownloadExcelFileReportCA002() {
    this.isShowLoading = true;
    this.DownloadService.ReportCA002ToExcelAsync(this.huyenID, this.year, this.month).subscribe(
      res => {
        window.open(res.toString(), "_blank");
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  ReportCA003Async() {
    this.isShowLoading = true;
    this.ReportService.ReportCA103Async(this.huyenID, this.year, this.month, this.nhanVienID).subscribe(
      res => {
        this.ReportService.listReportCA003 = (res as Report[]);
        this.dataSource3 = new MatTableDataSource(this.ReportService.listReportCA003);
        this.dataSource3.sort = this.sort3;
        this.dataSource3.paginator = this.paginator3;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchReportCA003() {
    if (this.searchString.length > 0) {
      this.dataSource3.filter = this.searchString.toLowerCase();
    }
    else {
      this.ReportCA003Async();
    }
  }
  onDownloadExcelFileReportCA003() {
    this.isShowLoading = true;
    this.DownloadService.ReportCA003ToExcelAsync(this.huyenID, this.year, this.month).subscribe(
      res => {
        window.open(res.toString(), "_blank");
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  ReportCA004Async() {
    this.isShowLoading = true;
    this.ReportService.ReportCA104Async(this.huyenID, this.year, this.month, this.nhanVienID).subscribe(
      res => {
        this.ReportService.listReportCA004 = (res as Report[]);
        this.dataSource4 = new MatTableDataSource(this.ReportService.listReportCA004);
        this.dataSource4.sort = this.sort4;
        this.dataSource4.paginator = this.paginator4;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchReportCA004() {
    if (this.searchString.length > 0) {
      this.dataSource4.filter = this.searchString.toLowerCase();
    }
    else {
      this.ReportCA004Async();
    }
  }
  onDownloadExcelFileReportCA004() {
    this.isShowLoading = true;
    this.DownloadService.ReportCA004ToExcelAsync(this.huyenID, this.year, this.month).subscribe(
      res => {
        window.open(res.toString(), "_blank");
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  ReportCA005Async() {
    this.isShowLoading = true;
    this.ReportService.ReportCA105Async(this.huyenID, this.year, this.month, this.nhanVienID).subscribe(
      res => {
        this.ReportService.listReportCA005 = (res as Report[]);
        this.dataSource5 = new MatTableDataSource(this.ReportService.listReportCA005);
        this.dataSource5.sort = this.sort5;
        this.dataSource5.paginator = this.paginator5;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchReportCA005() {
    if (this.searchString.length > 0) {
      this.dataSource5.filter = this.searchString.toLowerCase();
    }
    else {
      this.ReportCA005Async();
    }
  }
  onDownloadExcelFileReportCA005() {
    this.isShowLoading = true;
    this.DownloadService.ReportCA005ToExcelAsync(this.huyenID, this.year, this.month).subscribe(
      res => {
        window.open(res.toString(), "_blank");
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  ReportCA006Async() {
    this.isShowLoading = true;
    this.ReportService.ReportCA106Async(this.huyenID, this.year, this.month, this.nhanVienID).subscribe(
      res => {
        this.ReportService.listReportCA006 = (res as Report[]);
        this.dataSource6 = new MatTableDataSource(this.ReportService.listReportCA006);
        this.dataSource6.sort = this.sort6;
        this.dataSource6.paginator = this.paginator6;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchReportCA006() {
    if (this.searchString.length > 0) {
      this.dataSource6.filter = this.searchString.toLowerCase();
    }
    else {
      this.ReportCA006Async();
    }
  }
  onDownloadExcelFileReportCA006() {
    this.isShowLoading = true;
    this.DownloadService.ReportCA006ToExcelAsync(this.huyenID, this.year, this.month).subscribe(
      res => {
        window.open(res.toString(), "_blank");
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  ReportCA007Async() {
    this.isShowLoading = true;
    this.ReportService.ReportCA107Async(this.huyenID, this.year, this.month, this.nhanVienID).subscribe(
      res => {
        this.ReportService.listReportCA007 = (res as Report[]);
        this.dataSource7 = new MatTableDataSource(this.ReportService.listReportCA007);
        this.dataSource7.sort = this.sort7;
        this.dataSource7.paginator = this.paginator7;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSearchReportCA007() {
    if (this.searchString.length > 0) {
      this.dataSource7.filter = this.searchString.toLowerCase();
    }
    else {
      this.ReportCA007Async();
    }
  }
  onDownloadExcelFileReportCA007() {
    this.isShowLoading = true;
    this.DownloadService.ReportCA007ToExcelAsync(this.huyenID, this.year, this.month).subscribe(
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
  onSearch009() {
    if (this.searchString.length > 0) {
      this.dataSource9.filter = this.searchString.toLowerCase();
    }
    else {
      this.DichVuChiTieuGetToList();
    }
  }
  DichVuChiTieuGetToList() {
    this.isShowLoading = true;
    this.DichVuChiTieuService.GetByNam_ThangToListAsync(this.year, this.month).subscribe(
      res => {
        this.DichVuChiTieuService.list = (res as DichVuChiTieu[]).sort((a, b) => (a.NhanVienID > b.NhanVienID ? 1 : -1));
        this.dataSource9 = new MatTableDataSource(this.DichVuChiTieuService.list);
        this.dataSource9.sort = this.sort9;
        this.dataSource9.paginator = this.paginator9;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onSaveDichVuChiTieu(element: DichVuChiTieu) {
    this.isShowLoading = true;
    this.DichVuChiTieuService.SaveAsync(element).subscribe(
      res => {
        this.onSearch009();
        this.isShowLoading = false;
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.isShowLoading = false;
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }

  onAddReportCA001(ID: any) {
    this.DoanhNghiepDichVuCAService.GetByIDAsync(ID).subscribe(
      res => {
        this.DoanhNghiepDichVuCAService.formData = res as DoanhNghiepDichVuCA;
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(DoanhNghiepDichVuCADetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.onSearchReportCA001();
        });
      },
      err => {
      }
    );
  }
  onAddReportCA002(ID: any) {
    this.DoanhNghiepDichVuCAService.GetByIDAsync(ID).subscribe(
      res => {
        this.DoanhNghiepDichVuCAService.formData = res as DoanhNghiepDichVuCA;
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(DoanhNghiepDichVuCADetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.onSearchReportCA002();
        });
      },
      err => {
      }
    );
  }
  onAddReportCA003(ID: any) {
    this.DoanhNghiepDichVuCAService.GetByIDAsync(ID).subscribe(
      res => {
        this.DoanhNghiepDichVuCAService.formData = res as DoanhNghiepDichVuCA;
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(DoanhNghiepDichVuCADetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.onSearchReportCA003();
        });
      },
      err => {
      }
    );
  }
  onAddReportCA004(ID: any) {
    this.DoanhNghiepDichVuCAService.GetByIDAsync(ID).subscribe(
      res => {
        this.DoanhNghiepDichVuCAService.formData = res as DoanhNghiepDichVuCA;
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(DoanhNghiepDichVuCADetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.onSearchReportCA004();
        });
      },
      err => {
      }
    );
  }
  onAddReportCA005(ID: any) {
    this.DoanhNghiepDichVuCAService.GetByIDAsync(ID).subscribe(
      res => {
        this.DoanhNghiepDichVuCAService.formData = res as DoanhNghiepDichVuCA;
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(DoanhNghiepDichVuCADetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.onSearchReportCA005();
        });
      },
      err => {
      }
    );
  }
}
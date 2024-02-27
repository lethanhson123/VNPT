import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { NotificationService } from 'src/app/shared/notification.service';
import { Huyen } from 'src/app/shared/Huyen.model';
import { HuyenService } from 'src/app/shared/Huyen.service';
import { Xa } from 'src/app/shared/Xa.model';
import { XaService } from 'src/app/shared/Xa.service';
import { LoaiDoanhNghiep } from 'src/app/shared/LoaiDoanhNghiep.model';
import { LoaiDoanhNghiepService } from 'src/app/shared/LoaiDoanhNghiep.service';
import { NganhNgheKinhDoanh } from 'src/app/shared/NganhNgheKinhDoanh.model';
import { NganhNgheKinhDoanhService } from 'src/app/shared/NganhNgheKinhDoanh.service';
import { LoaiTrangThai } from 'src/app/shared/LoaiTrangThai.model';
import { LoaiTrangThaiService } from 'src/app/shared/LoaiTrangThai.service';
import { LoaiDoanhNghiepThanhVien } from 'src/app/shared/LoaiDoanhNghiepThanhVien.model';
import { LoaiDoanhNghiepThanhVienService } from 'src/app/shared/LoaiDoanhNghiepThanhVien.service';
import { DichVu } from 'src/app/shared/DichVu.model';
import { DichVuService } from 'src/app/shared/DichVu.service';
import { NhanVien } from 'src/app/shared/NhanVien.model';
import { NhanVienService } from 'src/app/shared/NhanVien.service';
import { PhongBan } from 'src/app/shared/PhongBan.model';
import { PhongBanService } from 'src/app/shared/PhongBan.service';
import { DoanhNghiep } from 'src/app/shared/DoanhNghiep.model';
import { DoanhNghiepService } from 'src/app/shared/DoanhNghiep.service';
import { DoanhNghiepThanhVien } from 'src/app/shared/DoanhNghiepThanhVien.model';
import { DoanhNghiepThanhVienService } from 'src/app/shared/DoanhNghiepThanhVien.service';
import { DoanhNghiepDichVu } from 'src/app/shared/DoanhNghiepDichVu.model';
import { DoanhNghiepDichVuService } from 'src/app/shared/DoanhNghiepDichVu.service';
import { DoanhNghiepDichVuLichSu } from 'src/app/shared/DoanhNghiepDichVuLichSu.model';
import { DoanhNghiepDichVuLichSuService } from 'src/app/shared/DoanhNghiepDichVuLichSu.service';
import { DoanhNghiepDichVuCA } from 'src/app/shared/DoanhNghiepDichVuCA.model';
import { DoanhNghiepDichVuCAService } from 'src/app/shared/DoanhNghiepDichVuCA.service';
import { Report } from 'src/app/shared/Report.model';
import { ReportService } from 'src/app/shared/Report.service';
import { YearMonth } from 'src/app/shared/YearMonth.model';
import { DownloadService } from 'src/app/shared/Download.service';
import { ChartOptions, ChartType, ChartDataSets, Chart, ChartConfiguration, ChartData } from 'chart.js';
import { Color, Label, SingleDataSet, monkeyPatchChartJsLegend, monkeyPatchChartJsTooltip } from 'ng2-charts';
import { DoanhNghiepDichVuCADetailComponent } from 'src/app/doanh-nghiep-dich-vu-ca/doanh-nghiep-dich-vu-cadetail/doanh-nghiep-dich-vu-cadetail.component';

@Component({
  selector: 'app-doanh-nghiep-info',
  templateUrl: './doanh-nghiep-info.component.html',
  styleUrls: ['./doanh-nghiep-info.component.css']
})
export class DoanhNghiepInfoComponent implements OnInit {

  dataSourceDoanhNghiepDichVuLichSu: MatTableDataSource<any>;
  @ViewChild(MatSort) sortDoanhNghiepDichVuLichSu: MatSort;
  @ViewChild(MatPaginator) paginatorDoanhNghiepDichVuLichSu: MatPaginator;

  dataSourceDoanhNghiepThanhVien: MatTableDataSource<any>;
  @ViewChild('sortDoanhNghiepThanhVien') sortDoanhNghiepThanhVien: MatSort;
  @ViewChild('paginatorDoanhNghiepThanhVien') paginatorDoanhNghiepThanhVien: MatPaginator;

  dataSourceDoanhNghiepDichVu: MatTableDataSource<any>;
  @ViewChild('sortDoanhNghiepDichVu') sortDoanhNghiepDichVu: MatSort;
  @ViewChild('paginatorDoanhNghiepDichVu') paginatorDoanhNghiepDichVu: MatPaginator;

  dataSourceDoanhNghiepDichVuCA: MatTableDataSource<any>;
  @ViewChild('sortDoanhNghiepDichVuCA') sortDoanhNghiepDichVuCA: MatSort;
  @ViewChild('paginatorDoanhNghiepDichVuCA') paginatorDoanhNghiepDichVuCA: MatPaginator;

  dataSourceReport001: MatTableDataSource<any>;
  @ViewChild(MatSort) sortReport001: MatSort;
  @ViewChild(MatPaginator) paginatorReport001: MatPaginator;

  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  URLSub: string = environment.DomainDestination + "DoanhNghiepInfo";

  year: number = new Date().getFullYear();
  month: number = new Date().getMonth();
  yearTitle: number = new Date().getFullYear();
  monthTitle: number = new Date().getMonth();
  doanhThuByMonth: number = environment.InitializationNumber;
  constructor(
    public router: Router,
    public DoanhNghiepService: DoanhNghiepService,
    public DoanhNghiepThanhVienService: DoanhNghiepThanhVienService,
    public HuyenService: HuyenService,
    public XaService: XaService,
    public LoaiDoanhNghiepService: LoaiDoanhNghiepService,
    public NganhNgheKinhDoanhService: NganhNgheKinhDoanhService,
    public LoaiTrangThaiService: LoaiTrangThaiService,
    public NhanVienService: NhanVienService,
    public PhongBanService: PhongBanService,
    public LoaiDoanhNghiepThanhVienService: LoaiDoanhNghiepThanhVienService,
    public DoanhNghiepDichVuService: DoanhNghiepDichVuService,
    public DoanhNghiepDichVuLichSuService: DoanhNghiepDichVuLichSuService,
    public DoanhNghiepDichVuCAService: DoanhNghiepDichVuCAService,
    public DichVuService: DichVuService,
    public ReportService: ReportService,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,
    private dialog: MatDialog
  ) {
    this.router.events.forEach((event) => {
      if (event instanceof NavigationEnd) {
        this.queryString = event.url;
        this.GetYearToList();
        this.GetMonthToList();
      }
    });
  }

  ngOnInit(): void {
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
    });
  }
  GetMonthToList() {
    this.DownloadService.GetMonthToList().then(res => {
      this.DownloadService.listMonth = res as YearMonth[];
      this.GetYearAndMonth();
      this.GetByQueryString();
    });
  }
  GetDichVuToListAsync() {
    this.DichVuService.GetAllToListAsync().subscribe(
      res => {
        this.DichVuService.list = (res as DichVu[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
      },
      err => {
      }
    );
  }
  GetLoaiDoanhNghiepThanhVienToListAsync() {
    this.LoaiDoanhNghiepThanhVienService.GetAllToListAsync().subscribe(
      res => {
        this.LoaiDoanhNghiepThanhVienService.list = (res as LoaiDoanhNghiepThanhVien[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
      },
      err => {
      }
    );
  }
  GetNhanVienToListAsync() {
    this.NhanVienService.GetAllToListAsync().subscribe(
      res => {
        this.NhanVienService.list = (res as NhanVien[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
      },
      err => {
      }
    );
  }
  GetPhongBanToListAsync() {
    this.PhongBanService.GetAllToListAsync().subscribe(
      res => {
        this.PhongBanService.list = (res as PhongBan[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
      },
      err => {
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
    this.XaService.GetAllToListAsync().subscribe(
      res => {
        this.XaService.list = (res as Xa[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
      },
      err => {
      }
    );
  }
  GetNganhNgheKinhDoanhToListAsync() {
    this.NganhNgheKinhDoanhService.GetAllToListAsync().subscribe(
      res => {
        this.NganhNgheKinhDoanhService.list = (res as NganhNgheKinhDoanh[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
      },
      err => {
      }
    );
  }
  GetLoaiDoanhNghiepToListAsync() {
    this.LoaiDoanhNghiepService.GetAllToListAsync().subscribe(
      res => {
        this.LoaiDoanhNghiepService.list = (res as LoaiDoanhNghiep[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
      },
      err => {
      }
    );
  }
  GetLoaiTrangThaiToListAsync() {
    this.LoaiTrangThaiService.GetAllToListAsync().subscribe(
      res => {
        this.LoaiTrangThaiService.list = (res as LoaiTrangThai[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
      },
      err => {
      }
    );
  }
  GetDoanhNghiepDichVuCAToListAsync() {
    this.DoanhNghiepDichVuCAService.GetByParentIDToListAsync(this.DoanhNghiepService.formData.ID).subscribe(
      res => {
        this.DoanhNghiepDichVuCAService.list = (res as DoanhNghiepDichVuCA[]).sort((a, b) => (a.NgayHieuLuc < b.NgayHieuLuc ? 1 : -1));
        this.dataSourceDoanhNghiepDichVuCA = new MatTableDataSource(this.DoanhNghiepDichVuCAService.list);
        this.dataSourceDoanhNghiepDichVuCA.sort = this.sortDoanhNghiepDichVuCA;
        this.dataSourceDoanhNghiepDichVuCA.paginator = this.paginatorDoanhNghiepDichVuCA;
      },
      err => {
      }
    );
  }
  GetDoanhNghiepThanhVienToListAsync() {
    this.DoanhNghiepThanhVienService.GetByParentIDAndEmptyToListAsync(this.DoanhNghiepService.formData.ID).subscribe(
      res => {
        this.DoanhNghiepThanhVienService.list = (res as DoanhNghiepThanhVien[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.dataSourceDoanhNghiepThanhVien = new MatTableDataSource(this.DoanhNghiepThanhVienService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
        this.dataSourceDoanhNghiepThanhVien.sort = this.sortDoanhNghiepThanhVien;
        this.dataSourceDoanhNghiepThanhVien.paginator = this.paginatorDoanhNghiepThanhVien;
      },
      err => {
      }
    );
  }
  GetDoanhNghiepDichVuToListAsync() {
    this.DoanhNghiepDichVuService.GetByParentIDAndEmptyToListAsync(this.DoanhNghiepService.formData.ID).subscribe(
      res => {
        this.DoanhNghiepDichVuService.list = (res as DoanhNghiepDichVu[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.dataSourceDoanhNghiepDichVu = new MatTableDataSource(this.DoanhNghiepDichVuService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
        this.dataSourceDoanhNghiepDichVu.sort = this.sortDoanhNghiepDichVu;
        this.dataSourceDoanhNghiepDichVu.paginator = this.paginatorDoanhNghiepDichVu;
      },
      err => {
      }
    );
  }
  GetDoanhNghiepDichVuLichSuToListAsync() {
    this.isShowLoading = true;
    this.doanhThuByMonth = environment.InitializationNumber;
    this.DoanhNghiepDichVuLichSuService.GetByDoanhNghiepIDAndYearAndMonthToListAsync(this.DoanhNghiepService.formData.ID, this.year, this.month).subscribe(
      res => {
        this.DoanhNghiepDichVuLichSuService.list = (res as DoanhNghiepDichVuLichSu[]).sort((a, b) => (a.GiaTien < b.GiaTien ? 1 : -1));
        this.dataSourceDoanhNghiepDichVuLichSu = new MatTableDataSource(this.DoanhNghiepDichVuLichSuService.list.sort((a, b) => (a.GiaTien < b.GiaTien ? 1 : -1)));
        this.dataSourceDoanhNghiepDichVuLichSu.sort = this.sortDoanhNghiepDichVuLichSu;
        this.dataSourceDoanhNghiepDichVuLichSu.paginator = this.paginatorDoanhNghiepDichVuLichSu;
        this.doanhThuByMonth = environment.InitializationNumber;
        for (let i = 0; i < this.DoanhNghiepDichVuLichSuService.list.length; i++) {
          this.doanhThuByMonth = this.doanhThuByMonth + this.DoanhNghiepDichVuLichSuService.list[i].GiaTien;
        }

        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  ReportDoanhNghiep001Async() {
    this.isShowLoading = true;
    this.ReportService.ReportDoanhNghiep001Async(this.DoanhNghiepService.formData.ID, this.year, this.month).subscribe(
      res => {
        this.ReportService.listReport001 = (res as Report[]).sort((a, b) => (a.DoanhThu < b.DoanhThu ? 1 : -1));
        this.dataSourceReport001 = new MatTableDataSource(this.ReportService.listReport001.sort((a, b) => (a.DoanhThu < b.DoanhThu ? 1 : -1)));
        this.dataSourceReport001.sort = this.sortReport001;
        this.dataSourceReport001.paginator = this.paginatorReport001;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  public ChartOptionsReportDoanhNghiep002: ChartOptions = {
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
  public ChartColorsReportDoanhNghiep002: Color[] = [
    { backgroundColor: 'limegreen' },
  ]
  public ChartLabelsReportDoanhNghiep002: Label[] = [];
  public ChartTypeReportDoanhNghiep002: ChartType = 'bar';
  public ChartLegendReportDoanhNghiep002 = true;
  public ChartPluginsReportDoanhNghiep002 = [];

  public ChartDataReportDoanhNghiep002: ChartDataSets[] = [
  ];

  public ChartOptionsReportDoanhNghiep0021: ChartOptions = {
    responsive: true,
    tooltips: {
      callbacks: {
        label: function (tooltipItem, data) {
          var label = data.labels[tooltipItem.index];
          var value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
          return label + ': ' + Number(value).toFixed(0).replace(/./g, function (c, i, a) {
            return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "." + c : c;
          });
        }
      }
    }
  };
  public ChartColorsReportDoanhNghiep0021: Color[] = [
  ]
  public ChartLabelsReportDoanhNghiep0021: Label[] = [];
  public ChartTypeReportDoanhNghiep0021: ChartType = 'polarArea';
  public ChartLegendReportDoanhNghiep0021 = true;
  public ChartPluginsReportDoanhNghiep0021 = [];

  public ChartDataReportDoanhNghiep0021: ChartDataSets[] = [
  ];

  public ChartOptionsReportDoanhNghiep0022: ChartOptions = {
    responsive: true,
    tooltips: {
      callbacks: {
        label: function (tooltipItem, data) {
          var label = data.labels[tooltipItem.index];
          var value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
          return label + ': ' + Number(value).toFixed(0).replace(/./g, function (c, i, a) {
            return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "." + c : c;
          });
        }
      }
    }
  };
  public ChartColorsReportDoanhNghiep0022: Color[] = [
  ]
  public ChartLabelsReportDoanhNghiep0022: Label[] = [];
  public ChartTypeReportDoanhNghiep0022: ChartType = 'doughnut';
  public ChartLegendReportDoanhNghiep0022 = true;
  public ChartPluginsReportDoanhNghiep0022 = [];

  public ChartDataReportDoanhNghiep0022: ChartDataSets[] = [
  ];

  public ChartOptionsReportDoanhNghiep003: ChartOptions = {
    responsive: true,
    tooltips: {
      callbacks: {
        label: function (tooltipItem, data) {
          var label = data.datasets[tooltipItem.datasetIndex].label;
          return label + ': ' + Number(tooltipItem.yLabel).toFixed(0).replace(/./g, function (c, i, a) {
            return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "." + c : c;
          });
        }
      }
    }
  };
  public ChartColorsReportDoanhNghiep003: Color[] = [
  ]
  public ChartLabelsReportDoanhNghiep003: Label[] = ['Tháng 01', 'Tháng 02', 'Tháng 03', 'Tháng 04', 'Tháng 05', 'Tháng 06', 'Tháng 07', 'Tháng 08', 'Tháng 09', 'Tháng 10', 'Tháng 11', 'Tháng 12'];
  public ChartTypeReportDoanhNghiep003: ChartType = 'line';
  public ChartLegendReportDoanhNghiep003 = true;
  public ChartPluginsReportDoanhNghiep003 = [
  ];

  public ChartDataReportDoanhNghiep003: ChartDataSets[] = [
  ];

  public ChartOptionsReportDoanhNghiep004: ChartOptions = {
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
  public ChartColorsReportDoanhNghiep004: Color[] = [
    { backgroundColor: 'limegreen' },
  ]
  public ChartLabelsReportDoanhNghiep004: Label[] = [];
  public ChartTypeReportDoanhNghiep004: ChartType = 'bar';
  public ChartLegendReportDoanhNghiep004 = true;
  public ChartPluginsReportDoanhNghiep004 = [];

  public ChartDataReportDoanhNghiep004: ChartDataSets[] = [
  ];

  public ChartOptionsReportDoanhNghiep0041: ChartOptions = {
    responsive: true,
    tooltips: {
      callbacks: {
        label: function (tooltipItem, data) {
          var label = data.labels[tooltipItem.index];
          var value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
          return label + ': ' + Number(value).toFixed(0).replace(/./g, function (c, i, a) {
            return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "." + c : c;
          });
        }
      }
    }
  };
  public ChartColorsReportDoanhNghiep0041: Color[] = [
  ]
  public ChartLabelsReportDoanhNghiep0041: Label[] = [];
  public ChartTypeReportDoanhNghiep0041: ChartType = 'polarArea';
  public ChartLegendReportDoanhNghiep0041 = true;
  public ChartPluginsReportDoanhNghiep0041 = [];

  public ChartDataReportDoanhNghiep0041: ChartDataSets[] = [
  ];

  public ChartOptionsReportDoanhNghiep0042: ChartOptions = {
    responsive: true,
    tooltips: {
      callbacks: {
        label: function (tooltipItem, data) {
          var label = data.labels[tooltipItem.index];
          var value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
          return label + ': ' + Number(value).toFixed(0).replace(/./g, function (c, i, a) {
            return i > 0 && c !== "." && (a.length - i) % 3 === 0 ? "." + c : c;
          });
        }
      }
    }
  };
  public ChartColorsReportDoanhNghiep0042: Color[] = [
  ]
  public ChartLabelsReportDoanhNghiep0042: Label[] = [];
  public ChartTypeReportDoanhNghiep0042: ChartType = 'doughnut';
  public ChartLegendReportDoanhNghiep0042 = true;
  public ChartPluginsReportDoanhNghiep0042 = [];

  public ChartDataReportDoanhNghiep0042: ChartDataSets[] = [
  ];

  ReportDoanhNghiep002Async() {
    this.isShowLoading = true;
    this.ReportService.ReportDoanhNghiep002Async(this.DoanhNghiepService.formData.ID, this.year, this.month).subscribe(
      res => {
        this.ReportService.listReport002 = (res as Report[]).sort((a, b) => (a.DoanhThu > b.DoanhThu ? 1 : -1));
        let DichVu = [];
        let DoanhThu = [];
        this.ReportService.listReport002.forEach(item => {
          this.yearTitle = item.Year;
          this.monthTitle = item.Month;
          DichVu.push(item.DichVu);
          DoanhThu.push(item.DoanhThu);
        });
        let label: string = 'Doanh thu tháng ' + this.monthTitle + '-' + this.yearTitle + ' (Đơn vị tính: đồng)';
        this.ChartLabelsReportDoanhNghiep002 = DichVu;
        this.ChartDataReportDoanhNghiep002 = [{ data: DoanhThu, label: label, stack: 'a' }];

        this.ChartLabelsReportDoanhNghiep0021 = DichVu;
        this.ChartDataReportDoanhNghiep0021 = [{ data: DoanhThu, label: label }];

        this.ChartLabelsReportDoanhNghiep0022 = DichVu;
        this.ChartDataReportDoanhNghiep0022 = [{ data: DoanhThu, label: label }];

        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }

  ReportDoanhNghiep003Async() {
    this.isShowLoading = true;
    this.ReportService.ReportDoanhNghiep003Async(this.DoanhNghiepService.formData.ID, this.year, this.month).subscribe(
      res => {
        this.ReportService.listReport003 = (res as Report[]).sort((a, b) => (a.DichVuID > b.DichVuID ? 1 : -1));
        let Year: number = environment.InitializationNumber;
        let ChartData = [];
        this.ReportService.listReport003.forEach(item => {
          let DoanhThu = [];
          let DichVu: string = environment.InitializationString;
          Year = item.Year;
          DichVu = item.DichVu
          DoanhThu.push(item.DoanhThu01);
          DoanhThu.push(item.DoanhThu02);
          DoanhThu.push(item.DoanhThu03);
          DoanhThu.push(item.DoanhThu04);
          DoanhThu.push(item.DoanhThu05);
          DoanhThu.push(item.DoanhThu06);
          DoanhThu.push(item.DoanhThu07);
          DoanhThu.push(item.DoanhThu08);
          DoanhThu.push(item.DoanhThu09);
          DoanhThu.push(item.DoanhThu10);
          DoanhThu.push(item.DoanhThu11);
          DoanhThu.push(item.DoanhThu12);
          let data: any = {
            type: "line",
            fill: false,
            data: DoanhThu,
            label: DichVu,
            borderColor: this.DownloadService.GetRandomColor(DoanhThu.length)
          }
          ChartData.push(data);
          this.ChartDataReportDoanhNghiep003.push(data);
        });
        let label: string = 'Doanh thu năm ' + Year + ' (Đơn vị tính: đồng)';
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  ReportDoanhNghiep004Async() {
    this.isShowLoading = true;
    this.ReportService.ReportDoanhNghiep004Async(this.DoanhNghiepService.formData.ID, this.year, this.month).subscribe(
      res => {
        this.ReportService.listReport004 = (res as Report[]).sort((a, b) => (a.DoanhThu > b.DoanhThu ? 1 : -1));
        let DichVu = [];
        let DoanhThu = [];
        this.ReportService.listReport004.forEach(item => {
          this.yearTitle = item.Year;
          DichVu.push(item.DichVu);
          DoanhThu.push(item.DoanhThu);
        });
        let label: string = 'Doanh thu năm ' + this.yearTitle + ' (Đơn vị tính: đồng)';
        this.ChartLabelsReportDoanhNghiep004 = DichVu;
        this.ChartDataReportDoanhNghiep004 = [{ data: DoanhThu, label: label, stack: 'a' }];

        this.ChartLabelsReportDoanhNghiep0041 = DichVu;
        this.ChartDataReportDoanhNghiep0041 = [{ data: DoanhThu, label: label }];

        this.ChartLabelsReportDoanhNghiep0042 = DichVu;
        this.ChartDataReportDoanhNghiep0042 = [{ data: DoanhThu, label: label }];

        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  GetByQueryString() {
    this.isShowLoading = true;
    this.DoanhNghiepService.GetByIDStringAsync(this.queryString).subscribe(
      res => {
        if (this.DoanhNghiepService.formData) {
          this.GetDoanhNghiepDichVuLichSuToListAsync();
          this.GetHuyenToListAsync();
          this.GetXaToListAsync();
          this.GetNganhNgheKinhDoanhToListAsync();
          this.GetLoaiDoanhNghiepToListAsync();
          this.GetLoaiTrangThaiToListAsync();
          this.GetNhanVienToListAsync();
          this.GetPhongBanToListAsync();
          this.GetDoanhNghiepThanhVienToListAsync();
          this.GetLoaiDoanhNghiepThanhVienToListAsync();
          this.GetDoanhNghiepDichVuToListAsync();
          this.GetDichVuToListAsync();
          this.ReportDoanhNghiep001Async();
          this.ReportDoanhNghiep002Async();
          this.ReportDoanhNghiep003Async();
          this.ReportDoanhNghiep004Async();
          this.GetDoanhNghiepDichVuCAToListAsync();
        }
        this.isShowLoading = false;
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );   
  }
  onSubmit(form: NgForm) {
    this.isShowLoading = true;
    this.DoanhNghiepService.SaveAsync(form.value).subscribe(
      res => {
        this.GetByQueryString();
        this.NotificationService.warn(environment.SaveSuccess);
        this.isShowLoading = false;
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onChangeNgayCap(value) {
    this.DoanhNghiepService.formData.NgayCap = new Date(value);
  }
  onChangeNgayDangKyThayDoi(value) {
    this.DoanhNghiepService.formData.NgayDangKyThayDoi = new Date(value);
  }
  onChangeDoanhNghiepThanhVienNgaySinh(element: DoanhNghiepThanhVien, value) {
    element.NgaySinh = new Date(value);
  }
  onChangeDoanhNghiepThanhVienCCCD_NgayCap(element: DoanhNghiepThanhVien, value) {
    element.CCCD_NgayCap = new Date(value);
  }
  onChangeDoanhNghiepDichVuNgayKyHopDong(element: DoanhNghiepDichVu, value) {
    element.NgayKyHopDong = new Date(value);
  }
  onSaveDoanhNghiepThanhVien(element: DoanhNghiepThanhVien) {
    this.DoanhNghiepThanhVienService.SaveAsync(element).subscribe(
      res => {
        this.GetDoanhNghiepThanhVienToListAsync();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onSaveDoanhNghiepDichVu(element: DoanhNghiepDichVu) {
    this.DoanhNghiepDichVuService.SaveAsync(element).subscribe(
      res => {
        this.GetDoanhNghiepDichVuToListAsync();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onSaveDoanhNghiepDichVuLichSu(element: DoanhNghiepDichVuLichSu) {
    this.DoanhNghiepDichVuLichSuService.SaveAsync(element).subscribe(
      res => {
        this.GetDoanhNghiepDichVuLichSuToListAsync();
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  onSearchDoanhNghiepDichVuLichSu() {
    this.GetDoanhNghiepDichVuLichSuToListAsync();
    this.ReportDoanhNghiep001Async();
    this.ReportDoanhNghiep002Async();
    this.ReportDoanhNghiep003Async();
    this.ReportDoanhNghiep004Async();
  }
  onAddDoanhNghiepDichVuCA(ID: any) {
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
          this.GetDoanhNghiepDichVuCAToListAsync();
        });
      },
      err => {
      }
    );
  }
}

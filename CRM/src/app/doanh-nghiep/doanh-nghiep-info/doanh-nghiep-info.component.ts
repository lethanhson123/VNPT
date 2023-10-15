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
import { DoanhNghiep } from 'src/app/shared/DoanhNghiep.model';
import { DoanhNghiepService } from 'src/app/shared/DoanhNghiep.service';
import { DoanhNghiepThanhVien } from 'src/app/shared/DoanhNghiepThanhVien.model';
import { DoanhNghiepThanhVienService } from 'src/app/shared/DoanhNghiepThanhVien.service';
import { DoanhNghiepDichVu } from 'src/app/shared/DoanhNghiepDichVu.model';
import { DoanhNghiepDichVuService } from 'src/app/shared/DoanhNghiepDichVu.service';
import { DoanhNghiepDichVuLichSu } from 'src/app/shared/DoanhNghiepDichVuLichSu.model';
import { DoanhNghiepDichVuLichSuService } from 'src/app/shared/DoanhNghiepDichVuLichSu.service';
import { Report } from 'src/app/shared/Report.model';
import { ReportService } from 'src/app/shared/Report.service';
import { YearMonth } from 'src/app/shared/YearMonth.model';
import { DownloadService } from 'src/app/shared/Download.service';
import { ChartOptions, ChartType, ChartDataSets, Chart, ChartConfiguration, ChartData } from 'chart.js';
import { Color, Label, SingleDataSet, monkeyPatchChartJsLegend, monkeyPatchChartJsTooltip } from 'ng2-charts';

@Component({
  selector: 'app-doanh-nghiep-info',
  templateUrl: './doanh-nghiep-info.component.html',
  styleUrls: ['./doanh-nghiep-info.component.css']
})
export class DoanhNghiepInfoComponent implements OnInit {

  dataSourceDoanhNghiepThanhVien: MatTableDataSource<any>;
  @ViewChild(MatSort) sortDoanhNghiepThanhVien: MatSort;
  @ViewChild(MatPaginator) paginatorDoanhNghiepThanhVien: MatPaginator;

  dataSourceDoanhNghiepDichVu: MatTableDataSource<any>;
  @ViewChild(MatSort) sortDoanhNghiepDichVu: MatSort;
  @ViewChild(MatPaginator) paginatorDoanhNghiepDichVu: MatPaginator;

  dataSourceDoanhNghiepDichVuLichSu: MatTableDataSource<any>;
  @ViewChild(MatSort) sortDoanhNghiepDichVuLichSu: MatSort;
  @ViewChild(MatPaginator) paginatorDoanhNghiepDichVuLichSu: MatPaginator;

  dataSourceReport001: MatTableDataSource<any>;
  @ViewChild(MatSort) sortReport001: MatSort;
  @ViewChild(MatPaginator) paginatorReport001: MatPaginator;

  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  URLSub: string = environment.DomainDestination + "DoanhNghiepInfo";

  year: number = new Date().getFullYear();
  month: number = new Date().getMonth() + 1;
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
    public LoaiDoanhNghiepThanhVienService: LoaiDoanhNghiepThanhVienService,
    public DoanhNghiepDichVuService: DoanhNghiepDichVuService,
    public DoanhNghiepDichVuLichSuService: DoanhNghiepDichVuLichSuService,
    public DichVuService: DichVuService,
    public ReportService: ReportService,
    public NotificationService: NotificationService,
    public DownloadService: DownloadService,
  ) {
    this.router.events.forEach((event) => {
      if (event instanceof NavigationEnd) {
        this.queryString = event.url;
        this.GetByQueryString();
        this.GetYearToList();
        this.GetMonthToList();
      }
    });
  }

  ngOnInit(): void {
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
    this.DoanhNghiepDichVuLichSuService.GetByDoanhNghiepIDAndYearAndMonthToListAsync(this.DoanhNghiepService.formData.ID, this.year, this.month).subscribe(
      res => {
        this.DoanhNghiepDichVuLichSuService.list = (res as DoanhNghiepDichVuLichSu[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.dataSourceDoanhNghiepDichVuLichSu = new MatTableDataSource(this.DoanhNghiepDichVuLichSuService.list.sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1)));
        this.dataSourceDoanhNghiepDichVuLichSu.sort = this.sortDoanhNghiepDichVuLichSu;
        this.dataSourceDoanhNghiepDichVuLichSu.paginator = this.paginatorDoanhNghiepDichVuLichSu;

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
  Report001Async() {
    this.isShowLoading = true;
    this.ReportService.Report001Async(this.DoanhNghiepService.formData.ID).subscribe(
      res => {
        this.ReportService.listReport001 = (res as Report[]).sort((a, b) => (a.DoanhThu > b.DoanhThu ? 1 : -1));
        this.dataSourceReport001 = new MatTableDataSource(this.ReportService.listReport001.sort((a, b) => (a.DoanhThu > b.DoanhThu ? 1 : -1)));
        this.dataSourceReport001.sort = this.sortReport001;
        this.dataSourceReport001.paginator = this.paginatorReport001;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  public barChartOptionsReport002: ChartOptions = {
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
  public barChartColorsReport002: Color[] = [
    { backgroundColor: 'green' },
  ]
  public barChartLabelsReport002: Label[] = [];
  public barChartTypeReport002: ChartType = 'bar';
  public barChartLegendReport002 = true;
  public barChartPluginsReport002 = [];

  public barChartDataReport002: ChartDataSets[] = [
  ];

  public barChartOptionsReport003: ChartOptions = {
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
  public barChartColorsReport003: Color[] = [
    { backgroundColor: 'green' },
  ]
  public barChartLabelsReport003: Label[] = ['Tháng 01', 'Tháng 02', 'Tháng 03', 'Tháng 04', 'Tháng 05', 'Tháng 06', 'Tháng 07', 'Tháng 08', 'Tháng 09', 'Tháng 10', 'Tháng 11', 'Tháng 12'];
  public barChartTypeReport003: ChartType = 'line';
  public barChartLegendReport003 = true;
  public barChartPluginsReport003 = [];

  public barChartDataReport003: ChartDataSets[] = [
  ];
  Report002Async() {
    this.isShowLoading = true;
    this.ReportService.Report002Async(this.DoanhNghiepService.formData.ID).subscribe(
      res => {
        this.ReportService.listReport002 = (res as Report[]).sort((a, b) => (a.DoanhThu > b.DoanhThu ? 1 : -1));
        let Year: number = environment.InitializationNumber;
        let Month: number = environment.InitializationNumber;
        let DichVu = [];
        let DoanhThu = [];
        this.ReportService.listReport002.forEach(item => {
          Year = item.Year;
          Month = item.Month;
          DichVu.push(item.DichVu);
          DoanhThu.push(item.DoanhThu);
        });
        let label: string = 'Doanh thu tháng ' + Month + '-' + Year + ' (Đơn vị tính: đồng)';
        this.barChartLabelsReport002 = DichVu;
        this.barChartDataReport002 = [{ data: DoanhThu, label: label, stack: 'a' }];
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  Report003Async() {
    this.isShowLoading = true;
    this.ReportService.Report003Async(this.DoanhNghiepService.formData.ID).subscribe(
      res => {
        this.ReportService.listReport003 = (res as Report[]).sort((a, b) => (a.DichVuID > b.DichVuID ? 1 : -1));
        let Year: number = environment.InitializationNumber;
        let DichVu: string = environment.InitializationString;
        let DoanhThu = [];        
        this.ReportService.listReport003.forEach(item => {
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
            DoanhThu,
            DichVu
          }
          this.barChartDataReport003.push(data);
        });
        let label: string = 'Doanh thu năm ' + Year + ' (Đơn vị tính: đồng)';
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  GetByQueryString() {
    this.isShowLoading = true;
    this.DoanhNghiepService.GetByIDStringAsync(this.queryString).then(res => {
      this.DoanhNghiepService.formData = res as DoanhNghiep;
      if (this.DoanhNghiepService.formData) {
        this.GetHuyenToListAsync();
        this.GetXaToListAsync();
        this.GetNganhNgheKinhDoanhToListAsync();
        this.GetLoaiDoanhNghiepToListAsync();
        this.GetLoaiTrangThaiToListAsync();
        this.GetNhanVienToListAsync();
        this.GetDoanhNghiepThanhVienToListAsync();
        this.GetLoaiDoanhNghiepThanhVienToListAsync();
        this.GetDoanhNghiepDichVuToListAsync();
        this.GetDichVuToListAsync();
        this.GetDoanhNghiepDichVuLichSuToListAsync();
        this.Report001Async();
        this.Report002Async();
        //this.Report003Async();
      }
      this.isShowLoading = false;
    });
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
  }
}

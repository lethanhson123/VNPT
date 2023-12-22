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
import { DoanhNghiepDichVuCAEmailComponent } from '../doanh-nghiep-dich-vu-ca/doanh-nghiep-dich-vu-caemail/doanh-nghiep-dich-vu-caemail.component';

@Component({
  selector: 'app-cavnpt',
  templateUrl: './cavnpt.component.html',
  styleUrls: ['./cavnpt.component.css']
})
export class CAVNPTComponent implements OnInit {

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

  dataSource203: MatTableDataSource<any>;
  @ViewChild('sort203') sort203: MatSort;
  @ViewChild('paginator203') paginator203: MatPaginator;

  dataSource204: MatTableDataSource<any>;
  @ViewChild('sort204') sort204: MatSort;
  @ViewChild('paginator204') paginator204: MatPaginator;

  DataSource206: MatTableDataSource<any>;
  @ViewChild('Sort206') Sort206: MatSort;
  @ViewChild('Paginator206') Paginator206: MatPaginator;

  DataSource207: MatTableDataSource<any>;
  @ViewChild('Sort207') Sort207: MatSort;
  @ViewChild('Paginator207') Paginator207: MatPaginator;

  isShowLoading: boolean = false;
  domainName = environment.DomainDestination;
  huyenID: number = environment.InitializationNumber;
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
  hetHan: number = environment.InitializationNumber;
  year: number = new Date().getFullYear();
  month: number = new Date().getMonth() + 1;
  isKetLuan: boolean = false;
  isSmartCA: boolean = false;
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
    this.onSearchReportCA201();
    // this.onSearchReportCA001();
    // this.onSearchReportCA002();
    // this.onSearchReportCA008();
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
  onReportCA() {
    this.isShowLoading = true;
    this.DownloadService.ReportCA503_504_506_507ToHTMLAsync(this.year, this.month, this.isSmartCA).subscribe(
      res => {
        window.open(res.toString(), "_blank");
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  ReportCA201Async() {
    this.isShowLoading = true;
    this.ReportService.ReportCA501Async(this.year, this.month, this.isSmartCA).subscribe(
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
    this.ReportService.ReportCA502Async(this.year, this.month, this.isSmartCA).subscribe(
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
        let label001: string = 'PHÁT TRIỂN';
        let label002: string = 'Chỉ tiêu';
        let label003: string = 'GIA HẠN';
        let label004: string = 'Chỉ tiêu';
        this.ChartLabelsReportCA202PhatTrien = labelArray;
        this.ChartDataReportCA202PhatTrien = [
          { data: dataArray001, label: label001, stack: 'a', type: 'line', fill: false },
          { data: dataArray002, label: label002, stack: 'b', }
        ];
        this.ChartLabelsReportCA202GiaHan = labelArray;
        this.ChartDataReportCA202GiaHan = [
          { data: dataArray003, label: label003, stack: 'a', type: 'line', fill: false },
          { data: dataArray004, label: label004, stack: 'b' }
        ];
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  ReportCA205Async() {
    this.isShowLoading = true;
    this.ReportService.ReportCA505Async(this.year, this.month, this.isSmartCA).subscribe(
      res => {
        this.ReportService.listReportCA205 = (res as Report[]);
        let labelArray001 = [];
        let dataArray001 = [];
        let labelArray002 = [];
        let dataArray002 = [];
        for (let i = 0; i < this.ReportService.listReportCA205.length; i++) {
          labelArray001.push(this.ReportService.listReportCA205[i].LoaiGoiCuoc);
          dataArray001.push(this.ReportService.listReportCA205[i].SanLuong);
          labelArray002.push(this.ReportService.listReportCA205[i].DichVu);
          dataArray002.push(this.ReportService.listReportCA205[i].DoanhThu);
        }
        this.ChartLabelsReportCA205SanLuong = labelArray001;
        this.ChartDataReportCA205SanLuong = [
          { data: dataArray001, stack: 'a' },
        ];
        this.ChartLabelsReportCA205DoanhThu = labelArray002;
        this.ChartDataReportCA205DoanhThu = [
          { data: dataArray002, stack: 'a' },
        ];
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }

  ReportCA203Async() {
    this.isShowLoading = true;
    this.ReportService.ReportCA503Async(this.year, this.month, this.isSmartCA).subscribe(
      res => {
        this.ReportService.listReportCA203 = (res as Report[]);
        this.dataSource203 = new MatTableDataSource(this.ReportService.listReportCA203);
        this.dataSource203.sort = this.sort203;
        this.dataSource203.paginator = this.paginator203;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  ReportCA204Async() {
    this.isShowLoading = true;
    this.ReportService.ReportCA504Async(this.year, this.month, this.isSmartCA).subscribe(
      res => {
        this.ReportService.listReportCA204 = (res as Report[]);
        this.dataSource204 = new MatTableDataSource(this.ReportService.listReportCA204);
        this.dataSource204.sort = this.sort204;
        this.dataSource204.paginator = this.paginator204;
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
    this.ReportCA205Async();
    this.ReportCA203Async();
    this.ReportCA204Async();
  }

  public ChartOptionsReportCA205SanLuong: ChartOptions = {
    responsive: true, 
    legend: {
      display: true,
      position: 'right'
    },    
    tooltips: {
      callbacks: {
        label: function (tooltipItem, data) {
          var label = data.labels[tooltipItem.index];
          var value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
          return label + '';
        }
      }
    }
  };
  public ChartColorsReportCA205SanLuong: Color[] = [
  ]
  public ChartLabelsReportCA205SanLuong: Label[] = [];
  public ChartTypeReportCA205SanLuong: ChartType = 'pie';
  public ChartLegendReportCA205SanLuong = true;
  public ChartPluginsReportCA205SanLuong = [];

  public ChartDataReportCA205SanLuong: ChartDataSets[] = [
  ];

  public ChartOptionsReportCA205DoanhThu: ChartOptions = {
    responsive: true,
    legend: {
      display: true,
      position: 'right'
    }, 
    tooltips: {
      callbacks: {
        label: function (tooltipItem, data) {
          var label = data.labels[tooltipItem.index];
          var value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
          return label + '';
        }
      }
    }
  };
  public ChartColorsReportCA205DoanhThu: Color[] = [
  ]
  public ChartLabelsReportCA205DoanhThu: Label[] = [];
  public ChartTypeReportCA205DoanhThu: ChartType = 'pie';
  public ChartLegendReportCA205DoanhThu = true;
  public ChartPluginsReportCA205DoanhThu = [];

  public ChartDataReportCA205DoanhThu: ChartDataSets[] = [
  ];

  public ChartOptionsReportCA305SanLuong: ChartOptions = {
    responsive: true,
    legend: {
      display: true,
      position: 'right'
    },    
    tooltips: {
      callbacks: {
        label: function (tooltipItem, data) {
          var label = data.labels[tooltipItem.index];
          var value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
          return label + '';
        }
      }
    }
  };
  public ChartColorsReportCA305SanLuong: Color[] = [
  ]
  public ChartLabelsReportCA305SanLuong: Label[] = [];
  public ChartTypeReportCA305SanLuong: ChartType = 'pie';
  public ChartLegendReportCA305SanLuong = true;
  public ChartPluginsReportCA305SanLuong = [];
  public ChartDataReportCA305SanLuong: ChartDataSets[] = [
  ];

  public ChartOptionsReportCA305DoanhThu: ChartOptions = {
    responsive: true,
    legend: {
      display: true,
      position: 'right'
    },   
    tooltips: {
      callbacks: {
        label: function (tooltipItem, data) {
          var label = data.labels[tooltipItem.index];
          var value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
          return label + '';
        }
      }
    }
  };
  public ChartColorsReportCA305DoanhThu: Color[] = [
  ]
  public ChartLabelsReportCA305DoanhThu: Label[] = [];
  public ChartTypeReportCA305DoanhThu: ChartType = 'pie';
  public ChartLegendReportCA305DoanhThu = true;
  public ChartPluginsReportCA305DoanhThu = [];
  public ChartDataReportCA305DoanhThu: ChartDataSets[] = [
  ];

  public ChartOptionsReportCA306SanLuong: ChartOptions = {
    responsive: true,
    legend: {
      display: true,
      position: 'right'
    },   
    tooltips: {
      callbacks: {
        label: function (tooltipItem, data) {
          var label = data.labels[tooltipItem.index];
          var value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
          return label + '';
        }
      }
    }
  };
  public ChartColorsReportCA306SanLuong: Color[] = [
  ]
  public ChartLabelsReportCA306SanLuong: Label[] = [];
  public ChartTypeReportCA306SanLuong: ChartType = 'pie';
  public ChartLegendReportCA306SanLuong = true;
  public ChartPluginsReportCA306SanLuong = [];
  public ChartDataReportCA306SanLuong: ChartDataSets[] = [
  ];

  public ChartOptionsReportCA306DoanhThu: ChartOptions = {
    responsive: true,
    legend: {
      display: true,
      position: 'right'
    },   
    tooltips: {
      callbacks: {
        label: function (tooltipItem, data) {
          var label = data.labels[tooltipItem.index];
          var value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
          return label + '';
        }
      }
    }
  };
  public ChartColorsReportCA306DoanhThu: Color[] = [
  ]
  public ChartLabelsReportCA306DoanhThu: Label[] = [];
  public ChartTypeReportCA306DoanhThu: ChartType = 'pie';
  public ChartLegendReportCA306DoanhThu = true;
  public ChartPluginsReportCA306DoanhThu = [];
  public ChartDataReportCA306DoanhThu: ChartDataSets[] = [
  ];

  public ChartOptionsReportCA307SanLuong: ChartOptions = {
    responsive: true,
    legend: {
      display: true,
      position: 'right'
    },   
    tooltips: {
      callbacks: {
        label: function (tooltipItem, data) {
          var label = data.labels[tooltipItem.index];
          var value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
          return label + '';
        }
      }
    }
  };
  public ChartColorsReportCA307SanLuong: Color[] = [
  ]
  public ChartLabelsReportCA307SanLuong: Label[] = [];
  public ChartTypeReportCA307SanLuong: ChartType = 'pie';
  public ChartLegendReportCA307SanLuong = true;
  public ChartPluginsReportCA307SanLuong = [];
  public ChartDataReportCA307SanLuong: ChartDataSets[] = [
  ];

  public ChartOptionsReportCA307DoanhThu: ChartOptions = {
    responsive: true,
    legend: {
      display: true,
      position: 'right'
    },   
    tooltips: {
      callbacks: {
        label: function (tooltipItem, data) {
          var label = data.labels[tooltipItem.index];
          var value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
          return label + '';
        }
      }
    }
  };
  public ChartColorsReportCA307DoanhThu: Color[] = [
  ]
  public ChartLabelsReportCA307DoanhThu: Label[] = [];
  public ChartTypeReportCA307DoanhThu: ChartType = 'pie';
  public ChartLegendReportCA307DoanhThu = true;
  public ChartPluginsReportCA307DoanhThu = [];
  public ChartDataReportCA307DoanhThu: ChartDataSets[] = [
  ];

  public ChartOptionsReportCA308SanLuong: ChartOptions = {
    responsive: true,
    legend: {
      display: true,
      position: 'right'
    },   
    tooltips: {
      callbacks: {
        label: function (tooltipItem, data) {
          var label = data.labels[tooltipItem.index];
          var value = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
          return label + '';
        }
      }
    }
  };
  public ChartColorsReportCA308SanLuong: Color[] = [
  ]
  public ChartLabelsReportCA308SanLuong: Label[] = [];
  public ChartTypeReportCA308SanLuong: ChartType = 'pie';
  public ChartLegendReportCA308SanLuong = true;
  public ChartPluginsReportCA308SanLuong = [];
  public ChartDataReportCA308SanLuong: ChartDataSets[] = [
  ];

  public ChartOptionsReportCA202PhatTrien: ChartOptions = {
    responsive: true,
    animation: {
      duration: 1,
      onComplete: function () {
        var chartInstance = this.chart,
          ctx = chartInstance.ctx;
        ctx.textAlign = 'center';
        ctx.fillStyle = "rgba(0, 0, 0, 1)";
        ctx.textBaseline = 'bottom';
        this.data.datasets.forEach(function (dataset, i) {
          var meta = chartInstance.controller.getDatasetMeta(i);
          meta.data.forEach(function (bar, index) {
            var data = dataset.data[index];
            ctx.fillText(data, bar._model.x, bar._model.y - 5);

          });
        });
      }
    },
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
  ]
  public ChartLabelsReportCA202PhatTrien: Label[] = [];
  public ChartTypeReportCA202PhatTrien: ChartType = 'bar';
  public ChartLegendReportCA202PhatTrien = true;
  public ChartPluginsReportCA202PhatTrien = [];

  public ChartDataReportCA202PhatTrien: ChartDataSets[] = [
  ];

  public ChartOptionsReportCA202GiaHan: ChartOptions = {
    responsive: true,    
    animation: {
      duration: 1,
      onComplete: function () {
        var chartInstance = this.chart,
          ctx = chartInstance.ctx;
        ctx.textAlign = 'center';
        ctx.fillStyle = "rgba(0, 0, 0, 1)";
        ctx.textBaseline = 'bottom';
        this.data.datasets.forEach(function (dataset, i) {
          var meta = chartInstance.controller.getDatasetMeta(i);
          meta.data.forEach(function (bar, index) {
            var data = dataset.data[index];
            ctx.fillText(data, bar._model.x, bar._model.y - 5);

          });
        });
      }
    },
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
  ]
  public ChartLabelsReportCA202GiaHan: Label[] = [];
  public ChartTypeReportCA202GiaHan: ChartType = 'bar';
  public ChartLegendReportCA202GiaHan = true;
  public ChartPluginsReportCA202GiaHan = [];

  public ChartDataReportCA202GiaHan: ChartDataSets[] = [
  ]; 
 
  GetHuyenToListAsync() {
    this.HuyenService.GetSQLByNhanVienID_ActiveAsync().subscribe(
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
      },
      err => {
      }
    );
  } 
  ReportCA001Async() {
    this.isShowLoading = true;
    this.ReportService.ReportCA401Async(this.huyenID, this.year, this.month, this.nhanVienID, this.isSmartCA).subscribe(
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

    this.isShowLoading = true;
    this.ReportService.ReportCA605Async(this.huyenID, this.year, this.month, this.nhanVienID, this.isSmartCA).subscribe(
      res => {
        this.ReportService.listReportCA305 = (res as Report[]);
        let labelArray001 = [];
        let dataArray001 = [];
        let labelArray002 = [];
        let dataArray002 = [];
        for (let i = 0; i < this.ReportService.listReportCA305.length; i++) {
          labelArray001.push(this.ReportService.listReportCA305[i].LoaiGoiCuoc);
          dataArray001.push(this.ReportService.listReportCA305[i].SanLuong);
          labelArray002.push(this.ReportService.listReportCA305[i].DichVu);
          dataArray002.push(this.ReportService.listReportCA305[i].DoanhThu);
        }
        this.ChartLabelsReportCA305SanLuong = labelArray001;
        this.ChartDataReportCA305SanLuong = [
          { data: dataArray001, stack: 'a' },
        ];
        this.ChartLabelsReportCA305DoanhThu = labelArray002;
        this.ChartDataReportCA305DoanhThu = [
          { data: dataArray002, stack: 'a' },
        ];
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
    this.ReportService.ReportCA402Async(this.huyenID, this.year, this.month, this.nhanVienID, this.isSmartCA).subscribe(
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

    this.isShowLoading = true;
    this.ReportService.ReportCA606Async(this.huyenID, this.year, this.month, this.nhanVienID, this.isSmartCA).subscribe(
      res => {
        this.ReportService.listReportCA306 = (res as Report[]);
        let labelArray001 = [];
        let dataArray001 = [];
        let labelArray002 = [];
        let dataArray002 = [];
        for (let i = 0; i < this.ReportService.listReportCA306.length; i++) {
          labelArray001.push(this.ReportService.listReportCA306[i].LoaiGoiCuoc);
          dataArray001.push(this.ReportService.listReportCA306[i].SanLuong);
          labelArray002.push(this.ReportService.listReportCA306[i].DichVu);
          dataArray002.push(this.ReportService.listReportCA306[i].DoanhThu);
        }
        this.ChartLabelsReportCA306SanLuong = labelArray001;
        this.ChartDataReportCA306SanLuong = [
          { data: dataArray001, stack: 'a' },
        ];
        this.ChartLabelsReportCA306DoanhThu = labelArray002;
        this.ChartDataReportCA306DoanhThu = [
          { data: dataArray002, stack: 'a' },
        ];
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
    this.ReportService.ReportCA403Async(this.huyenID, this.year, this.month, this.nhanVienID, this.isSmartCA).subscribe(
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
    this.ReportService.ReportCA404Async(this.huyenID, this.year, this.month, this.nhanVienID, this.isSmartCA).subscribe(
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
    this.ReportService.ReportCA405Async(this.huyenID, this.year, this.month, this.nhanVienID, this.hetHan, this.isSmartCA).subscribe(
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

    this.isShowLoading = true;
    this.ReportService.ReportCA607Async(this.huyenID, this.year, this.month, this.nhanVienID, this.hetHan, this.isSmartCA).subscribe(
      res => {
        this.ReportService.listReportCA307 = (res as Report[]);
        let labelArray001 = [];
        let dataArray001 = [];
        let labelArray002 = [];
        let dataArray002 = [];
        for (let i = 0; i < this.ReportService.listReportCA307.length; i++) {
          labelArray001.push(this.ReportService.listReportCA307[i].LoaiGoiCuoc);
          dataArray001.push(this.ReportService.listReportCA307[i].SanLuong);
          labelArray002.push(this.ReportService.listReportCA307[i].DichVu);
          dataArray002.push(this.ReportService.listReportCA307[i].DoanhThu);
        }
        this.ChartLabelsReportCA307SanLuong = labelArray001;
        this.ChartDataReportCA307SanLuong = [
          { data: dataArray001, stack: 'a' },
        ];
        this.ChartLabelsReportCA307DoanhThu = labelArray002;
        this.ChartDataReportCA307DoanhThu = [
          { data: dataArray002, stack: 'a' },
        ];
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
    this.ReportService.ReportCA406Async(this.huyenID, this.year, this.month, this.nhanVienID, this.isSmartCA).subscribe(
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
    this.ReportService.ReportCA407Async(this.huyenID, this.year, this.month, this.nhanVienID, this.isSmartCA).subscribe(
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
  ReportCA008Async() {
    this.isShowLoading = true;
    this.ReportService.ReportCA408Async(this.huyenID, this.year, this.month, this.nhanVienID, this.isKetLuan, this.isSmartCA).subscribe(
      res => {
        this.ReportService.listReportCA008 = (res as Report[]);
        this.dataSource8 = new MatTableDataSource(this.ReportService.listReportCA008);
        this.dataSource8.sort = this.sort8;
        this.dataSource8.paginator = this.paginator8;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );

    this.isShowLoading = true;
    this.ReportService.ReportCA608Async(this.huyenID, this.year, this.month, this.nhanVienID, this.isSmartCA).subscribe(
      res => {
        this.ReportService.listReportCA308 = (res as Report[]);
        let labelArray001 = [];
        let dataArray001 = [];
        let labelArray002 = [];
        let dataArray002 = [];
        for (let i = 0; i < this.ReportService.listReportCA308.length; i++) {
          labelArray001.push(this.ReportService.listReportCA308[i].LoaiGoiCuoc);
          dataArray001.push(this.ReportService.listReportCA308[i].SanLuong);
        }
        this.ChartLabelsReportCA308SanLuong = labelArray001;
        this.ChartDataReportCA308SanLuong = [
          { data: dataArray001, stack: 'a' },
        ];
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );

  }
  onSearchReportCA008() {
    this.ReportCA206();
    this.ReportCA207();
    if (this.searchString.length > 0) {
      this.dataSource8.filter = this.searchString.toLowerCase();
    }
    else {
      this.ReportCA008Async();
    }
  }
  onDownloadExcelFileReportCA008() {
    this.isShowLoading = true;
    this.DownloadService.ReportCA408ToExcelAsync(this.huyenID, this.year, this.month, this.nhanVienID, this.isKetLuan, this.isSmartCA).subscribe(
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
  onEmailReportCA005(ID: any) {
    this.DoanhNghiepDichVuCAService.GetByIDAsync(ID).subscribe(
      res => {
        this.DoanhNghiepDichVuCAService.formData = res as DoanhNghiepDichVuCA;
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(DoanhNghiepDichVuCAEmailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.onSearchReportCA005();
        });
      },
      err => {
      }
    );
  }
  onAddReportCA008(ID: any) {
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
          this.onSearchReportCA008();
        });
      },
      err => {
      }
    );
  }
  DoanhNghiepDichVuCAThieuHoSo() {
    this.isShowLoading = true;
    this.DoanhNghiepDichVuCAService.AsyncThieuHoSoDoanhNghiepDichVuCA().subscribe(
      res => {        
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  ReportCA206() {
    this.isShowLoading = true;
    this.ReportService.ReportCA206Async(this.year, this.month).subscribe(
      res => {
        this.ReportService.listReportCA206 = (res as Report[]);
        this.DataSource206 = new MatTableDataSource(this.ReportService.listReportCA206);
        this.DataSource206.sort = this.Sort206;
        this.DataSource206.paginator = this.Paginator206;

        let labelArray = [];
        let dataArray001 = [];
        let dataArray002 = [];
        let dataArray003 = [];        
        for (let i = 0; i < this.ReportService.listReportCA206.length; i++) {
          labelArray.push(this.ReportService.listReportCA206[i].NhanVienTaoYeuCauName);
          dataArray001.push(this.ReportService.listReportCA206[i].HoSo);
          dataArray002.push(this.ReportService.listReportCA206[i].HoSoHoanThanh);
          dataArray003.push(this.ReportService.listReportCA206[i].HoSoChuaHoanThanh);          
        }
        let label001: string = 'HỒ SƠ';
        let label002: string = 'HOÀN THÀNH';
        let label003: string = 'CHƯA HOÀN THÀNH';        
        this.ChartLabelsReportCA206 = labelArray;
        this.ChartDataReportCA206 = [
          { data: dataArray001, label: label001, stack: 'a', },
          { data: dataArray002, label: label002, stack: 'b', type: 'line', fill: false },
          { data: dataArray003, label: label003, stack: 'c', type: 'line', fill: false }
        ];

        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  ReportCA207() {
    this.isShowLoading = true;
    this.ReportService.ReportCA207Async(this.year, this.month).subscribe(
      res => {
        this.ReportService.listReportCA207 = (res as Report[]);
        this.DataSource207 = new MatTableDataSource(this.ReportService.listReportCA207);
        this.DataSource207.sort = this.Sort207;
        this.DataSource207.paginator = this.Paginator207;

        let labelArray = [];
        let dataArray001 = [];
        let dataArray002 = [];
        let dataArray003 = [];        
        for (let i = 0; i < this.ReportService.listReportCA207.length; i++) {
          labelArray.push(this.ReportService.listReportCA207[i].PhongBanTaoYeuCauName);
          dataArray001.push(this.ReportService.listReportCA207[i].HoSo);
          dataArray002.push(this.ReportService.listReportCA207[i].HoSoHoanThanh);
          dataArray003.push(this.ReportService.listReportCA207[i].HoSoChuaHoanThanh);          
        }
        let label001: string = 'HỒ SƠ';
        let label002: string = 'HOÀN THÀNH';
        let label003: string = 'CHƯA HOÀN THÀNH';        
        this.ChartLabelsReportCA207 = labelArray;
        this.ChartDataReportCA207 = [
          { data: dataArray001, label: label001, stack: 'a', },
          { data: dataArray002, label: label002, stack: 'b', type: 'line', fill: false },
          { data: dataArray003, label: label003, stack: 'c', type: 'line', fill: false }
        ];
        

        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  public ChartOptionsReportCA206: ChartOptions = {
    responsive: true,
    animation: {
      duration: 1,
      onComplete: function () {
        var chartInstance = this.chart,
        ctx = chartInstance.ctx;
        ctx.textAlign = 'center';
        ctx.fillStyle = "rgba(0, 0, 0, 1)";
        ctx.textBaseline = 'bottom';
        this.data.datasets.forEach(function (dataset, i) {
          var meta = chartInstance.controller.getDatasetMeta(i);
          meta.data.forEach(function (bar, index) {
            var data = dataset.data[index];
            ctx.fillText(data, bar._model.x, bar._model.y - 5);

          });
        });
      }
    },
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
  public ChartColorsReportCA206: Color[] = [
  ]
  public ChartLabelsReportCA206: Label[] = [];
  public ChartTypeReportCA206: ChartType = 'bar';
  public ChartLegendReportCA206 = true;
  public ChartPluginsReportCA206 = [];

  public ChartDataReportCA206: ChartDataSets[] = [
  ];

  public ChartOptionsReportCA207: ChartOptions = {
    responsive: true,
    animation: {
      duration: 1,
      onComplete: function () {
        var chartInstance = this.chart,
        ctx = chartInstance.ctx;
        ctx.textAlign = 'center';
        ctx.fillStyle = "rgba(0, 0, 0, 1)";
        ctx.textBaseline = 'bottom';
        this.data.datasets.forEach(function (dataset, i) {
          var meta = chartInstance.controller.getDatasetMeta(i);
          meta.data.forEach(function (bar, index) {
            var data = dataset.data[index];
            ctx.fillText(data, bar._model.x, bar._model.y - 5);

          });
        });
      }
    },
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
  public ChartColorsReportCA207: Color[] = [
  ]
  public ChartLabelsReportCA207: Label[] = [];
  public ChartTypeReportCA207: ChartType = 'bar';
  public ChartLegendReportCA207 = true;
  public ChartPluginsReportCA207 = [];

  public ChartDataReportCA207: ChartDataSets[] = [
  ];
}
import { Component, OnInit, ViewChild } from '@angular/core';
import { ChartOptions, ChartType, ChartDataSets, Chart, ChartConfiguration, ChartData } from 'chart.js';
import { Color, Label, SingleDataSet, monkeyPatchChartJsLegend, monkeyPatchChartJsTooltip } from 'ng2-charts';

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

import { Report } from 'src/app/shared/Report.model';
import { ReportService } from 'src/app/shared/Report.service';

@Component({
  selector: 'app-khach-hang',
  templateUrl: './khach-hang.component.html',
  styleUrls: ['./khach-hang.component.css']
})
export class KhachHangComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  xaID: number = environment.InitializationNumber;
  huyenID: number = environment.InitializationNumber;
  URLSub: string = environment.DomainDestination + "DoanhNghiepInfo";
  year: number = new Date().getFullYear();
  constructor(
    public DoanhNghiepService: DoanhNghiepService,
    public HuyenService: HuyenService,
    public XaService: XaService,
    public NotificationService: NotificationService,

    public ReportService: ReportService,
  ) { }

  ngOnInit(): void {
    this.ReportVNPT1001ToListAsync();
    this.ReportVNPT1002ToListAsync();
    this.GetHuyenToListAsync();

  }
  GetHuyenToListAsync() {
    this.HuyenService.GetAllToListAsync().subscribe(
      res => {
        this.HuyenService.list = (res as Huyen[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));        
        this.onSearch();
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
    this.DoanhNghiepService.GetSQLBySearchString_HuyenIDToListTranferAsync(this.searchString, this.huyenID).subscribe(
      res => {
        this.DoanhNghiepService.list = (res as DoanhNghiep[]);
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
  }

  ReportVNPT1001ToListAsync() {
    this.isShowLoading = true;
    this.ReportService.ReportVNPT1001ToListAsync().subscribe(
      res => {
        this.ReportService.listReportVNPT1001 = (res as Report[]);
        let labelArray001 = [];
        let dataArray001 = [];
        for (let i = 0; i < this.ReportService.listReportVNPT1001.length; i++) {
          labelArray001.push(this.ReportService.listReportVNPT1001[i].HuyenName);
          dataArray001.push(this.ReportService.listReportVNPT1001[i].SanLuong);
        }
        this.ChartLabelsReportVNPT1001 = labelArray001;
        this.ChartDataReportVNPT1001 = [
          { data: dataArray001, stack: 'a', },
        ];
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }

  ReportVNPT1002ToListAsync() {
    this.isShowLoading = true;
    this.ReportService.ReportVNPT1002ToListAsync().subscribe(
      res => {
        this.ReportService.listReportVNPT1002 = (res as Report[]);
        let label001: string = 'Doanh nghiệp';
        let labelArray001 = [];
        let dataArray001 = [];
        for (let i = 0; i < this.ReportService.listReportVNPT1002.length; i++) {
          labelArray001.push(this.ReportService.listReportVNPT1002[i].HuyenName);
          dataArray001.push(this.ReportService.listReportVNPT1002[i].SanLuong);
        }
        this.ChartLabelsReportVNPT1002 = labelArray001;
        this.ChartDataReportVNPT1002 = [
          { data: dataArray001, label: label001, stack: 'a', type: 'line', fill: false },
        ];
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }

  public ChartOptionsReportVNPT1001: ChartOptions = {
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
  public ChartColorsReportVNPT1001: Color[] = [
  ]
  public ChartLabelsReportVNPT1001: Label[] = [];
  public ChartTypeReportVNPT1001: ChartType = 'pie';
  public ChartLegendReportVNPT1001 = true;
  public ChartPluginsReportVNPT1001 = [];

  public ChartDataReportVNPT1001: ChartDataSets[] = [
  ];

  public ChartOptionsReportVNPT1002: ChartOptions = {
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
  public ChartColorsReportVNPT1002: Color[] = [
  ]
  public ChartLabelsReportVNPT1002: Label[] = [];
  public ChartTypeReportVNPT1002: ChartType = 'bar';
  public ChartLegendReportVNPT1002 = true;
  public ChartPluginsReportVNPT1002 = [];

  public ChartDataReportVNPT1002: ChartDataSets[] = [
  ];
}

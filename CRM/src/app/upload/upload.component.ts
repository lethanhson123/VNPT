import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

import { UploadService } from 'src/app/shared/Upload.service';
import { DoanhNghiep } from 'src/app/shared/DoanhNghiep.model';
import { DoanhNghiepService } from 'src/app/shared/DoanhNghiep.service';
import { YearMonth } from 'src/app/shared/YearMonth.model';
import { DownloadService } from 'src/app/shared/Download.service';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  year: number = new Date().getFullYear();
  month: number = new Date().getMonth() + 1;

  isShowLoading: boolean = false;
  isDoanhNghiep: boolean = false;
  isDoanhThu: boolean = false;
  excelDoanhNghiepURL: string = environment.APIRootURL + environment.Download + "/DoanhNghiep.xlsx";
  excelDoanhThuURL: string = environment.APIRootURL + environment.Download + "/DoanhThu.xlsx";
  @ViewChild('uploadDoanhNghiep') uploadDoanhNghiep!: ElementRef;
  @ViewChild('uploadDoanhThu') uploadDoanhThu!: ElementRef;
  dataSource: MatTableDataSource<any>;  
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(
    public DoanhNghiepService: DoanhNghiepService,
    public UploadService: UploadService,
    public DownloadService: DownloadService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
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
  changeDoanhNghiep(files: FileList) {
    if (files) {
      this.isDoanhNghiep = true;
    }
  }
  changeDoanhThu(files: FileList) {
    if (files) {
      this.isDoanhThu = true;
    }
  }
  onSubmit() {
    let fileToUpload: File;
    fileToUpload = this.uploadDoanhNghiep.nativeElement.files[0];
    this.isShowLoading = true;
    this.UploadService.PostDoanhNghiepListByExcelFileAsync(fileToUpload).subscribe(
      res => {
        this.isShowLoading = false;
        this.DoanhNghiepService.list = res as DoanhNghiep[];
        this.dataSource = new MatTableDataSource(this.DoanhNghiepService.list.sort((a, b) => (a.Code > b.Code ? 1 : -1)));
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      err => {
        this.isShowLoading = false;
        this.NotificationService.warn(environment.UploadNotSuccess);
      }
    );
  }
  onSubmitDoanhThu() {
    let fileToUpload: File;
    fileToUpload = this.uploadDoanhThu.nativeElement.files[0];
    this.isShowLoading = true;
    this.UploadService.PostDoanhThuByYearAndMonthListByExcelFileAsync(fileToUpload, this.year, this.month).subscribe(
      res => {
        this.isShowLoading = false;
        this.DoanhNghiepService.list = res as DoanhNghiep[];
        this.dataSource = new MatTableDataSource(this.DoanhNghiepService.list.sort((a, b) => (a.Code > b.Code ? 1 : -1)));
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      err => {
        this.isShowLoading = false;
        this.NotificationService.warn(environment.UploadNotSuccess);
      }
    );
  }
}

import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

import { UploadService } from 'src/app/shared/Upload.service';
import { DoanhNghiep } from 'src/app/shared/DoanhNghiep.model';
import { DoanhNghiepService } from 'src/app/shared/DoanhNghiep.service';

import { DoanhNghiepDichVuCA } from 'src/app/shared/DoanhNghiepDichVuCA.model';
import { DoanhNghiepDichVuCAService } from 'src/app/shared/DoanhNghiepDichVuCA.service';

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
  isGoiCuoc: boolean = false;
  isCA: boolean = false;
  isCAHoSo: boolean = false;
  isCACapBu: boolean = false;
  excelDoanhNghiepURL: string = environment.APIRootURL + environment.Download + "/DoanhNghiep.xlsx";
  excelDoanhThuURL: string = environment.APIRootURL + environment.Download + "/DoanhThu.xlsx";
  excelGoiCuocURL: string = environment.APIRootURL + environment.Download + "/GoiCuoc.xlsx";
  excelCAURL: string = environment.APIRootURL + environment.Download + "/CA.xlsx";
  excelCAHoSoURL: string = environment.APIRootURL + environment.Download + "/CASoChungThu.xlsx";
  excelCACapBuURL: string = environment.APIRootURL + environment.Download + "/CACapBu.xlsx";
  @ViewChild('uploadDoanhNghiep') uploadDoanhNghiep!: ElementRef;
  @ViewChild('uploadDoanhThu') uploadDoanhThu!: ElementRef;
  @ViewChild('uploadGoiCuoc') uploadGoiCuoc!: ElementRef;
  @ViewChild('uploadCA') uploadCA!: ElementRef;
  @ViewChild('uploadCAHoSo') uploadCAHoSo!: ElementRef;
  @ViewChild('uploadCACapBu') uploadCACapBu!: ElementRef;
  dataSource: MatTableDataSource<any>;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(
    public DoanhNghiepService: DoanhNghiepService,
    public DoanhNghiepDichVuCAService: DoanhNghiepDichVuCAService,
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
  changeGoiCuoc(files: FileList) {
    if (files) {
      this.isGoiCuoc = true;
    }
  }
  changeCA(files: FileList) {
    if (files) {
      this.isCA = true;
    }
  }
  changeCAHoSo(files: FileList) {
    if (files) {
      this.isCAHoSo = true;
    }
  }
  changeCACapBu(files: FileList) {
    if (files) {
      this.isCACapBu = true;
    }
  }
  onSubmit() {
    let fileToUpload: File;
    fileToUpload = this.uploadDoanhNghiep.nativeElement.files[0];
    this.isShowLoading = true;
    this.UploadService.PostDoanhNghiepListByExcelFileAsync(fileToUpload).subscribe(
      res => {
        this.isShowLoading = false;
        this.DoanhNghiepService.list = (res as DoanhNghiep[]).sort((a, b) => (a.Code > b.Code ? 1 : -1));
        this.dataSource = new MatTableDataSource(this.DoanhNghiepService.list);
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
    this.UploadService.PostDoanhThuByYearAndMonthList2023ByExcelFileAsync(fileToUpload, this.year, this.month).subscribe(
      res => {
        this.isShowLoading = false;
        this.DoanhNghiepService.list = (res as DoanhNghiep[]).sort((a, b) => (a.Code > b.Code ? 1 : -1));
        this.dataSource = new MatTableDataSource(this.DoanhNghiepService.list);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      err => {
        this.isShowLoading = false;
        this.NotificationService.warn(environment.UploadNotSuccess);
      }
    );
  }
  onSubmitCA() {
    let fileToUpload: File;
    fileToUpload = this.uploadCA.nativeElement.files[0];
    this.isShowLoading = true;
    this.UploadService.PostCA20ListByExcelFileAsync(fileToUpload).subscribe(
      res => {
        this.isShowLoading = false;
        this.NotificationService.warn(environment.UploadSuccess);
      },
      err => {
        this.isShowLoading = false;
        this.NotificationService.warn(environment.UploadNotSuccess);
      }
    );
  }
  onSubmitCACapBu() {
    let fileToUpload: File;
    fileToUpload = this.uploadCACapBu.nativeElement.files[0];
    this.isShowLoading = true;
    this.UploadService.PostCACapBuByExcelFileAsync(fileToUpload).subscribe(
      res => {
        this.DoanhNghiepDichVuCAService.list = (res as DoanhNghiepDichVuCA[]);
        console.log(this.DoanhNghiepDichVuCAService.list);
        this.isShowLoading = false;
        this.NotificationService.warn(environment.UploadSuccess);
      },
      err => {
        this.isShowLoading = false;
        this.NotificationService.warn(environment.UploadNotSuccess);
      }
    );
  }
  onSubmitGoiCuoc() {
    let fileToUpload: File;
    fileToUpload = this.uploadGoiCuoc.nativeElement.files[0];
    this.isShowLoading = true;
    this.UploadService.PostGoiCuocListByExcelFileAsync(fileToUpload).subscribe(
      res => {
        this.isShowLoading = false;
        this.NotificationService.warn(environment.UploadSuccess);
      },
      err => {
        this.isShowLoading = false;
        this.NotificationService.warn(environment.UploadNotSuccess);
      }
    );
  }
  onSubmitCAHoSo() {
    let fileToUpload: File;
    fileToUpload = this.uploadCAHoSo.nativeElement.files[0];
    this.isShowLoading = true;
    this.UploadService.PostDoanhNghiepDichVuCASoChungThuByExcelFileAsync(fileToUpload).subscribe(
      res => {
        this.isShowLoading = false;
        this.NotificationService.warn(environment.UploadSuccess);
      },
      err => {
        this.isShowLoading = false;
        this.NotificationService.warn(environment.UploadNotSuccess);
      }
    );
  }
}

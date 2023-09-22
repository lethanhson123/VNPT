import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

import { UploadService } from 'src/app/shared/Upload.service';
import { DoanhNghiep } from 'src/app/shared/DoanhNghiep.model';
import { DoanhNghiepService } from 'src/app/shared/DoanhNghiep.service';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  isShowLoading: boolean = false;
  isDoanhNghiep: boolean = false;
  excelDoanhNghiepURL: string = environment.APIRootURL + environment.Download + "/DoanhNghiep.xlsx";
  @ViewChild('uploadDoanhNghiep') uploadDoanhNghiep!: ElementRef;

  dataSource: MatTableDataSource<any>;  
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(
    public DoanhNghiepService: DoanhNghiepService,
    public UploadService: UploadService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
  }
  changeDoanhNghiep(files: FileList) {
    if (files) {
      this.isDoanhNghiep = true;
    }
  }
  onSubmit() {
    let fileToUpload: File;
    fileToUpload = this.uploadDoanhNghiep.nativeElement.files[0];
    this.isShowLoading = true;
    this.UploadService.PostDoanhNghiepListByExcelFile(fileToUpload).subscribe(
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

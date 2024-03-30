import { Component, OnInit, Inject, ElementRef, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/Notification.service';

import { DichVu } from 'src/app/shared/DichVu.model';
import { DichVuService } from 'src/app/shared/DichVu.service';

import { NhanVien } from 'src/app/shared/NhanVien.model';
import { NhanVienService } from 'src/app/shared/NhanVien.service';

import { DoanhNghiep } from 'src/app/shared/DoanhNghiep.model';
import { DoanhNghiepService } from 'src/app/shared/DoanhNghiep.service';

import { DoanhNghiepDichVu } from 'src/app/shared/DoanhNghiepDichVu.model';
import { DoanhNghiepDichVuService } from 'src/app/shared/DoanhNghiepDichVu.service';

@Component({
  selector: 'app-doanh-nghiep-detail',
  templateUrl: './doanh-nghiep-detail.component.html',
  styleUrls: ['./doanh-nghiep-detail.component.css']
})
export class DoanhNghiepDetailComponent implements OnInit {

  @ViewChild('DoanhNghiepDichVuSort') DoanhNghiepDichVuSort: MatSort;
  @ViewChild('DoanhNghiepDichVuPaginator') DoanhNghiepDichVuPaginator: MatPaginator;

  constructor(
    public dialogRef: MatDialogRef<DoanhNghiepDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,

    public NotificationService: NotificationService,

    public DichVuService: DichVuService,   
    public NhanVienService: NhanVienService,   

    public DoanhNghiepService: DoanhNghiepService,   
    public DoanhNghiepDichVuService: DoanhNghiepDichVuService,   
  ) { }

  ngOnInit(): void {
    this.DichVuSearch();
    this.NhanVienSearch();
    this.DoanhNghiepDichVuSearch();
  }

  DichVuSearch() {
    this.DichVuService.ComponentGetAllToListAsync();
  }
  NhanVienSearch() {
    this.NhanVienService.ComponentGetAllToListAsync();
  }

  DoanhNghiepDichVuSearch() {
    this.DoanhNghiepDichVuService.IsShowLoading = true; 
    this.DoanhNghiepDichVuService.BaseParameter.ParentID = this.DoanhNghiepService.FormData.ID; 
    this.DoanhNghiepDichVuService.GetByParentIDToListAsync().subscribe(
      res => {
        this.DoanhNghiepDichVuService.List = (res as DoanhNghiepDichVu[]).sort((a, b) => (a.Name > b.Name ? 1 : -1));
        this.DoanhNghiepDichVuService.DataSource = new MatTableDataSource(this.DoanhNghiepDichVuService.List);
        this.DoanhNghiepDichVuService.DataSource.sort = this.DoanhNghiepDichVuSort;
        this.DoanhNghiepDichVuService.DataSource.paginator = this.DoanhNghiepDichVuPaginator;
        this.DoanhNghiepDichVuService.IsShowLoading = false;
      },
      err => {
        this.DoanhNghiepDichVuService.IsShowLoading = false;
      }
    );
  }

  Close() {
    this.dialogRef.close();
  }
}

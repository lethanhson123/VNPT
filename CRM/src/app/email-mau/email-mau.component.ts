import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NotificationService } from 'src/app/shared/notification.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';


import { EmailLichSu } from 'src/app/shared/EmailLichSu.model';
import { EmailLichSuService } from 'src/app/shared/EmailLichSu.service';

import { EmailMau } from 'src/app/shared/EmailMau.model';
import { EmailMauService } from 'src/app/shared/EmailMau.service';
import { EmailMauDetailComponent } from '../email-mau-detail/email-mau-detail.component';

@Component({
  selector: 'app-email-mau',
  templateUrl: './email-mau.component.html',
  styleUrls: ['./email-mau.component.css']
})
export class EmailMauComponent implements OnInit { 

  dataSourceEmailLichSu: MatTableDataSource<any>;
  @ViewChild('sortEmailLichSu') sortEmailLichSu: MatSort;
  @ViewChild('paginatorEmailLichSu') paginatorEmailLichSu: MatPaginator;

  dataSourceEmailMau: MatTableDataSource<any>;
  @ViewChild('sortEmailMau') sortEmailMau: MatSort;
  @ViewChild('paginatorEmailMau') paginatorEmailMau: MatPaginator;


  isShowLoading: boolean = false;
  searchString: string = environment.InitializationString;
  
  year: number = new Date().getFullYear();
  month: number = new Date().getMonth() + 1;

  
  constructor(
    private dialog: MatDialog,
    public NotificationService: NotificationService,

    public EmailLichSuService: EmailLichSuService,   
    public EmailMauService: EmailMauService,   

  ) { }

  ngOnInit(): void {
   
  }
  DateEmailLichSuBatDau(value) {
    this.EmailLichSuService.BaseParameter.BatDau = new Date(value);
  }
  DateEmailLichSuKetThuc(value) {
    this.EmailLichSuService.BaseParameter.KetThuc = new Date(value);
  }
  
  EmailLichSuSearch() {
    this.isShowLoading = true;
    this.EmailLichSuService.GetBySearchString_BatDau_KetThucToListAsync().subscribe(
      res => {
        this.EmailLichSuService.list = (res as EmailLichSu[]);
        this.dataSourceEmailLichSu = new MatTableDataSource(this.EmailLichSuService.list);
        this.dataSourceEmailLichSu.sort = this.sortEmailLichSu;
        this.dataSourceEmailLichSu.paginator = this.paginatorEmailLichSu;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }  

  EmailMauSearch() {
    this.isShowLoading = true;
    this.EmailMauService.GetAllToListAsync().subscribe(
      res => {
        this.EmailMauService.list = (res as EmailMau[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));;
        this.dataSourceEmailMau = new MatTableDataSource(this.EmailMauService.list);
        this.dataSourceEmailMau.sort = this.sortEmailMau;
        this.dataSourceEmailMau.paginator = this.paginatorEmailMau;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }  
  EmailMauAdd(ID: number) { 
    this.isShowLoading = true;
    this.EmailMauService.GetByIDAsync(ID).subscribe(
      res => {
        this.EmailMauService.formData = res as EmailMau;
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(EmailMauDetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {          
        });
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
}

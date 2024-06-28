import { Component, OnInit, Inject, ElementRef, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';

import { EmailMau } from 'src/app/shared/EmailMau.model';
import { EmailMauService } from 'src/app/shared/EmailMau.service';
import { EmailMauTapTinDinhKem } from 'src/app/shared/EmailMauTapTinDinhKem.model';
import { EmailMauTapTinDinhKemService } from 'src/app/shared/EmailMauTapTinDinhKem.service';

@Component({
  selector: 'app-email-mau-detail',
  templateUrl: './email-mau-detail.component.html',
  styleUrls: ['./email-mau-detail.component.css']
})
export class EmailMauDetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  isShowLoading: boolean = false;

  constructor(

    public dialogRef: MatDialogRef<EmailMauDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,

    public NotificationService: NotificationService,

    public EmailMauService: EmailMauService,
    public EmailMauTapTinDinhKemService: EmailMauTapTinDinhKemService,

  ) {
    this.ID = data["ID"] as number;
  }

  ngOnInit(): void {
    this.EmailMauTapTinDinhKemSearch();
  }

  Close() {
    this.dialogRef.close();
  }
  ChangeFileName(files: FileList) {
    if (files) {
      this.EmailMauService.FileToUpload = files;
    }
  }
  EmailMauTapTinDinhKemChangeFileName(files: FileList) {
    if (files) {
      this.EmailMauTapTinDinhKemService.FileToUpload = files;
    }
  }

  Save() {
    this.isShowLoading = true;
    this.EmailMauService.SaveAndUploadFileAsync().subscribe(
      res => {
        this.EmailMauService.formData = res as EmailMau;
        this.EmailMauTapTinDinhKemSave();
        this.isShowLoading = false;
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.isShowLoading = false;
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  }
  EmailMauTapTinDinhKemSave() {
    this.isShowLoading = true;
    this.EmailMauTapTinDinhKemService.formData.ParentID = this.EmailMauService.formData.ID;
    this.EmailMauTapTinDinhKemService.SaveAndUploadFilesAsync().subscribe(
      res => {
        this.EmailMauTapTinDinhKemSearch();
        this.isShowLoading = false;        
      },
      err => {
        this.isShowLoading = false;        
      }
    );
  }
  EmailMauTapTinDinhKemSearch() {
    this.isShowLoading = true;
    this.EmailMauTapTinDinhKemService.GetByParentIDToListAsync(this.EmailMauService.formData.ID).subscribe(
      res => {
        this.EmailMauTapTinDinhKemService.list = (res as EmailMauTapTinDinhKem[]);
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
}
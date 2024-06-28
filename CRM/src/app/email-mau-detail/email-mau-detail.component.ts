import { Component, OnInit, Inject, ElementRef, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { EmailMau } from 'src/app/shared/EmailMau.model';
import { EmailMauService } from 'src/app/shared/EmailMau.service';


@Component({
  selector: 'app-email-mau-detail',
  templateUrl: './email-mau-detail.component.html',
  styleUrls: ['./email-mau-detail.component.css']
})
export class EmailMauDetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  isShowLoading: boolean = false;
  @ViewChild('uploadHopDong') uploadHopDong!: ElementRef;
  @ViewChild('uploadDonXinCapChungThuSo') uploadDonXinCapChungThuSo!: ElementRef;
  @ViewChild('uploadCCCD') uploadCCCD!: ElementRef;
  @ViewChild('uploadGiayPhepKinhDoanh') uploadGiayPhepKinhDoanh!: ElementRef;
  @ViewChild('uploadBienBanNghiemThu') uploadBienBanNghiemThu!: ElementRef;
  @ViewChild('uploadHoaDon') uploadHoaDon!: ElementRef;

  constructor(

    public dialogRef: MatDialogRef<EmailMauDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,

    public NotificationService: NotificationService,
    public EmailMauService: EmailMauService,
    
    
  ) {
    this.ID = data["ID"] as number;
  }

  ngOnInit(): void {
  }

  Close() {
    this.dialogRef.close();
  }
  ChangeFileName(files: FileList) {
    if (files) {
      this.EmailMauService.FileToUpload = files;      
    }
  }
  Save() {    
    this.isShowLoading = true;    
    this.EmailMauService.SaveAndUploadFileAsync().subscribe(
      res => {
        this.EmailMauService.formData = res as EmailMau;
        this.isShowLoading = false;
        this.NotificationService.warn(environment.SaveSuccess);
      },
      err => {
        this.isShowLoading = false;
        this.NotificationService.warn(environment.SaveNotSuccess);
      }
    );
  } 
}
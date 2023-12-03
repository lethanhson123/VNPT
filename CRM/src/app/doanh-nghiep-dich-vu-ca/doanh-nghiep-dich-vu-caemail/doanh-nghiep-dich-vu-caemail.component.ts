import { Component, OnInit, Inject, ElementRef, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { DoanhNghiepDichVuCA } from 'src/app/shared/DoanhNghiepDichVuCA.model';
import { DoanhNghiepDichVuCAService } from 'src/app/shared/DoanhNghiepDichVuCA.service';

@Component({
  selector: 'app-doanh-nghiep-dich-vu-caemail',
  templateUrl: './doanh-nghiep-dich-vu-caemail.component.html',
  styleUrls: ['./doanh-nghiep-dich-vu-caemail.component.css']
})
export class DoanhNghiepDichVuCAEmailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  isShowLoading: boolean = false;
  constructor(
    public DoanhNghiepDichVuCAService: DoanhNghiepDichVuCAService,
    public NotificationService: NotificationService,
    public dialogRef: MatDialogRef<DoanhNghiepDichVuCAEmailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.ID = data["ID"] as number;
  }

  ngOnInit(): void {
  }
  onClose() {
    this.dialogRef.close();
  }

  onSubmit() {    
    this.isShowLoading = true;
    this.DoanhNghiepDichVuCAService.Save001Async(this.DoanhNghiepDichVuCAService.formData).subscribe(
      res => {
        this.DoanhNghiepDichVuCAService.formData = res as DoanhNghiepDichVuCA;
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

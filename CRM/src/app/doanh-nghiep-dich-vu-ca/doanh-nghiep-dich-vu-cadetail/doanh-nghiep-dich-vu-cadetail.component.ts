import { Component, OnInit, Inject, ElementRef, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { DoanhNghiepDichVuCA } from 'src/app/shared/DoanhNghiepDichVuCA.model';
import { DoanhNghiepDichVuCAService } from 'src/app/shared/DoanhNghiepDichVuCA.service';
import { EmailService } from 'src/app/shared/Email.service';
@Component({
  selector: 'app-doanh-nghiep-dich-vu-cadetail',
  templateUrl: './doanh-nghiep-dich-vu-cadetail.component.html',
  styleUrls: ['./doanh-nghiep-dich-vu-cadetail.component.css']
})
export class DoanhNghiepDichVuCADetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  isShowLoading: boolean = false;
  @ViewChild('uploadHopDong') uploadHopDong!: ElementRef;
  @ViewChild('uploadDonXinCapChungThuSo') uploadDonXinCapChungThuSo!: ElementRef;
  @ViewChild('uploadCCCD') uploadCCCD!: ElementRef;
  @ViewChild('uploadGiayPhepKinhDoanh') uploadGiayPhepKinhDoanh!: ElementRef;
  @ViewChild('uploadBienBanNghiemThu') uploadBienBanNghiemThu!: ElementRef;
  @ViewChild('uploadHoaDon') uploadHoaDon!: ElementRef;

  constructor(
    public DoanhNghiepDichVuCAService: DoanhNghiepDichVuCAService,
    public NotificationService: NotificationService,
    public EmailService: EmailService,
    public dialogRef: MatDialogRef<DoanhNghiepDichVuCADetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.ID = data["ID"] as number;
  }

  ngOnInit(): void {
  }
  onClose() {
    this.dialogRef.close();
  }
  DateNgayHieuLuc(value) {
    this.DoanhNghiepDichVuCAService.formData.NgayHieuLuc = new Date(value);
  }
  DateNgayHetHanNguyenMau(value) {
    this.DoanhNghiepDichVuCAService.formData.NgayHetHanNguyenMau = new Date(value);
  }
  HopDongDelete() {
    this.DoanhNghiepDichVuCAService.formData.HopDong = environment.InitializationString;
  }
  BienBanNghiemThuDelete() {
    this.DoanhNghiepDichVuCAService.formData.BienBanNghiemThu = environment.InitializationString;
  }
  CCCDDelete() {
    this.DoanhNghiepDichVuCAService.formData.CCCD = environment.InitializationString;
  }
  DonXinCapChungThuSoDelete() {
    this.DoanhNghiepDichVuCAService.formData.DonXinCapChungThuSo = environment.InitializationString;
  }
  HoaDonDelete() {
    this.DoanhNghiepDichVuCAService.formData.HoaDon = environment.InitializationString;
  }
  GiayPhepKinhDoanhDelete() {
    this.DoanhNghiepDichVuCAService.formData.GiayPhepKinhDoanh = environment.InitializationString;
  }
  onSubmit() {
    let fileHopDong: File;
    fileHopDong = this.uploadHopDong.nativeElement.files[0];
    let fileDonXinCapChungThuSo: File;
    fileDonXinCapChungThuSo = this.uploadDonXinCapChungThuSo.nativeElement.files[0];
    let fileGiayPhepKinhDoanh: File;
    fileGiayPhepKinhDoanh = this.uploadGiayPhepKinhDoanh.nativeElement.files[0];
    let fileBienBanNghiemThu: File;
    fileBienBanNghiemThu = this.uploadBienBanNghiemThu.nativeElement.files[0];
    let fileHoaDon: File;
    fileHoaDon = this.uploadHoaDon.nativeElement.files[0];
    let fileCCCD: File;
    fileCCCD = this.uploadCCCD.nativeElement.files[0];
    this.isShowLoading = true;
    this.DoanhNghiepDichVuCAService.SaveAndUploadFilesAsync(this.DoanhNghiepDichVuCAService.formData, fileHopDong, fileDonXinCapChungThuSo, fileGiayPhepKinhDoanh, fileBienBanNghiemThu, fileHoaDon, fileCCCD).subscribe(
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
  onSendEmail() {
    this.isShowLoading = true;
    this.EmailService.BaseParameter.ID = this.DoanhNghiepDichVuCAService.formData.ID;
    this.EmailService.AsyncHetHanDoanhNghiepDichVuCA2024().subscribe(
      res => {
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
}

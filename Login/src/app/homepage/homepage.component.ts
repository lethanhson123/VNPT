import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NhanVien } from 'src/app/shared/NhanVien.model';
import { NhanVienService } from 'src/app/shared/NhanVien.service';
import { NotificationService } from 'src/app/shared/notification.service';


@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  isShowLoading: boolean = false;
  constructor(
    public NhanVienService: NhanVienService,
    public NotificationService: NotificationService,
  ) {
    this.GetByIDAsync();
  }

  ngOnInit(): void {
  }
  GetByIDAsync() {
    this.isShowLoading = true;
    this.NhanVienService.GetByIDAsync(0).subscribe(
      res => {
        this.NhanVienService.formData = res as NhanVien;
        this.isShowLoading = false;
      },
      err => {
        this.isShowLoading = false;
      }
    );
  }
  onAuthenticationAsync() {
    this.isShowLoading = true;
    this.NhanVienService.AuthenticationAsync(this.NhanVienService.formData).subscribe(
      res => {
        this.isShowLoading = false;
        this.NhanVienService.formData = res as NhanVien;
        if (this.NhanVienService.formData) {
          if (this.NhanVienService.formData.ID > 0) {
            localStorage.setItem(environment.NhanVienID, this.NhanVienService.formData.ID.toString());
            window.location.href = environment.DomainDestination + "XacThucOTP";
          }
          else {
            this.NotificationService.success(environment.LoginNotSuccess);
          }
        }
        else {
          this.NotificationService.success(environment.LoginNotSuccess);
        }
      },
      err => {
        this.NotificationService.warn(environment.LoginNotSuccess);
        this.isShowLoading = false;
      }
    );
  }
}

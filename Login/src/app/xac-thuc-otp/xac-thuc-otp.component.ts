import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NhanVienToken } from 'src/app/shared/NhanVienToken.model';
import { NhanVienTokenService } from 'src/app/shared/NhanVienToken.service';
import { NotificationService } from 'src/app/shared/notification.service';


@Component({
  selector: 'app-xac-thuc-otp',
  templateUrl: './xac-thuc-otp.component.html',
  styleUrls: ['./xac-thuc-otp.component.css']
})
export class XacThucOTPComponent implements OnInit {

  isShowLoading: boolean = false;
  constructor(
    public NhanVienTokenService: NhanVienTokenService,
    public NotificationService: NotificationService,
  ) { }

  ngOnInit(): void {
  }
  onAuthenticationAsync() {
    this.isShowLoading = true;
    var nhanVienID = localStorage.getItem(environment.NhanVienID);
    if (nhanVienID) {
      this.NhanVienTokenService.formData.ParentID = Number(nhanVienID);
      this.NhanVienTokenService.formData.Description = environment.TokenAPI;
      this.NhanVienTokenService.AuthenticationAsync(this.NhanVienTokenService.formData).subscribe(
        res => {
          this.isShowLoading = false;
          this.NhanVienTokenService.formData = res as NhanVienToken;
          if (this.NhanVienTokenService.formData) {
            if (this.NhanVienTokenService.formData.ID > 0) {
              let url = environment.CRM + "Homepage?" + environment.Token + "=" + this.NhanVienTokenService.formData.Token;
              //alert(url);
              window.location.href = url;
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
    else {
      window.location.href = environment.DomainDestination + "Homepage";
    }

  }
}

import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Router, NavigationEnd } from '@angular/router';
import { NhanVien } from 'src/app/shared/NhanVien.model';
import { NhanVienService } from 'src/app/shared/NhanVien.service';
import { NhanVienToken } from 'src/app/shared/NhanVienToken.model';
import { NhanVienTokenService } from 'src/app/shared/NhanVienToken.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'CRM';
  domainName = environment.DomainDestination;
  domainURL = environment.DomainURL;
  queryString: string = environment.InitializationString;
  constructor(
    public router: Router,
    public NhanVienService: NhanVienService,
    public NhanVienTokenService: NhanVienTokenService,
  ) {    
    this.getByQueryString();
  }
  getByQueryString() {
    this.router.events.forEach((event) => {
      if (event instanceof NavigationEnd) {
        this.queryString = event.url;
        if (this.queryString.indexOf(environment.Token) > -1) {
          localStorage.setItem(environment.Token, this.queryString.split('=')[this.queryString.split('=').length - 1]);
        }        
        this.AuthenticationToken();
      }
    });
  }
  AuthenticationToken() {
    let token = localStorage.getItem(environment.Token);    
    let isLogin = true;
    if (token == null) {
      isLogin = false;
    }
    else {
      this.NhanVienTokenService.GetByTokenAsync(token).subscribe(
        res => {
          this.NhanVienTokenService.formData = res as NhanVienToken;
          if (this.NhanVienTokenService.formData != null) {
            if (this.NhanVienTokenService.formData.ParentID > 0) {              
              this.NhanVienService.GetByIDAsync(this.NhanVienTokenService.formData.ParentID).subscribe(
                res => {
                  this.NhanVienService.formDataLogin = res as NhanVien;
                  if (this.NhanVienService.formDataLogin) {
                    localStorage.setItem(environment.NhanVienID, this.NhanVienService.formDataLogin.ID.toString());
                    localStorage.setItem(environment.NhanVienName, this.NhanVienService.formDataLogin.Name);
                    localStorage.setItem(environment.NhanVienEmail, this.NhanVienService.formDataLogin.Email);
                    localStorage.setItem(environment.NhanVienNote, this.NhanVienService.formDataLogin.Note);                  
                  }
                  else {
                    isLogin = false;
                  }
                },
                err => {
                  isLogin = false;
                }
              );
            }
            else {
              isLogin = false;
            }
          }
          else {
            isLogin = false;
          }
        },
        err => {
          isLogin = false;
        }
      );
    }
    if (isLogin == false) {      
      window.location.href =  environment.LoginURL;
    }
  }
  onLogout() {
    localStorage.setItem(environment.Token, environment.InitializationString);
    localStorage.setItem(environment.NhanVienID, environment.InitializationString);
    localStorage.setItem(environment.NhanVienName, environment.InitializationString);
    localStorage.setItem(environment.NhanVienEmail, environment.InitializationString);
    localStorage.setItem(environment.NhanVienNote, environment.InitializationString);    
    window.location.href = environment.LoginURL;
  }
}

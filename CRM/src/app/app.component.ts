import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Router, NavigationEnd } from '@angular/router';
import { NhanVien } from 'src/app/shared/NhanVien.model';
import { NhanVienService } from 'src/app/shared/NhanVien.service';
import { NhanVienToken } from 'src/app/shared/NhanVienToken.model';
import { NhanVienTokenService } from 'src/app/shared/NhanVienToken.service';
import { Menu } from 'src/app/shared/Menu.model';
import { MenuService } from 'src/app/shared/Menu.service';

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
  queryStringSub: string = environment.InitializationString;
  constructor(
    public router: Router,
    public NhanVienService: NhanVienService,
    public NhanVienTokenService: NhanVienTokenService,
    public MenuService: MenuService,
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
  GetMenuToListAsync() {    
    if (this.queryString) {
      if (this.queryString.length > 0) {
        this.queryStringSub = this.queryString.substring(1, this.queryString.length);
      }
    }
    this.MenuService.GetByNhanVienIDToListAsync().subscribe(
      res => {
        this.MenuService.ListChild = (res as Menu[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
        this.MenuService.ListParent = [];
        let isLogin = false;
        for (var i = 0; i < this.MenuService.ListChild.length; i++) {
          if (this.queryStringSub == this.MenuService.ListChild[i].Display) {
            this.MenuService.ListChild[i].Active = true;
          }
          else {
            this.MenuService.ListChild[i].Active = false;
          }
          if (this.queryStringSub.indexOf(this.MenuService.ListChild[i].Display) > -1) {
            isLogin = true;
          }
          this.MenuService.ListChild[i].Display = environment.DomainDestination + this.MenuService.ListChild[i].Display;
        }
        for (var i = 0; i < this.MenuService.ListChild.length; i++) {
          if (this.MenuService.ListChild[i].ParentID == 0) {
            this.MenuService.ListChild[i].Active = false;
            this.MenuService.ListChild[i].ListChild = [];
            for (var j = 0; j < this.MenuService.ListChild.length; j++) {
              if (this.MenuService.ListChild[i].ID == this.MenuService.ListChild[j].ParentID) {
                this.MenuService.ListChild[i].ListChild.push(this.MenuService.ListChild[j]);
                if (this.MenuService.ListChild[j].Active == true) {
                  this.MenuService.ListChild[i].Active = true;
                }
              }
            }
            this.MenuService.ListParent.push(this.MenuService.ListChild[i]);
          }
        }

        if (this.queryStringSub.indexOf("NhanVienDangNhap") > -1) {
          isLogin = true;
        }        
        if (this.queryStringSub.indexOf("Info") > -1) {
          isLogin = true;
        }
        if (isLogin == false) {
          let destinationURL = environment.DomainDestination
          window.location.href = destinationURL;
        }
      },
      err => {
      }
    );
  }
  MenuClick(itemParent: Menu) {
    for (var i = 0; i < this.MenuService.ListParent.length; i++) {
      this.MenuService.ListParent[i].Active = false;
      if (this.MenuService.ListParent[i].ID == itemParent.ID) {
        this.MenuService.ListParent[i].Active = true;
      }
    }
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
                    this.GetMenuToListAsync();                   
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

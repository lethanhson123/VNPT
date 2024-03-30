import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Router, NavigationEnd } from '@angular/router';
import { DownloadService } from 'src/app/shared/Download.service';


import { interval } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'VNPT';

  queryString: string = environment.InitializationString;
  queryStringSub: string = environment.InitializationString;
  constructor(
    public router: Router,
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
    localStorage.setItem(environment.NhanVienID, "1");
  }

}

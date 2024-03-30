import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {


  IsMobile: boolean = false;
  membershipID: number = 0;
  constructor(public snackBar: MatSnackBar) {
    if (localStorage.getItem("MembershipID")) {
      this.membershipID = Number(localStorage.getItem("MembershipID"));
    }
    let windowWidth = Math.floor(window.innerWidth);
    if (windowWidth < 700) {
      this.IsMobile = true;
    }
  }
  config: MatSnackBarConfig = {
    duration: 3000,
    horizontalPosition: 'right',
    verticalPosition: 'top'
  }
  success(message: string) {
    this.config['panelClass'] = ['notification', 'success'];
    this.snackBar.open(message, '', this.config);
  }

  warn(message: string) {
    this.config['panelClass'] = ['notification', 'warn'];
    this.snackBar.open(message, '', this.config);
  }
}

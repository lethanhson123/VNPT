import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Router, NavigationEnd } from '@angular/router';
import { DoanhNghiep } from 'src/app/shared/DoanhNghiep.model';
import { DoanhNghiepService } from 'src/app/shared/DoanhNghiep.service';
import { DoanhNghiepDichVuCA } from 'src/app/shared/DoanhNghiepDichVuCA.model';
import { DoanhNghiepDichVuCAService } from 'src/app/shared/DoanhNghiepDichVuCA.service';
import { DoanhNghiepDichVuCADetailComponent } from '../doanh-nghiep-dich-vu-ca/doanh-nghiep-dich-vu-cadetail/doanh-nghiep-dich-vu-cadetail.component';

@Component({
  selector: 'app-doanh-nghiep-ca',
  templateUrl: './doanh-nghiep-ca.component.html',
  styleUrls: ['./doanh-nghiep-ca.component.css']
})
export class DoanhNghiepCAComponent implements OnInit {

  dataSourceDoanhNghiepDichVuCA: MatTableDataSource<any>;
  @ViewChild('sortDoanhNghiepDichVuCA') sortDoanhNghiepDichVuCA: MatSort;
  @ViewChild('paginatorDoanhNghiepDichVuCA') paginatorDoanhNghiepDichVuCA: MatPaginator;  

  isShowLoading: boolean = false;
  queryString: string = environment.InitializationString;
  URLSub: string = environment.DomainDestination + "DoanhNghiepInfo";

  constructor(
    public router: Router,  
    private dialog: MatDialog,
    public DoanhNghiepService: DoanhNghiepService, 
    public DoanhNghiepDichVuCAService: DoanhNghiepDichVuCAService,
  ) { 
    this.router.events.forEach((event) => {
      if (event instanceof NavigationEnd) {
        this.queryString = event.url;
        this.GetByQueryString();       
      }
    });
  }

  ngOnInit(): void {
  }
  GetByQueryString() {
    this.isShowLoading = true;
    this.DoanhNghiepService.GetByIDStringAsync(this.queryString).then(res => {
      this.DoanhNghiepService.formData = res as DoanhNghiep;
      if (this.DoanhNghiepService.formData) {       
        this.GetDoanhNghiepDichVuCAToListAsync();
      }
      this.isShowLoading = false;
    });
  }
  GetDoanhNghiepDichVuCAToListAsync() {
    this.DoanhNghiepDichVuCAService.GetByParentIDToListAsync(this.DoanhNghiepService.formData.ID).subscribe(
      res => {
        this.DoanhNghiepDichVuCAService.list = (res as DoanhNghiepDichVuCA[]).sort((a, b) => (a.NgayHieuLuc < b.NgayHieuLuc ? 1 : -1));
        this.dataSourceDoanhNghiepDichVuCA = new MatTableDataSource(this.DoanhNghiepDichVuCAService.list);
        this.dataSourceDoanhNghiepDichVuCA.sort = this.sortDoanhNghiepDichVuCA;
        this.dataSourceDoanhNghiepDichVuCA.paginator = this.paginatorDoanhNghiepDichVuCA;
      },
      err => {
      }
    );
  }
  onAddDoanhNghiepDichVuCA(ID: any) {
    this.DoanhNghiepDichVuCAService.GetByIDAsync(ID).subscribe(
      res => {
        this.DoanhNghiepDichVuCAService.formData = res as DoanhNghiepDichVuCA;
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        dialogConfig.width = environment.DialogConfigWidth;
        dialogConfig.data = { ID: ID };
        const dialog = this.dialog.open(DoanhNghiepDichVuCADetailComponent, dialogConfig);
        dialog.afterClosed().subscribe(() => {
          this.GetDoanhNghiepDichVuCAToListAsync();
        });
      },
      err => {
      }
    );
  }
}

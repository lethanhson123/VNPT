import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardHoaDonDienTuComponent } from './dashboard-hoa-don-dien-tu.component';

describe('DashboardHoaDonDienTuComponent', () => {
  let component: DashboardHoaDonDienTuComponent;
  let fixture: ComponentFixture<DashboardHoaDonDienTuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardHoaDonDienTuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardHoaDonDienTuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

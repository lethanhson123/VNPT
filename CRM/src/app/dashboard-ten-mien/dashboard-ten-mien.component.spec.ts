import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardTenMienComponent } from './dashboard-ten-mien.component';

describe('DashboardTenMienComponent', () => {
  let component: DashboardTenMienComponent;
  let fixture: ComponentFixture<DashboardTenMienComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardTenMienComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardTenMienComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

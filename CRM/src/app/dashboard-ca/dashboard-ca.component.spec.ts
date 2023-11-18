import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardCAComponent } from './dashboard-ca.component';

describe('DashboardCAComponent', () => {
  let component: DashboardCAComponent;
  let fixture: ComponentFixture<DashboardCAComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardCAComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardCAComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

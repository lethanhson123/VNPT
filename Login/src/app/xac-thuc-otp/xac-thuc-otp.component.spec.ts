import { ComponentFixture, TestBed } from '@angular/core/testing';

import { XacThucOTPComponent } from './xac-thuc-otp.component';

describe('XacThucOTPComponent', () => {
  let component: XacThucOTPComponent;
  let fixture: ComponentFixture<XacThucOTPComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ XacThucOTPComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(XacThucOTPComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

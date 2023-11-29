import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NhanVienDangNhapComponent } from './nhan-vien-dang-nhap.component';

describe('NhanVienDangNhapComponent', () => {
  let component: NhanVienDangNhapComponent;
  let fixture: ComponentFixture<NhanVienDangNhapComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NhanVienDangNhapComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NhanVienDangNhapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

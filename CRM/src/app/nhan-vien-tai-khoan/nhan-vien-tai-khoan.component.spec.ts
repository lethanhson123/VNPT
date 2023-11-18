import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NhanVienTaiKhoanComponent } from './nhan-vien-tai-khoan.component';

describe('NhanVienTaiKhoanComponent', () => {
  let component: NhanVienTaiKhoanComponent;
  let fixture: ComponentFixture<NhanVienTaiKhoanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NhanVienTaiKhoanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NhanVienTaiKhoanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

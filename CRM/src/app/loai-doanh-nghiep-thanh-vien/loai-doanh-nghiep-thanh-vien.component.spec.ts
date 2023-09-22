import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoaiDoanhNghiepThanhVienComponent } from './loai-doanh-nghiep-thanh-vien.component';

describe('LoaiDoanhNghiepThanhVienComponent', () => {
  let component: LoaiDoanhNghiepThanhVienComponent;
  let fixture: ComponentFixture<LoaiDoanhNghiepThanhVienComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoaiDoanhNghiepThanhVienComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoaiDoanhNghiepThanhVienComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

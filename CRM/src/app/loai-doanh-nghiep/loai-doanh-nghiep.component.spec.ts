import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoaiDoanhNghiepComponent } from './loai-doanh-nghiep.component';

describe('LoaiDoanhNghiepComponent', () => {
  let component: LoaiDoanhNghiepComponent;
  let fixture: ComponentFixture<LoaiDoanhNghiepComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoaiDoanhNghiepComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoaiDoanhNghiepComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

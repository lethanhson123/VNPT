import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoanhNghiepMaSoThueKhongTonTaiComponent } from './doanh-nghiep-ma-so-thue-khong-ton-tai.component';

describe('DoanhNghiepMaSoThueKhongTonTaiComponent', () => {
  let component: DoanhNghiepMaSoThueKhongTonTaiComponent;
  let fixture: ComponentFixture<DoanhNghiepMaSoThueKhongTonTaiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoanhNghiepMaSoThueKhongTonTaiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DoanhNghiepMaSoThueKhongTonTaiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

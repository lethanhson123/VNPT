import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoanhNghiepDichVuCAComponent } from './doanh-nghiep-dich-vu-ca.component';

describe('DoanhNghiepDichVuCAComponent', () => {
  let component: DoanhNghiepDichVuCAComponent;
  let fixture: ComponentFixture<DoanhNghiepDichVuCAComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoanhNghiepDichVuCAComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DoanhNghiepDichVuCAComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

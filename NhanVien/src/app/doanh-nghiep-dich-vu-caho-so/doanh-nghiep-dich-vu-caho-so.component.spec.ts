import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoanhNghiepDichVuCAHoSoComponent } from './doanh-nghiep-dich-vu-caho-so.component';

describe('DoanhNghiepDichVuCAHoSoComponent', () => {
  let component: DoanhNghiepDichVuCAHoSoComponent;
  let fixture: ComponentFixture<DoanhNghiepDichVuCAHoSoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoanhNghiepDichVuCAHoSoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DoanhNghiepDichVuCAHoSoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

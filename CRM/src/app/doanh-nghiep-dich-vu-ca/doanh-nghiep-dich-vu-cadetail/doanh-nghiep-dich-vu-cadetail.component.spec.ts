import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoanhNghiepDichVuCADetailComponent } from './doanh-nghiep-dich-vu-cadetail.component';

describe('DoanhNghiepDichVuCADetailComponent', () => {
  let component: DoanhNghiepDichVuCADetailComponent;
  let fixture: ComponentFixture<DoanhNghiepDichVuCADetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoanhNghiepDichVuCADetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DoanhNghiepDichVuCADetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

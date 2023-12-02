import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoanhNghiepDichVuCAEmailComponent } from './doanh-nghiep-dich-vu-caemail.component';

describe('DoanhNghiepDichVuCAEmailComponent', () => {
  let component: DoanhNghiepDichVuCAEmailComponent;
  let fixture: ComponentFixture<DoanhNghiepDichVuCAEmailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoanhNghiepDichVuCAEmailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DoanhNghiepDichVuCAEmailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

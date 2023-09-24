import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoanhNghiepInfoComponent } from './doanh-nghiep-info.component';

describe('DoanhNghiepInfoComponent', () => {
  let component: DoanhNghiepInfoComponent;
  let fixture: ComponentFixture<DoanhNghiepInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoanhNghiepInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DoanhNghiepInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

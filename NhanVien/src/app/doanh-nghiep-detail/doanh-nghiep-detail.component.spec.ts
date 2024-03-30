import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoanhNghiepDetailComponent } from './doanh-nghiep-detail.component';

describe('DoanhNghiepDetailComponent', () => {
  let component: DoanhNghiepDetailComponent;
  let fixture: ComponentFixture<DoanhNghiepDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoanhNghiepDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DoanhNghiepDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

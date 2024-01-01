import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoanhNghiepCAComponent } from './doanh-nghiep-ca.component';

describe('DoanhNghiepCAComponent', () => {
  let component: DoanhNghiepCAComponent;
  let fixture: ComponentFixture<DoanhNghiepCAComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoanhNghiepCAComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DoanhNghiepCAComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

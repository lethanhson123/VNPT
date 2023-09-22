import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NganhNgheKinhDoanhComponent } from './nganh-nghe-kinh-doanh.component';

describe('NganhNgheKinhDoanhComponent', () => {
  let component: NganhNgheKinhDoanhComponent;
  let fixture: ComponentFixture<NganhNgheKinhDoanhComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NganhNgheKinhDoanhComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NganhNgheKinhDoanhComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

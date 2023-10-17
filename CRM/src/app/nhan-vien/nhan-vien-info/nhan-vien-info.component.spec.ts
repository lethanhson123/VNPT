import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NhanVienInfoComponent } from './nhan-vien-info.component';

describe('NhanVienInfoComponent', () => {
  let component: NhanVienInfoComponent;
  let fixture: ComponentFixture<NhanVienInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NhanVienInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NhanVienInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

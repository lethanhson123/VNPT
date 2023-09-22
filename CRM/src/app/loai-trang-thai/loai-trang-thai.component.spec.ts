import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoaiTrangThaiComponent } from './loai-trang-thai.component';

describe('LoaiTrangThaiComponent', () => {
  let component: LoaiTrangThaiComponent;
  let fixture: ComponentFixture<LoaiTrangThaiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoaiTrangThaiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoaiTrangThaiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

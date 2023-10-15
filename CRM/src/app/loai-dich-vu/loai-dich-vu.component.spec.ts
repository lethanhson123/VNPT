import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoaiDichVuComponent } from './loai-dich-vu.component';

describe('LoaiDichVuComponent', () => {
  let component: LoaiDichVuComponent;
  let fixture: ComponentFixture<LoaiDichVuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoaiDichVuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoaiDichVuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

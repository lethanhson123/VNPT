import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhanQuyenMenuComponent } from './phan-quyen-menu.component';

describe('PhanQuyenMenuComponent', () => {
  let component: PhanQuyenMenuComponent;
  let fixture: ComponentFixture<PhanQuyenMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PhanQuyenMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PhanQuyenMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

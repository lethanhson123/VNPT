import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhongBanInfoComponent } from './phong-ban-info.component';

describe('PhongBanInfoComponent', () => {
  let component: PhongBanInfoComponent;
  let fixture: ComponentFixture<PhongBanInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PhongBanInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PhongBanInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

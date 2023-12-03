import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CASmartComponent } from './casmart.component';

describe('CASmartComponent', () => {
  let component: CASmartComponent;
  let fixture: ComponentFixture<CASmartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CASmartComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CASmartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

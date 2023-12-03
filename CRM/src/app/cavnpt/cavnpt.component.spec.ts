import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CAVNPTComponent } from './cavnpt.component';

describe('CAVNPTComponent', () => {
  let component: CAVNPTComponent;
  let fixture: ComponentFixture<CAVNPTComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CAVNPTComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CAVNPTComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

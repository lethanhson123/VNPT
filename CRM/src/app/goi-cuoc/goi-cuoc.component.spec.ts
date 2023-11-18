import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoiCuocComponent } from './goi-cuoc.component';

describe('GoiCuocComponent', () => {
  let component: GoiCuocComponent;
  let fixture: ComponentFixture<GoiCuocComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GoiCuocComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GoiCuocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

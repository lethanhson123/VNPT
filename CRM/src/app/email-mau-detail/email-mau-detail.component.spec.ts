import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmailMauDetailComponent } from './email-mau-detail.component';

describe('EmailMauDetailComponent', () => {
  let component: EmailMauDetailComponent;
  let fixture: ComponentFixture<EmailMauDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmailMauDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmailMauDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

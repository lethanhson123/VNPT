import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmailMauComponent } from './email-mau.component';

describe('EmailMauComponent', () => {
  let component: EmailMauComponent;
  let fixture: ComponentFixture<EmailMauComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmailMauComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmailMauComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PackagePaymentModalComponent } from './package-payment-modal.component';

describe('PackagePaymentModalComponent', () => {
  let component: PackagePaymentModalComponent;
  let fixture: ComponentFixture<PackagePaymentModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PackagePaymentModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PackagePaymentModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

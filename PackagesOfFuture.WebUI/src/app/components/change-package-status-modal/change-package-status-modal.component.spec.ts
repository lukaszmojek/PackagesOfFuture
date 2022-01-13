import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangePackageStatusModalComponent } from './change-package-status-modal.component';

describe('ChangePackageStatusModalComponent', () => {
  let component: ChangePackageStatusModalComponent;
  let fixture: ComponentFixture<ChangePackageStatusModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChangePackageStatusModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChangePackageStatusModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

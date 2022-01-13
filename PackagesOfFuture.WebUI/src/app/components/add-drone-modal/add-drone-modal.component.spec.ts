import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDroneModalComponent } from './add-drone-modal.component';

describe('AddDroneModalComponent', () => {
  let component: AddDroneModalComponent;
  let fixture: ComponentFixture<AddDroneModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddDroneModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddDroneModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

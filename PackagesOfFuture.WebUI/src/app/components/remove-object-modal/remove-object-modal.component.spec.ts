import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoveObjectModalComponent } from './remove-object-modal.component';

describe('RemoveObjectModalComponent', () => {
  let component: RemoveObjectModalComponent;
  let fixture: ComponentFixture<RemoveObjectModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RemoveObjectModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RemoveObjectModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

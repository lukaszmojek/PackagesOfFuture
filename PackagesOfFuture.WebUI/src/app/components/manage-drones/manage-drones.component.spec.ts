import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageDronesComponent } from './manage-drones.component';

describe('ManageDronesComponent', () => {
  let component: ManageDronesComponent;
  let fixture: ComponentFixture<ManageDronesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageDronesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageDronesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageSortingComponent } from './manage-sorting.component';

describe('ManageSortingComponent', () => {
  let component: ManageSortingComponent;
  let fixture: ComponentFixture<ManageSortingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageSortingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageSortingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

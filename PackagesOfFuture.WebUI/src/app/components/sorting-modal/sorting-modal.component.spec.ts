import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SortingModalComponent } from './sorting-modal.component';

describe('SortingModalComponent', () => {
  let component: SortingModalComponent;
  let fixture: ComponentFixture<SortingModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SortingModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SortingModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { HttpClientTestingModule } from '@angular/common/http/testing';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { provideMockStore } from '@ngrx/store/testing';
import { initialState } from 'src/app/auth/auth.reducer';
import { MaterialModule } from 'src/app/material.module';

import { PackageListComponent } from './package-list.component';

describe('PackageListComponent', () => {
  let component: PackageListComponent;
  let fixture: ComponentFixture<PackageListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PackageListComponent ],
      imports: [ MaterialModule, HttpClientTestingModule, BrowserAnimationsModule],
      providers: [
        provideMockStore({ initialState })
      ],
      schemas: [ NO_ERRORS_SCHEMA ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PackageListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

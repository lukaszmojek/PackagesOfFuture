import { ComponentFixture, TestBed } from '@angular/core/testing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterTestingModule } from '@angular/router/testing';
import { MockStore, provideMockStore } from '@ngrx/store/testing';
import { MenuComponent } from '../menu/menu.component';
import { MaterialModule } from '../shared/material.module';
import { IApplicationState } from '../state';

import { MainAppComponent } from './main-app.component';

describe('MainAppComponent', () => {
  let component: MainAppComponent;
  let fixture: ComponentFixture<MainAppComponent>;
  let store: MockStore

  const initialState: IApplicationState = {} as IApplicationState

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MainAppComponent, MenuComponent ],
      imports: [ RouterTestingModule, MaterialModule, BrowserAnimationsModule ],
      providers: [
        provideMockStore({ initialState })
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MainAppComponent);
    store = TestBed.inject(MockStore)
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

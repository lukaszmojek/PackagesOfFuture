import { TestBed } from '@angular/core/testing';
import { AuthorizationService } from './authorization.service';
import { provideMockStore, MockStore } from '@ngrx/store/testing';
import { IApplicationState } from '../state';
import { IAuthState } from './auth.reducer';

describe('AuthorizationService', () => {
  let service: AuthorizationService;
  let store: MockStore

  const initialState: IApplicationState = { 
    auth: {token: ''} as IAuthState
  }

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        provideMockStore({ initialState })
      ]
    });

    service = TestBed.inject(AuthorizationService);
    store = TestBed.inject(MockStore);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing'
import { RouterTestingModule } from '@angular/router/testing'
import { provideMockStore } from '@ngrx/store/testing'
import { AppComponent } from './app.component'
import { initialState } from './auth/auth.reducer'
import { MainAppComponent } from './components/main-app/main-app.component'

describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      declarations: [AppComponent, MainAppComponent],
      providers: [
        provideMockStore({ initialState })
      ]
    }).compileComponents()
  })

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent)
    const app = fixture.componentInstance

    expect(app).toBeTruthy()
  })
})

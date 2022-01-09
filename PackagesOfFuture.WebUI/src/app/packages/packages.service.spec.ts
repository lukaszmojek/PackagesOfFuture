import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { PackagesService } from './packages.service';

describe('PackagesService', () => {
  let service: PackagesService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ]
    });
    service = TestBed.inject(PackagesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

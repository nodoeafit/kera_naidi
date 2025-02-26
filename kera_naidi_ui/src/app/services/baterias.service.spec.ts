import { TestBed } from '@angular/core/testing';

import { BateriasService } from './baterias.service';

describe('BateriasService', () => {
  let service: BateriasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BateriasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

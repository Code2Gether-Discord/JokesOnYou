/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { HandleErrorService } from './handle-error.service';

describe('Service: HandleError', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HandleErrorService]
    });
  });

  it('should ...', inject([HandleErrorService], (service: HandleErrorService) => {
    expect(service).toBeTruthy();
  }));
});

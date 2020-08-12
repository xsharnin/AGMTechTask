import { TestBed, inject } from '@angular/core/testing';

import { GpsPointsService } from './gpspoints.service';

describe('GpsPointsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GpsPointsService]
    });
  });

  it('should be created', inject([GpsPointsService], (service: GpsPointsService) => {
    expect(service).toBeTruthy();
  }));
});

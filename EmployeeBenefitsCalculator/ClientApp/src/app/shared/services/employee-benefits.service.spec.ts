import { TestBed } from '@angular/core/testing';

import { EmployeeBenefitsService } from './employee-benefits.service';

describe('EmployeeBenefitsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EmployeeBenefitsService = TestBed.get(EmployeeBenefitsService);
    expect(service).toBeTruthy();
  });
});

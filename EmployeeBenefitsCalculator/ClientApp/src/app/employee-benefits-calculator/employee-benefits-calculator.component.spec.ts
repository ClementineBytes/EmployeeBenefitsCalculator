import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeBenefitsCalculatorComponent } from './employee-benefits-calculator.component';

describe('EmployeeBenefitsCalculatorComponent', () => {
  let component: EmployeeBenefitsCalculatorComponent;
  let fixture: ComponentFixture<EmployeeBenefitsCalculatorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeBenefitsCalculatorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeBenefitsCalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

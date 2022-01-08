import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms'
import { Employee } from '../shared/models/employee.model';
import { Person } from '../shared/models/person.model';
import { EmployeeBenefitsService } from '../shared/services/employee-benefits.service';

@Component({
  selector: 'app-employee-benefits-calculator',
  templateUrl: './employee-benefits-calculator.component.html',
  styleUrls: ['./employee-benefits-calculator.component.css']
})
export class EmployeeBenefitsCalculatorComponent implements OnInit {
  employeeForm: FormGroup;
  employee: Employee;
  benefitsCostPerPaycheck: string;
  costCalculated: boolean;

  constructor(private empBenefitsService: EmployeeBenefitsService) { }

  ngOnInit() {
    this.employee = {firstName:'', lastName:'', dependents:[]};
    this.benefitsCostPerPaycheck = '';
    this.costCalculated = false;
    this.employeeForm = new FormGroup({
      employeeFirstName: new FormControl('', [Validators.required, Validators.pattern('[a-zA-Z]+')]),
      employeeLastName: new FormControl('', [Validators.required, Validators.pattern('[a-zA-Z]+')]),
      dependentsForms: new FormArray([])
    })
  }

  dependents(): FormArray {
    return this.employeeForm.get("dependentsForms") as FormArray
  }

  newDependent(): FormGroup {
    return new FormGroup({
      dependentFirstName: new FormControl('', [Validators.required, Validators.pattern('[a-zA-Z]+')]),
      dependentLastName: new FormControl('', [Validators.required, Validators.pattern('[a-zA-Z]+')])
    })
  }

  addDependent() {
    this.dependents().push(this.newDependent());
  }

  removeDependent(dependentIndex:number) {
    this.dependents().removeAt(dependentIndex);
  }

  onSubmit() {
    console.log(this.employeeForm.value);
    this.hydrateEmployeeObject();
    this.empBenefitsService.calculateBenefitsCost(this.employee).subscribe(data => {
      console.log(data)
      this.employee = data;
      this.benefitsCostPerPaycheck = (Number(this.employee.benefitsCost) / 26).toFixed(2);
      this.costCalculated = true;
      this.employee.dependents = [];
    }, error => { console.log(error) })
  }

  hydrateEmployeeObject() {
    this.employee.firstName = this.employeeForm.value.employeeFirstName;
    this.employee.lastName = this.employeeForm.value.employeeLastName;
    if(this.employeeForm.value.dependentsForms.length > 0)
    {
      for(let i = 0; i < this.employeeForm.value.dependentsForms.length; i++)
      {
        this.employee.dependents.push({firstName: this.employeeForm.value.dependentsForms[i].dependentFirstName, lastName:this.employeeForm.value.dependentsForms[i].dependentLastName})
      }
    }
  }

}

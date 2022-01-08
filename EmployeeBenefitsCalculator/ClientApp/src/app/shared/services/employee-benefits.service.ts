import { HttpClient, HttpParams } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Employee } from '../models/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeBenefitsService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  calculateBenefitsCost(employeeData) {
    return this.http.post(this.baseUrl + "employeeBenefits/cost", employeeData).pipe(
      map(data => {
        const employee: Employee = data;
        return employee;
      }) 
    );
  }

}

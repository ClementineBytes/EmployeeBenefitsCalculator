import { Person } from "./person.model";

export interface Employee extends Person {
    id?: number,
    annualSalary?: number,
    numberOfPaychecksAYear?: number,
    dependents?: Person[],
    benefitsCost?: number
}
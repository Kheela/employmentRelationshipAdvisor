
import {throwError as observableThrowError,  Observable } from 'rxjs';

import {catchError, map} from 'rxjs/operators';
import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import "rxjs/Rx"

export enum SalaryType
{
    Gross = 1,
    Nett = 2
}

@Injectable()
export class EmploymentContractCalculationService {

    private baseUrl = 'http://localhost:3524/api/SchedulePermanentContractSalaryCalculation';

    constructor(private http: Http) { }

    scheduleCalculation(salary: number, salaryType: SalaryType) {
        return this.http.get(this.baseUrl + "?salary=" + salary + "&salaryType=" + salaryType).pipe(
            //.map(res => <Customer[]> res.json())
            map(res => res.json()),
            catchError(error => {
                console.log(error);
                return observableThrowError(error);
            }),);
    }

    // getCalculations() {
    //     return this.http.get(this.baseUrl)
    //         //.map(res => <Customer[]> res.json())
    //         .map(res => res.json())
    //         .catch(error => {
    //             console.log(error);
    //             return Observable.throw(error);
    //         });
    // }
}

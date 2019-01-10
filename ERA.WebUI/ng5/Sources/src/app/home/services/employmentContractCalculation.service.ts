
import {throwError as observableThrowError,  Observable } from 'rxjs';

import {catchError, map} from 'rxjs/operators';
import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import "rxjs/Rx"

@Injectable()
export class EmploymentContractCalculationService {

    private baseUrl = 'http://localhost:3524/api/SchedulePermanentContractSalaryCalculation';

    constructor(private http: Http) { }

    scheduleCalculation(salaryGross: number) {
        return this.http.get(this.baseUrl + "?salaryGross=" + salaryGross).pipe(
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

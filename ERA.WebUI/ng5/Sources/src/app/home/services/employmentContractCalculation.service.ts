import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Observable } from "rxjs/Observable";
import "rxjs/Rx"

@Injectable()
export class EmploymentContractCalculationService {

    private baseUrl = 'http://localhost:3524/api/SchedulePermanentContractSalaryCalculation';

    constructor(private http: Http) { }

    scheduleCalculation(salaryGross: number) {
        return this.http.get(this.baseUrl + "?salaryGross=" + salaryGross)
            //.map(res => <Customer[]> res.json())
            .map(res => res.json())
            .catch(error => {
                console.log(error);
                return Observable.throw(error);
            });
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

import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Observable } from "rxjs/Observable";
import "rxjs/Rx"

@Injectable()
export class EmploymentContractCalculationService {

    private baseUrl = 'http://localhost:18021/api/ScheduleEmploymentContractCalculation';

    constructor(private http: Http) { }

    scheduleCalculation(salaryBrutto: number) {
        return this.http.get(this.baseUrl + "?salaryBrutto=" + salaryBrutto)
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
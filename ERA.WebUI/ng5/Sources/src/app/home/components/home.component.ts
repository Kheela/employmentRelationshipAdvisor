import { Component, OnInit } from '@angular/core';
import { element } from 'protractor';
import { MouseEvent } from 'ngx-bootstrap/utils/facade/browser';
import { Observable } from "rxjs/Observable";
import "rxjs/Rx"

import { EmploymentContractCalculationService } from '../services/employmentContractCalculation.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  private salaryGross: number;
  private calculationResult = '';
  private isLoading = false;
  private wasCalculateClicked = false;
  private enableEmploymentCalculation = true;
  private enableContractCalculation = false;

  constructor(private service: EmploymentContractCalculationService) { }

  ngOnInit() {
  }

  calculate() {
    this.isLoading = true;

    this.service.scheduleCalculation(this.salaryGross)
      //todo: .filter(data => this.form.valid)
      .subscribe(
        response => {
          console.log(response);
          this.calculationResult = response;
          //JSON.stringify(response)
          this.isLoading = false;
        },
        error => {
          alert('error');
          this.isLoading = false;
        }
      );

    // setTimeout(() => {
    //   this.calculationResult = this.salaryGross.toString();
    //   this.isSpinnerVisible = false;
    // }, 2000);
  }

  onClick() {
    this.wasCalculateClicked = !this.wasCalculateClicked;
  }
}

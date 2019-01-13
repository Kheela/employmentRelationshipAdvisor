import { Component, OnInit } from '@angular/core';
import { element } from 'protractor';
import { MouseEvent } from 'ngx-bootstrap/utils/facade/browser';
import { Observable, of } from "rxjs";
import "rxjs/Rx"

import { EmploymentContractCalculationService, SalaryType } from '../services/employmentContractCalculation.service';

export class EmployeeSalaryCalculationResult {
  public SalaryNett: number
}

export class EmployerPaymentCostCalculationResult {
  public TotalPaymentCost: number
}

export class CalculationResult {
  public EmployeeSalaryCalculationResult: EmployeeSalaryCalculationResult
  public EmployerPaymentCostCalculationResult : EmployerPaymentCostCalculationResult;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  private salaryGross: number;
  private salaryNett: number;
  /* mock: 
  //private calculationResult: CalculationResult;
  *///*
  private calculationResult = '';
  //*/
  private isLoading = false;
  private wasCalculateClicked = false;
  private enableEmploymentCalculation = true;
  private enableContractCalculation = false;

  constructor(private service: EmploymentContractCalculationService) { }

  ngOnInit() {

    // mock
    // this.calculationResult = new CalculationResult();
    // this.calculationResult.EmployeeSalaryCalculationResult = new EmployeeSalaryCalculationResult();
    // this.calculationResult.EmployeeSalaryCalculationResult.SalaryNett = 1000;
    // this.calculationResult.EmployerPaymentCostCalculationResult = new EmployerPaymentCostCalculationResult();
    // this.calculationResult.EmployerPaymentCostCalculationResult.TotalPaymentCost = 100;
  }

  onGrossChange(newValue) {
      this.salaryGross = newValue;
      this.salaryNett = null;
  }

  onNettChange(newValue) {
      this.salaryNett = newValue;
      this.salaryGross = null;
  }

  calculate() {
    this.isLoading = true;

    let salaryType = this.salaryGross 
      ? SalaryType.Gross 
      : SalaryType.Nett;

    let salary = salaryType === SalaryType.Gross 
      ? this.salaryGross
      : this.salaryNett;

    this.service.scheduleCalculation(salary, salaryType)
      //todo: .filter(data => this.form.valid)
      .subscribe( 
        response => {
          console.log(response);
          this.calculationResult = response;
          //JSON.stringify(response)
          this.isLoading = false;
        },        
        error => {
            alert('error: ' + error);
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

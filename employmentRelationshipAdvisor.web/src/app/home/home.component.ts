import { Component, OnInit } from '@angular/core';
import { Http, URLSearchParams } from '@angular/http';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  apiRoot = 'http://httpbin.org';
  salary = '';
  salaryDisplay = '';
  isSpinnerVisible = false;

  constructor(private http: Http) { }

  ngOnInit() {
  }

  showSalary() {
    this.isSpinnerVisible = true;

    setTimeout(() => {
      this.salaryDisplay = this.salary;
      this.isSpinnerVisible = false;
    }, 2000);
  }
}

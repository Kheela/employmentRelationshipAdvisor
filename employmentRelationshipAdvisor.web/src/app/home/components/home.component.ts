import { Component, OnInit } from '@angular/core';
import { Http, URLSearchParams } from '@angular/http';
import { MouseEvent } from 'ngx-bootstrap/utils/facade/browser';
import { element } from 'protractor';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  apiRoot = 'http://httpbin.org';
  salaryNetto = '';
  salaryDisplay = '';
  isSpinnerVisible = false;
  wasCalculateClicked = false;

  constructor(private http: Http) { }

  ngOnInit() {
  }

  calculate() {
    this.isSpinnerVisible = true;

    setTimeout(() => {
      this.salaryDisplay = this.salaryNetto;
      this.isSpinnerVisible = false;
    }, 2000);
  }

  onClick() {
    this.wasCalculateClicked = !this.wasCalculateClicked;
  }
}

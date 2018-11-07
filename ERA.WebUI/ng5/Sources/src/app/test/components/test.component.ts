import { Component, OnInit } from '@angular/core';
import { Http, URLSearchParams } from '@angular/http';

@Component({
  selector: 'test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {
  apiRoot: string = "http://httpbin.org";

  constructor(private http: Http) { }

  ngOnInit() {
  }

  doGET() {
    console.log("GET");
    let url = `${this.apiRoot}/get`;
    
    let search = new URLSearchParams();
    search.set('foo', 'moo');
    search.set('limit', '25');

    this.http
      .get(url, { search })
      .subscribe(res => console.log(res.json()));
  }

  doPOST() {
    console.log("POST");
  }

  doPUT() {
    console.log("PUT");
  }

  doDELETE() {
    console.log("DELETE");
  }

  doGETAsPromise() {
    console.log("GET AS PROMISE");
  }

  doGETAsPromiseError() {
    console.log("GET AS PROMISE ERROR");
  }

  doGETAsObservableError() {
    console.log("GET AS OBSERVABLE ERROR");
  }

  doGETWithHeaders() {
    console.log("GET WITH HEADERS");
  }
}

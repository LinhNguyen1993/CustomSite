import { getBaseUrl } from 'src/main';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  baseUrl : string = getBaseUrl();
  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  getProducts(){    
    this.http.get(this.baseUrl + "api/product/getProducts").subscribe(response => {
      console.log(response);
    }, (error => {
      console.log(error);
    }),
      () => {
        console.log("complete");
      });
  }

}

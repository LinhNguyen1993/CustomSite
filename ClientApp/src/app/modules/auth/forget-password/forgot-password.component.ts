import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject, ErrorHandler } from '@angular/core';
import { Http } from '@angular/http';
import { getBaseUrl } from 'src/main';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {

  email: string;
  baseUrl: string = getBaseUrl();

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  forgotPassword() {
    console.log(this.email);
    this.http.post(this.baseUrl + "api/account/forgotPassword", JSON.stringify(this.email)).subscribe(response => {
      console.log(response);
    }, (error => {
      console.log(error);
    }),
      () => {
        console.log("complete");
      });
  }
}

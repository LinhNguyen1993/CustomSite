import { HttpClient } from '@angular/common/http';
import { Component, OnInit} from '@angular/core';
import { getBaseUrl } from 'src/main';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {

  
  email: string;
  baseUrl: string = getBaseUrl();
  forgotPasswordModel = new ForgotPasswordModel();

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  forgotPassword() {
    console.log(this.email);
    this.forgotPasswordModel.Email = this.email;
    this.http.post(this.baseUrl + "api/account/forgotPassword", JSON.stringify(this.forgotPasswordModel)).subscribe(response => {
      console.log(response);
    }, (error => {
      console.log(error);
    }),
      () => {
        console.log("complete");
      });
  }

  getProducts() {
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

class ForgotPasswordModel {
  Email: string
}
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  goggleBtnText: string = "Login with Goggle";
  facebookBtnText: string = "Login with Facebook";
  otherServicesWidth: number = 219;
  otherServicesHeight: number = 37;

  constructor() { }

  ngOnInit(): void {
  }
}

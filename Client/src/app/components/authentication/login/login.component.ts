import { Component, OnInit } from '@angular/core';
import { DarkModeService } from "../../.././_services/dark-mode.service";
import { AccountService } from "../../.././_services/account.service";
import { LoginRequest } from "../../.././_models/_requests/loginRequest";

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

  bgColor: string = "#2C2F33";
  fgColor: string = "white";

  usernameEmail!: string;
  password!: string;

  result: any;

  constructor(private darkModeService: DarkModeService, private accountService: AccountService) {
    this.darkModeService.onToggle().subscribe((value) => this.onToggle(value));
  }

  ngOnInit(): void {
  }

  onToggle(value: boolean): void {
    this.bgColor = (value) ? "#2C2F33" : "white";
    this.fgColor = (value) ? "white" : "black";
  }

  toggleDarkmode(): void {
    this.darkModeService.toggleDarkMode();
  }

  login(): void {
    this.result = this.accountService.login({ email: this.usernameEmail, password: this.password }).subscribe(
    );
  }
}

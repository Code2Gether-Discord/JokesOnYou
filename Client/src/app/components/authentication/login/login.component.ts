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

  bgColor: string;
  fgColor: string;
  linkColor: string;

  usernameEmail!: string;
  password!: string;

  result: any;

  constructor(private darkModeService: DarkModeService, private accountService: AccountService) {
    this.darkModeService.onToggle().subscribe((value) => this.onToggle());

    this.bgColor = this.darkModeService.bgColor;
    this.fgColor = this.darkModeService.fgColor;
    this.linkColor = this.darkModeService.linkColor;
  }

  ngOnInit(): void {
  }

  onToggle(): void {
    this.bgColor = this.darkModeService.bgColor;
    this.fgColor = this.darkModeService.fgColor;
    this.linkColor = this.darkModeService.linkColor;
  }

  toggleDarkmode(): void {
    this.darkModeService.toggleDarkMode();
  }

  login(): void {
    this.result = this.accountService.login({ email: this.usernameEmail, password: this.password }).subscribe(
    );
  }
}

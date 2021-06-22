import { Component, OnInit } from '@angular/core';
import { UiApearanceService } from "../../.././_services/uiAppearence.service";
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

  constructor(private uiApearanceSerivce: UiApearanceService, private accountService: AccountService) {
    this.uiApearanceSerivce.onToggle().subscribe(() => this.onToggle());

    this.bgColor = this.uiApearanceSerivce.bgColor;
    this.fgColor = this.uiApearanceSerivce.fgColor;
    this.linkColor = this.uiApearanceSerivce.linkColor;
  }

  ngOnInit(): void {
  }

  onToggle(): void {
    this.bgColor = this.uiApearanceSerivce.bgColor;
    this.fgColor = this.uiApearanceSerivce.fgColor;
    this.linkColor = this.uiApearanceSerivce.linkColor;
  }

  toggleDarkmode(): void {
    this.uiApearanceSerivce.toggleDarkMode();
  }

  login(): void {
    this.accountService.login({ email: this.usernameEmail, password: this.password }).subscribe();
  }
}

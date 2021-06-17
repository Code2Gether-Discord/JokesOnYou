import { Component, OnInit } from '@angular/core';
import { DarkModeService } from "../../.././_services/dark-mode.service";

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

  constructor(private darkModeService: DarkModeService) {
    this.darkModeService.onToggle().subscribe((value) => this.onToggle(value));
  }

  ngOnInit(): void {
  }

  onToggle(value: boolean) {
    this.bgColor = (value) ? "#2C2F33" : "white";
    this.fgColor = (value) ? "white" : "black";
  }

  toggleDarkmode() {
    this.darkModeService.toggleDarkMode();
  }
}

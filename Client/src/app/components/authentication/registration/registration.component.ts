import { Component, OnInit } from '@angular/core';
import { DarkModeService } from "../../.././_services/dark-mode.service";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  username!: string;
  dateOfBirth!: string;
  password!: string;
  email!: string;
  retypePassword!: string;

  sliderDarkMode: boolean = false;

  bgColor: string = "#2C2F33";
  fgColor: string = "white";

  constructor(private darkModeService: DarkModeService) {
    this.darkModeService.onToggle().subscribe((value) => this.onToggle(value));
  }

  ngOnInit(): void {
  }

  onToggle(value: boolean) {
    this.sliderDarkMode = value;

    this.bgColor = (value) ? "#2C2F33" : "white";
    this.fgColor = (value) ? "white" : "black";
  }

  toggleDarkmode() {
    console.log(this.username);
    this.darkModeService.toggleDarkMode();
  }
}

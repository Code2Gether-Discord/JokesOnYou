import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  darkMode: boolean = false;
  bgColor: string;
  fgColor: string;

  sliderClass: string;

  constructor() {
    this.bgColor = (this.darkMode) ? "#2C2F33" : "white";
    this.fgColor = (this.darkMode) ? "white" : "black";
    this.sliderClass = (this.darkMode) ? "sliderDark round" : "slider round";
  }

  ngOnInit(): void {
  }

}

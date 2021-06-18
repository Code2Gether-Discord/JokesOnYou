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

  nsfw: boolean = false;

  bgColor: string;
  fgColor: string;
  linkColor: string;

  constructor(private darkModeService: DarkModeService) {
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

  toggleNSFW(): void {
    this.nsfw = !this.nsfw;
  }
}

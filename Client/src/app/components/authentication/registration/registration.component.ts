import { Component, OnInit } from '@angular/core';
import { UiApearanceService } from "../../.././_services/uiAppearence.service";

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

  height: string = "5%";
  width: string = "13.5%";
  radius: string = "3%";

  constructor(private uiApearanceService: UiApearanceService) {
    this.uiApearanceService.onToggle().subscribe(() => this.onToggle());

    this.bgColor = this.uiApearanceService.bgColor;
    this.fgColor = this.uiApearanceService.fgColor;
    this.linkColor = this.uiApearanceService.linkColor;
  }

  ngOnInit(): void {
  }

  onToggle(): void {
    this.bgColor = this.uiApearanceService.bgColor;
    this.fgColor = this.uiApearanceService.fgColor;
    this.linkColor = this.uiApearanceService.linkColor;
  }

  toggleDarkmode(): void {
    this.uiApearanceService.toggleDarkMode();
  }

  toggleNSFW(): void {
    this.nsfw = !this.nsfw;
  }
}

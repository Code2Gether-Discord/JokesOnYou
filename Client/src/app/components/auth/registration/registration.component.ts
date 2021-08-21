import { Component, OnInit } from '@angular/core';
import { RegisterInfo } from '../../../_models/registerInfo';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  model: RegisterInfo = {
    nsfw: false
  }

  constructor() {
  }

  ngOnInit(): void {
  }

  onSubmit(): void {
    alert(`Register and redirect ${this.model.username}\\${this.model.dateOfBirth}` +
      `${this.model.password}\\${this.model.email}` +
      `${this.model.retypePassword}\\${this.model.nsfw}`);
  }
}

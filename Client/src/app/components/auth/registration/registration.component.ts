import { Component, OnInit } from '@angular/core';
import { RegisterInfo } from '../../../_models/registerInfo';
import { AccountService } from 'src/app/_services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  model: RegisterInfo = {
    nsfw: false
  }

  constructor(private account: AccountService, private router: Router) {
  }

  ngOnInit(): void {
    if (this.account.isAuthorised()) {
      this.router.navigate(['profile']);
    }
  }

  onSubmit(): void {
    // We have validated data in html.
    this.account.register({
      nsfwEnabled: this.model.nsfw,
      password: this.model.password!,
      email: this.model.email!,
      birthDate: this.model.dateOfBirth!,
      userName: this.model.username!
    }).subscribe(_ => {
      this.router.navigate(['login']);
    });
  }
}

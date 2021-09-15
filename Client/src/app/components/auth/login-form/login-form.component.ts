import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginInfo } from '../../../_models/loginInfo';
import { AccountService } from '../../../_services/account.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  constructor(
    private authorizeService: AccountService,
    private router: Router) { }

  model: LoginInfo = { username: '', password: '' };
  error: string = '';

  submitted = false;

  onSubmit() {
    this.submitted = true;

    // Validation on empty strings is done in html
    this.authorizeService.login({
      loginName: this.model.username!,
      password: this.model.password!
    }, m => this.error = m
    ).subscribe();
  }

  ngOnInit(): void {
    this.authorizeService.isAuthorised$.subscribe(isAuth => {
      if (isAuth) {
        this.router.navigate(['profile']);
      }
    })
  }
}

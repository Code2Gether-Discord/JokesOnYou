import { Component, Input, OnInit } from '@angular/core';
import { LoginInfo } from 'src/app/_models/loginInfo';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  model: LoginInfo = { username: '', password: '' }

  submitted = false;

  onSubmit() {
    this.submitted = true;
    alert(`Log in and redirect to main page ${this.model.username}\\${this.model.password}`);
  }

  ngOnInit(): void {
  }
}

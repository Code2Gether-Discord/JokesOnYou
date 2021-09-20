import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../../../_models/user';
import { AccountService } from '../../../_services/account.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  user: User = {}
  isAuthorised: boolean = false;

  constructor(private account: AccountService, private router: Router) {
  }

  onLogOut() {
    this.account.logout();
    window.location.reload();
  }

  ngOnInit(): void {
    this.account.isAuthorised$.subscribe(isAuth => {
      if (!isAuth) {
        this.router.navigate(['login']);
      }
    })

    this.account.currentUser$.subscribe(u => this.user = u);
  }
}

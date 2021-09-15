import { Component } from '@angular/core';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {

  constructor(private account: AccountService) { }

  isAuthorised: boolean = false

  ngOnInit(): void {
    this.account.isAuthorised$.subscribe(v => this.isAuthorised = v);
  }
}

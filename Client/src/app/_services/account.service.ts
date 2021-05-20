import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private accountUrl = environment.apiUrl + 'account';
  private currentUser = new ReplaySubject<User>(1);
  currentUser$ = this.currentUser.asObservable();

  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post(`${this.accountUrl}login`, model).pipe(
      map((user: User) => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.setCurrentUser(user);
        }
      }));
  }

  setCurrentUser(user: User) {
    this.currentUser.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUser.next(undefined);
  }
}

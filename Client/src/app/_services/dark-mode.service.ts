import { Injectable } from '@angular/core';
import { Observable, Subject } from "rxjs"

@Injectable({
  providedIn: 'root'
})
export class DarkModeService {
  private darkMode: boolean = true;
  private subject = new Subject<any>();

  constructor() { }

  toggleDarkMode(): void {
    this.darkMode = !this.darkMode;
    this.subject.next(this.darkMode);
  }

  onToggle(): Observable<any> {
    return this.subject.asObservable();
  }
}

import { Injectable } from '@angular/core';
import { Observable, Subject } from "rxjs"

@Injectable({
  providedIn: 'root'
})
export class UiApearanceService {
  private darkMode: boolean = true;
  private subject = new Subject<boolean>();

  public fgColor: string = "white";
  public bgColor: string = "#2C2F33";
  public linkColor: string = "#00C2FF";

  constructor() { }

  toggleDarkMode(): void {
    this.darkMode = !this.darkMode;
    this.fgColor = (this.darkMode) ? "white" : "black";
    this.bgColor = (this.darkMode) ? "#2C2F33" : "white";
    this.linkColor = (this.darkMode) ? "#00C2FF" : "blue";

    this.subject.next(this.darkMode);
  }

  onToggle(): Observable<any> {
    return this.subject.asObservable();
  }
}

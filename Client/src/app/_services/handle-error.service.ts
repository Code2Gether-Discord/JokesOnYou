import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class HandleErrorService {
  constructor(private toastr: ToastrService) {}

  public handleError(err: HttpErrorResponse) {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      // Other errors go here
      errorMessage = `An error occurred ${err.error.message}`;
    }
    else {
      // Backend error goes here
      errorMessage = `${err.error.message ?? err.error}`
    }
    this.toastr.error(errorMessage);
  }
}

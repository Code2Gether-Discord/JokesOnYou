import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ToastrModule } from 'ngx-toastr';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from '../app/app.component';
import { AppRoutingModule } from './app-routing.module';
import { NavbarComponent } from './components/navbar/navbar.component';
import { JokeCardComponent } from './components/jokes/joke-card/joke-card.component';
import { JokeDetailComponent } from './components/jokes/joke-detail/joke-detail.component';
import { JokeListComponent } from './components/jokes/joke-list/joke-list.component';
import { LoginFormComponent } from './components/auth/login-form/login-form.component';
import { FormsModule } from '@angular/forms';
import { RegistrationComponent } from './components/auth/registration/registration.component';
import { AccountService } from './_services/account.service';
import { AuthInterceptor } from './_services/auth-interceptor';
import { JokesService } from './_services/jokes.service';
import { ProfileComponent } from './components/auth/profile/profile.component';
import { HandleErrorsInterceptor } from './_services/handle-errors-interceptor';
import { HandleErrorService } from './_services/handle-error.service';

@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
  ],
  declarations: [
    AppComponent,
    NavbarComponent,
    JokeListComponent,
    JokeCardComponent,
    JokeDetailComponent,
    LoginFormComponent,
    RegistrationComponent,
    ProfileComponent
  ],
  providers: [
    AccountService,
    JokesService,
    HandleErrorService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HandleErrorsInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

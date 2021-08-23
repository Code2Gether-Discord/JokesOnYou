import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from '../app/app.component';
import { AppRoutingModule } from './app-routing.module';
import { NavbarComponent } from './components/navbar/navbar.component';
import { JokeCardComponent } from './components/jokes/joke-card/joke-card.component';
import { JokeDetailComponent } from './components/jokes/joke-detail/joke-detail.component';
import { JokeListComponent } from './components/jokes/joke-list/joke-list.component';
import { LoginFormComponent } from './components/auth/login-form/login-form.component';
import { FormsModule } from '@angular/forms';
import { RegistrationComponent } from './components/auth/registration/registration.component';

@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,
    FormsModule
  ],
  declarations: [
    AppComponent,
    NavbarComponent,
    JokeListComponent,
    JokeCardComponent,
    JokeDetailComponent,
    LoginFormComponent,
    RegistrationComponent,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

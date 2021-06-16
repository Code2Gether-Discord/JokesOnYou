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
import { LoginComponent } from './components/authentication/login/login.component';
import { ButtonComponent } from './components/authentication/button/button.component';
import { InputComponent } from './components/authentication/input/input.component';
import { RegistrationComponent } from './components/authentication/registration/registration.component';

@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  declarations: [
    AppComponent,
    NavbarComponent,
    JokeListComponent,
    JokeCardComponent,
    JokeDetailComponent,
    LoginComponent,
    ButtonComponent,
    InputComponent,
    RegistrationComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

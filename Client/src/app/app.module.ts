import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from '../app/app.component';
import { JokeDetailComponent } from '../components/jokes/joke-detail/joke-detail.component';
import { NavbarComponent } from '../components/navbar/navbar.component';
import { AppRoutingModule } from './app-routing.module';
import { JokeCardComponent } from 'src/components/jokes/joke-card/joke-card.component';
import { JokeListComponent } from 'src/components/jokes/joke-list/joke-list.component';

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
    JokeDetailComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

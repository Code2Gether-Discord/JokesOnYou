import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from '../app/app.component';
import { JokesComponent } from '../components/jokes/jokes.component';
import { JokeComponent } from '../components/joke/joke.component';
import { NavbarComponent } from '../components/navbar/navbar.component';

@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: JokesComponent },
      { path: 'joke/:id', component: JokeComponent }
    ])
  ],
  declarations: [
    AppComponent,
    NavbarComponent,
    JokesComponent,
    JokeComponent,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

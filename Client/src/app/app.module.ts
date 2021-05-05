import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { JokesComponent } from '../jokes/jokes.component';
import { AppComponent } from '../app/app.component'
import { JokeComponent } from '../joke/joke.component';

@NgModule({
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: JokesComponent },
      { path: 'joke/:id', component: JokeComponent }
    ])
  ],
  declarations: [
    JokesComponent,
    AppComponent,
    JokeComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

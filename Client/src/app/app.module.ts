import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { JokesComponent } from '../jokes/jokes.component';

@NgModule({
  declarations: [
    JokesComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: JokesComponent },
    ])
  ],
  providers: [],
  bootstrap: [JokesComponent]
})
export class AppModule { }

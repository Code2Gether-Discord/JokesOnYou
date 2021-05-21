import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JokeDetailComponent } from './components/jokes/joke-detail/joke-detail.component';
import { JokeListComponent } from './components/jokes/joke-list/joke-list.component';

const routes: Routes = [
  { path: '', component: JokeListComponent },
  { path: 'joke/:id', component: JokeDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
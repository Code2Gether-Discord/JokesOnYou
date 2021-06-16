import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/authentication/login/login.component';
import { RegistrationComponent } from './components/authentication/registration/registration.component';
import { JokeDetailComponent } from './components/jokes/joke-detail/joke-detail.component';
import { JokeListComponent } from './components/jokes/joke-list/joke-list.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent },
  { path: 'joke/:id', component: JokeDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

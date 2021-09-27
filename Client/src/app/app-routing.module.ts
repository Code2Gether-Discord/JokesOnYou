import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JokeDetailComponent } from './components/jokes/joke-detail/joke-detail.component';
import { JokeListComponent } from './components/jokes/joke-list/joke-list.component';
import { LoginFormComponent } from './components/auth/login-form/login-form.component';
import { RegistrationComponent } from './components/auth/registration/registration.component';
import { ProfileComponent } from './components/auth/profile/profile.component';

const routes: Routes = [
  { path: '', component: JokeListComponent },
  { path: 'login', component: LoginFormComponent },
  { path: 'register', component: RegistrationComponent },
  { path: 'jokes', component: JokeListComponent },
  { path: 'joke/:id', component: JokeDetailComponent },
  { path: 'profile', component: ProfileComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { Component } from '@angular/core';

import { jokes } from './testJokes';

@Component({
  selector: 'app-jokes-component',
  templateUrl: './jokes.component.html'
})
export class JokesComponent {
  jokes = jokes;
}

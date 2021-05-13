import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, observable } from 'rxjs';
import { Joke } from '../../app/joke';

@Component({
  selector: 'app-jokes-component',
  templateUrl: './jokes.component.html'
})
export class JokesComponent implements OnInit{
  jokes?: Joke[];
  private jokesUrl = 'http://localhost:5000/api/jokes';

  constructor(
    private http: HttpClient
  ) { }

  getJokes(): void {
    this.http.get<Joke[]>(this.jokesUrl).subscribe(jokes => this.jokes = jokes);
  }

  ngOnInit() { this.getJokes() }

  /*
  getHeroes(): void {
    this.heroService.getHeroes()
      .subscribe(heroes => this.heroes = heroes);
  }
  */
}

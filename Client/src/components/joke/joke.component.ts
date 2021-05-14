import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Joke } from '../../app/joke';

@Component({
  selector: '',
  templateUrl: './joke.component.html'
})

export class JokeComponent implements OnInit {
  joke?: Joke;
  jokeId?: number;
  private jokesUrl = 'http://localhost:5000/api/jokes/';

  constructor(
    private http: HttpClient,
    private route: ActivatedRoute
  ) { }

  getJoke() {
    return this.http.get<Joke>(this.jokesUrl+this.jokeId).subscribe(joke => this.joke = joke);
  }

  ngOnInit() {
    const routeParams = this.route.snapshot.paramMap;
    this.jokeId = Number(routeParams.get('id'));

    this.getJoke();
  }
}

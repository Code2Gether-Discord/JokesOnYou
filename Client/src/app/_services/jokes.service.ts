import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Joke } from '../_models/joke';

@Injectable({
  providedIn: 'root'
})
export class JokesService {
  private jokesUrl = 'http://localhost:5000/api/jokes/';

  constructor(private http: HttpClient) { }

  getJoke(id: number) {
    return this.http.get<Joke>(this.jokesUrl + id);
  }

  getJokes() {
    return this.http.get<Joke[]>(this.jokesUrl);
  }
}

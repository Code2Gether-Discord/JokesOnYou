import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Joke } from '../../../_models/joke';
import { environment } from 'src/environments/environment';
import { JokesService } from 'src/app/_services/jokes.service';


@Component({
  selector: 'app-joke-list-component',
  templateUrl: './joke-list.component.html'
})
export class JokeListComponent implements OnInit {
  jokes: Joke[] = [];

  constructor(private http: HttpClient, private jokesService: JokesService) { }

  getJokes(): void {
    this.jokesService.getJokes().subscribe(jokes => {
      this.jokes = jokes;
      console.log(this.jokes);
    });
  }

  ngOnInit() {
    this.getJokes();
  }

}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Joke } from '../../../_models/joke';
import { JokesService } from 'src/app/_services/jokes.service';

@Component({
  selector: '',
  templateUrl: './joke-detail.component.html'
})

export class JokeDetailComponent implements OnInit {
  joke?: Joke;
  jokeId = 0;

  constructor(private route: ActivatedRoute, private jokesService: JokesService) { }

  getJoke() {
    this.jokesService.getJoke(this.jokeId).subscribe(joke => this.joke = joke)
  }

  ngOnInit() {
    const routeParams = this.route.snapshot.paramMap;
    this.jokeId = Number(routeParams.get('id'));

    this.getJoke();
  }
}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: '',
  templateUrl: './joke.component.html'
})

export class JokeComponent implements OnInit {
  joke = {id: 0, premise: "insidePremise", punchline:'insidePunchline'};

  constructor(
    private http: HttpClient
  ) { }

  getJoke() {
    return this.http.get<{ type: string, price: number }[]>('/api/jokes/0');
  }

  ngOnInit() {}
}

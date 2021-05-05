import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: '',
  templateUrl: './joke.component.html'
})

export class JokeComponent implements OnInit {
  joke = {id: 0, premise: "insidePremise", punchline:'insidePunchline'};

  constructor() { }

  ngOnInit() {}
}

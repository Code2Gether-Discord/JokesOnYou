import { Component, Input, OnInit } from '@angular/core';
import { Joke } from 'src/app/_models/joke';

@Component({
  selector: 'app-joke-card',
  templateUrl: './joke-card.component.html',
  styleUrls: ['./joke-card.component.css']
})
export class JokeCardComponent implements OnInit {
  @Input() joke?: Joke;

  constructor() { }

  ngOnInit(): void {
  }

}

import { Component, Input, OnInit } from '@angular/core';
import { Joke } from 'src/app/_models/joke';
import { jokes } from 'src/app/_services/testJokes';
@Component({
  selector: 'app-joke-card',
  templateUrl: './joke-card.component.html',
  styleUrls: ['./joke-card.component.css']
})
export class JokeCardComponent implements OnInit {
  joke: Joke = {
    id: 1,
    authorId: "1",
    dislikes: 10,
    likes: 10,
    premise: " I’ve created a writing software to rival Microsoft.",
    punchline: " It’s their Word against mine.",
    uploadDate: "12/02/2002"
  };

  spoiler: string = "spoilerShow content";
  punchlineVisibility: string = "hidden";

  constructor() {
  }

  ngOnInit(): void {
  }

  revealSpoiler(): void {
    this.punchlineVisibility = "visible";
    this.spoiler = "spoilerHidden content";
  }
}

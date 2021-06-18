import { Component, Input, OnInit, ViewChild, ElementRef } from '@angular/core';
import { fakeAsync } from '@angular/core/testing';
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
    uploadDate: "12/02/2002",
    tags: [
      "Programmer", "Top 100", "NSFW", "IDE", "Microsoft"
    ]
  };

  tags: string[] = this.joke.tags;

  spoiler: string = "spoilerShow content";
  punchlineVisibility: string = "hidden";

  private tagsSum: number = 0;
  private currentIndex: number = 0;

  constructor() {
    this.checkTag();
  }

  ngOnInit(): void {
  }


  revealSpoiler(): void {
    this.punchlineVisibility = "visible";
    this.spoiler = "spoilerHidden content";
  }

  checkTag(): void {
    for (var i = 0; i < this.joke.tags.length; i++) {
      this.currentIndex = i;

      if (this.joke.tags[this.currentIndex].length > 8) {
        this.tagsSum += this.joke.tags[this.currentIndex].length * (6) + 2 * 4 + 4;
      }
      else {
        this.tagsSum += this.joke.tags[this.currentIndex].length * (8) + 2 * 4 + 4;
      }

      if (this.tagsSum > 245) {
        break;
      }
    }

    this.tags[this.currentIndex] = "..." 

      this.tags.splice(this.currentIndex + 1, this.joke.tags.length - this.currentIndex);
  }
}

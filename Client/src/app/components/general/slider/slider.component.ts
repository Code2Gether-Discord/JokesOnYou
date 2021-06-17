import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { DarkModeService } from "../../.././_services/dark-mode.service";

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.css']
})
export class SliderComponent implements OnInit {
  sliderClass: string = "sliderDark round";

  @Output() onChange: EventEmitter<void> = new EventEmitter();

  constructor(private darkModeService: DarkModeService) {
    this.darkModeService.onToggle().subscribe((value) => this.onToggle(value));
  }

  ngOnInit(): void {
  }

  onToggle(value: boolean) {
    this.sliderClass = (value) ? "sliderDark round" : "slider round";
  }

  onSliderChange(): void {
    this.onChange.emit();
  }
}

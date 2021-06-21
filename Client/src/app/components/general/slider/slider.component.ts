import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { UiApearanceService } from "../../.././_services/uiAppearence.service";

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.css']
})
export class SliderComponent implements OnInit {

  @Input() sliderWidth: string = "60px";
  @Input() sliderHeight: string = "25px";
  @Input() label: string | undefined;
  @Input() circleRadius: string = "16px";

  sliderClass: string = "sliderDark round";
  circleClass: string = "circleDark round";

  @Output() onChange: EventEmitter<void> = new EventEmitter();

  constructor(private uiApearanceService: UiApearanceService) {
    this.uiApearanceService.onToggle().subscribe((value) => this.onToggle(value));
  }

  ngOnInit(): void {
  }

  onToggle(value: boolean) {
    this.sliderClass = (value) ? "sliderDark round" : "sliderLight round";
    this.circleClass = (value) ? "circleDark" : "circleLight";
  }

  onSliderChange(): void {
    this.onChange.emit();
  }
}

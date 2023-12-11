import {Component, Input, OnInit} from '@angular/core';

import { Lesson } from '../interfaces/lesson';


@Component({
  selector: 'app-schedule-item',
  templateUrl: './schedule-item.component.html',
  styleUrls: ['./schedule-item.component.scss'],

})
export class ScheduleItemComponent  {

  @Input() scheduleForDay: Array<Lesson>=[];
  @Input() dayOfWeek ="Monday";


}

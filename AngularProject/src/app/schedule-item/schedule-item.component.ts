import {Component, Input, OnInit} from '@angular/core';

import { Lesson } from '../interfaces/lesson';


@Component({
  selector: 'app-schedule-item',
  templateUrl: './schedule-item.component.html',
  styleUrls: ['./schedule-item.component.scss'],

})
export class ScheduleItemComponent implements OnInit  {

  @Input() scheduleForDay: Array<Lesson>=[];
  @Input() dayOfWeek ="Monday";
  @Input() dayOfWeekIndex =0;
  @Input() groupId=1;

   defaultLesson:Lesson={
    day:this.dayOfWeekIndex,
   groupId:this.groupId,
   numberInOrder:0,
   classroom:"",
   subjectName:"" ,
   teacherName: ""
   }

  ngOnInit(): void {
    
  }
}

import {Component} from '@angular/core';
import {MatTableModule} from '@angular/material/table';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = Array(8).fill({
  position: '',
  name: '1232434324444444444444444444',
  symbol: '23'
});

/**
 * @title Styling columns using their auto-generated column names
 */

@Component({
  selector: 'app-schedule-item',
  templateUrl: './schedule-item.component.html',
  styleUrls: ['./schedule-item.component.scss'],

})
export class ScheduleItemComponent {
  currentSubjectTeacher="select ";
  toggle=false;

  edit(){
    this.toggle=true;
  }

  subjectTeachers:Array<any>=[{name:"sdf"}]
  handleSubjectTeacher(value:any){}
  displayedColumns: string[] = ['number', 'subjectAndTeacher', 'classroom','edit'];
  dataSource = ELEMENT_DATA;
}

import { Component } from '@angular/core';

@Component({
  selector: 'app-lesson',
  templateUrl: './lesson.component.html',
  styleUrls: ['./lesson.component.scss']
})
export class LessonComponent {
  currentSubjectTeacher="select ";
  toggle=false;

  edit(){
    this.toggle=true;
  }

  subjectTeachers:Array<any>=[{name:"sdf"}]
  handleSubjectTeacher(value:any){}
}

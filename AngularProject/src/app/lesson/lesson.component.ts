import { Component, Input, OnInit } from '@angular/core';
import { Lesson } from '../interfaces/lesson';
import { ScheduleService } from '../services/ScheduleService';
import { SubjectTeacherService } from '../services/SubjectTeacherService';
import { SubjectTeacher } from '../interfaces/subjectTeacher';
import { MatSelectChange } from '@angular/material/select';

@Component({
  selector: 'app-lesson',
  templateUrl: './lesson.component.html',
  styleUrls: ['./lesson.component.scss']
})
export class LessonComponent implements OnInit {
  constructor(private scheduleService: ScheduleService,private subjectTeacherService:SubjectTeacherService) {}
  @Input() lesson: Lesson = {day:0,groupId:0, numberInOrder:0,classroom:"",subjectName:"",teacherName:""};
  toggle = false;
  subjectTeacherID: number | undefined = undefined;
  edit() {
    this.toggle = true;
  }
  currentItem = "Select subject and teacher";
  classroom: string=" ";
  subjectTeachers:Array<SubjectTeacher>=[];
  subjectTeacher:SubjectTeacher|undefined=undefined;
  ngOnInit(): void {
    this.subjectTeacherService.getSubjectTeachers().subscribe({
      next: (response: any) => {
        this.subjectTeachers=response;
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
    });
  }

  onSelectionChange(event: MatSelectChange){
    this.subjectTeacherID=event.value.id;
    this.subjectTeacher = event.value;
  }

  confirm() {
    if (this.subjectTeacherID !== undefined && this.classroom !== undefined,
      this.subjectTeacherID!==undefined
      ) {
      this.scheduleService.addLesson(
        this.lesson.numberInOrder,
        this.subjectTeacherID,
        this.classroom,
        this.lesson.groupId,
        this.lesson.day
      ).subscribe({
        next: () => {
          this.lesson.classroom = this.classroom;
          this.lesson.subjectName = this.subjectTeacher?.subjectName;
          this.lesson.teacherName = this.subjectTeacher?.teacherName;
          console.log("success");
        },
        error: (error) => {    
          console.log(error);
        },
      });
      this.toggle = false; // Перенесено внутрь блока кода
    }
  }

  cancel() {
    this.toggle = false;
  }
}

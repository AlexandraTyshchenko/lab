import { Component, OnInit} from '@angular/core';
import { Teacher } from '../interfaces/teacher';
import { TeacherService } from '../services/TeacherService';
@Component({

  selector: 'app-teachers',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.scss'],

})
export class TeachersComponent implements OnInit {
  teachers : Array<Teacher>=[];
  displayedColumns: string[] = ['teacher','shortinfo', 'subjects'];
  constructor(private teacherService : TeacherService){}

  ngOnInit() {
   this.teacherService.getTeachers().subscribe({
      next: (response: Teacher[]) => {
        this.teachers = response;
        console.log(this.teachers);
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
    });
  }
}

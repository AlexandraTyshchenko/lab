import { Component, OnInit } from '@angular/core';
import { SubjectService } from '../services/SubjectService';
import { Subject } from '../interfaces/subject';

@Component({
  selector: 'app-subjects',
  templateUrl: './subjects.component.html',
  styleUrls: ['./subjects.component.scss']
})
export class SubjectsComponent implements OnInit{
  constructor(private subjectsService:SubjectService){

  }

  addStudent(){
    console.log("hello");
  }

  displayedColumns: string[] = ['subject','description'];
  subjects:Array<Subject>=[];
  ngOnInit(){
    this.subjectsService.getSubjects().subscribe({
      next: (response: Subject[]) => {
        this.subjects = response;
        console.log(this.subjects);
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
    });
  }
}

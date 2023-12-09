import { DialogRef } from '@angular/cdk/dialog';
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SubjectTeacherService } from '../services/SubjectTeacherService';
import { Subject } from '../interfaces/subject';
import { TeacherSubjects } from '../interfaces/teacherSubjects';


@Component({
  selector: 'app-remove-subject',
  templateUrl: './remove-subject.component.html',
  styleUrls: ['./remove-subject.component.scss']
})
export class RemoveSubjectComponent implements OnInit {
  teacherId:number|undefined = undefined;
  subjects:Array<Subject> = [];
  subjectId:number|undefined = undefined
  currentSubject = "select subject"
  constructor( private dialogRef: DialogRef, 
   private  subjectTeacherService:SubjectTeacherService,
    @Inject(MAT_DIALOG_DATA) private data: any){
        this.teacherId = data.teacherId;
        console.log(this.teacherId);
    }

    closeForm() {
      this.dialogRef.close();
    }
    handleSubject(subject:Subject){
        this.subjectId = subject.id;
    }

  ngOnInit(): void {
    if(this.teacherId!==undefined){
      this. subjectTeacherService.getTeacherWithSubjects(this.teacherId).subscribe({
        next: (response: TeacherSubjects) => {
          this.subjects = response.subjects;
        },
        error: (error) => {
          console.error('Error fetching data:', error);
        }
      });
    }
    
  }

  onSubmit(){
      
  }
}

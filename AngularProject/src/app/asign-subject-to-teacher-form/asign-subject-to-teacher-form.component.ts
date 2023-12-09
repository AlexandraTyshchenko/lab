import { DialogRef } from '@angular/cdk/dialog';
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Subject } from '../interfaces/subject';
import { SubjectService } from '../services/SubjectService';
import { SubjectTeacherService } from '../services/SubjectTeacherService';

@Component({
  selector: 'app-asign-subject-to-teacher-form',
  templateUrl: './asign-subject-to-teacher-form.component.html',
  styleUrls: ['./asign-subject-to-teacher-form.component.scss']
})
export class AsignSubjectToTeacherFormComponent implements OnInit {
    teacherId:number|undefined = undefined;
    subjectId:number|undefined = undefined;
    subjects:Array<Subject> = [];
    currentSubject = "select subject";
    constructor( private dialogRef: DialogRef,
      private subjectsService:SubjectService,
      private subjectTeacher:SubjectTeacherService,
      @Inject(MAT_DIALOG_DATA) private data: any,){
        this.teacherId = data.teacherId;
        console.log(this.teacherId);
      }
      
      ngOnInit(){
        this.subjectsService.getSubjects().subscribe({
          next: (response: Subject[]) => {
            this.subjects = response;
          },
          error: (error) => {
            console.error('Error fetching data:', error);
          }
        });
      }

      closeForm(){
        this.dialogRef.close();
      }

      onSubmit(){
        if(this.subjectId !== undefined && this.teacherId!==undefined){
            this.subjectTeacher.AsignSubject(this.teacherId ,this.subjectId).subscribe({
              next: () => {
                console.log("sucesss");
                this.data.onConfirmation(); 
                this.dialogRef.close();
            
              },
              error: (error) => {
                console.log(error);
              }
            });
        }
      }

      handleSubject(subject:Subject){
          this.subjectId = subject.id;
      }  

}

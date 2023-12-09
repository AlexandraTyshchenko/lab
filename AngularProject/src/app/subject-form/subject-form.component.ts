import { DialogRef } from '@angular/cdk/dialog';
import { Component, Inject } from '@angular/core';
import { SubjectService } from '../services/SubjectService';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-subject-form',
  templateUrl: './subject-form.component.html',
  styleUrls: ['./subject-form.component.scss']
})
export class SubjectFormComponent {
  constructor( private dialogRef: DialogRef, private subjectService:SubjectService,
    @Inject(MAT_DIALOG_DATA) private data: any){}
  subjectName:string|undefined=undefined;
  description = "";
  errorMessage = ""
  onSubmit(){
    if(this.subjectName != undefined){
      this.subjectService.addSubject(this.subjectName,this.description).subscribe({
        next: () => {
          console.log("sucesss");
          this.data.onConfirmation(); 
          this.dialogRef.close();
      
        },
        error: (error) => {
          this.errorMessage=error.error.Details;
        }
      });
    }
    else{
      this.errorMessage = "name of the subject is required";
    } 
  }

  closeForm() {
    this.dialogRef.close();
  }

}

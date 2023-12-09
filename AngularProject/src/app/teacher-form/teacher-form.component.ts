import { DialogRef } from '@angular/cdk/dialog';
import { Component, Inject } from '@angular/core';
import { TeacherService } from '../services/TeacherService';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-teacher-form',
  templateUrl: './teacher-form.component.html',
  styleUrls: ['./teacher-form.component.scss']
})
export class TeacherFormComponent {
    name:string | undefined = undefined;
    shortInfo:string | undefined = undefined;
    errorMessage="";
    constructor(private dialogRef: DialogRef, private teacherService:TeacherService,
      @Inject(MAT_DIALOG_DATA) private data: any){}
      onSubmit(){
        if(this.name!= undefined && this.shortInfo!=undefined){
          this.teacherService.addTeacher(this.name,this.shortInfo).subscribe({
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
          this.errorMessage = "all fields required";
        } 
      }
    
      closeForm() {
        this.dialogRef.close();
      }
    
    
}

import { DialogRef } from '@angular/cdk/dialog';
import { Component, OnInit } from '@angular/core';
import { MatSelectChange } from '@angular/material/select';
import { TeacherService } from '../services/TeacherService';
import { Teacher } from '../interfaces/teacher';
import { GroupService } from '../services/GroupService';

@Component({
  selector: 'app-group-form',
  templateUrl: './group-form.component.html',
  styleUrls: ['./group-form.component.scss']
})
export class GroupFormComponent implements OnInit{

  
  ngOnInit() {
    this.teacherService.getTeachers().subscribe({
      next: (response: Teacher[]) => {
        this.teachers = response;
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
    });
  }
  
  errorMessage = "";
  currentTeacher = "select teacher" 
  currentCourse:string="select year of studying";
  courseNumber:undefined|number;
  courses=[1,2,3,4];
  teachers : Array<Teacher>=[];
  currentTeacherName:undefined|string=undefined;
  groupName:undefined|string = undefined;
  constructor(  private dialogRef: DialogRef,private teacherService : TeacherService,private groupService:GroupService){
    
  }
  onSelectionChange(event: MatSelectChange):void{
      this.courseNumber=event.value;
  }
  onSubmit(){
      if(this.currentTeacherName == undefined || this.groupName == undefined || this.courseNumber==undefined){
        this.errorMessage = "Not all fields are filled in";
      }
      else{
        this.errorMessage=" ";
        this.groupService.addGroup(this.groupName,this.courseNumber,this.currentTeacherName).subscribe({
          next: () => {
            console.log("sucesss");
            this.dialogRef.close();
          },
          error: (error) => {
            this.errorMessage=error.error.Details;
          }
        });
      }

  }



  handleTeacher(teacher: Teacher){
      this.currentTeacherName = teacher.name;
  }

  closeForm(){
    this.dialogRef.close();
  }
}

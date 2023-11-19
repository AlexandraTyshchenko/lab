import { Component } from '@angular/core';
import { GroupService } from '../services/GroupService';
import { Group } from '../classes/group';
import { DialogRef } from '@angular/cdk/dialog';
import { StudentService } from '../services/StudentService';

@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.scss'],

})
export class StudentFormComponent {
 
  groups:Group[]=[];
  currentGroup="select group";
  groupId=-1;
  firstName="";  
  lastName= "";
  email = "";
  done: boolean = false;
  handleGroup(selectedGroup:Group){
      this.groupId=selectedGroup.id;
  }
  closeForm() {
    this.dialogRef.close();
  }
  onSubmit(){
      if(this.groupId!=-1){
         this.studentService.addStudent(this.firstName,this.lastName, this.groupId, this.email).subscribe({
          next:() => { this.done=true;console.log(this.done);this.closeForm()},
          error: error => console.log(error)
      });
      }     
  }
  constructor(private groupService:GroupService,
    private dialogRef:DialogRef,
    private studentService:StudentService
    ) {  }
  ngOnInit() {
    this.groupService.GetGroups().subscribe({
      next: (response: any) => {
       this.groups=response;
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
    });
  }
}

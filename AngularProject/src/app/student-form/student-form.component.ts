import { Component } from '@angular/core';
import { GroupService } from '../services/GroupService';
import { Group } from '../classes/group';
import { DialogRef } from '@angular/cdk/dialog';
@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.scss']
})
export class StudentFormComponent {
 
  groups:Group[]=[];
  currentGroup="select group";
  groupId=-1;
  handleGroup(selectedGroup:Group){
      this.groupId=selectedGroup.id;
  }
  closeForm() {
    this.dialogRef.close();
  }
  onSubmit(){
      
  }
  constructor(private groupService:GroupService,
    private dialogRef:DialogRef
    ) {  }
  ngOnInit() {
    this.groupService.GetGroups().subscribe({
      next: (response: any) => {
       this.groups=response;
       console.log(this.groups);
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
    });
  }
}

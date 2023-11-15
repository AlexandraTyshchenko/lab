import { Component } from '@angular/core';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss']
})
export class StudentsComponent {
  groups = [
    { id: 1, name: "102" },
    { id: 2, name: "103" },
  ];
  currentGroup:string = "select group";
  
}

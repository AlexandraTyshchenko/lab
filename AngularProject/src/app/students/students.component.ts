import { Component, OnInit } from '@angular/core';
import { Student } from '../classes/student';
import { StudentService } from '../services/StudentService';
import { GroupService } from '../services/GroupService';
import { StudentFormComponent } from '../student-form/student-form.component';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Group } from '../classes/group';
@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss'],
})
export class StudentsComponent implements OnInit {

  groups: Group[] = [];
  currentGroup: string = "select group";
  length=0;//input for pagination component
  students:Student[]=[];
  selectedItemId=0;

  constructor(
    private studentService: StudentService,
    private groupService:GroupService,
    public dialog:MatDialog
    ) {}

  handleGroup(selectedItem: Group): void {
    this.selectedItemId=selectedItem.id;
    this.loadStudents(1);
  }

  private loadStudents(page: number): void {
    this.studentService.getStudents(this.selectedItemId, page, 10).subscribe({
      next: (response: any) => {
        this.length = response.studentsCount;
        this.students = response.students;
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
    });
  }

  handlePageNumber(pageChange:number): void {
    this.loadStudents(pageChange);
  }
  
  createForm(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "60%";
    this.dialog.open(StudentFormComponent,dialogConfig);
  }

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

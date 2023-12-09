import { Component, OnInit } from '@angular/core';
import { Student } from '../interfaces/student';
import { StudentService } from '../services/StudentService';
import { GroupService } from '../services/GroupService';
import { StudentFormComponent } from '../student-form/student-form.component';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Group } from '../interfaces/group';
import { GroupFormComponent } from '../group-form/group-form.component';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss'],

})

export class StudentsComponent implements OnInit {
  displayedColumns: string[] = ['lastname', 'firstname', 'email','id'];
  groups: Group[] = [];
  currentGroup: string = "select group";
  length=0;//input for pagination component
  students:Student[]=[];
  selectedGroupId=-1;
  curator="";
  page=0;
  constructor(
    private studentService: StudentService,
    private groupService:GroupService,
    public dialog:MatDialog
    ) {}
  handleGroup(selectedItem: Group): void {
    this.selectedGroupId=selectedItem.id;
    this.curator = selectedItem.curator;
    this.loadStudents(1);
  }

  deleteStudent(id: number) {
    if(confirm("Are you sure to delete ")) {
      this.studentService.deleteStudent(id).subscribe(() => {
        console.log("success");
        this.loadStudents(1);
      });
    }
   
  }
  
  private loadStudents(page: number): void {
    this.studentService.getStudents(this.selectedGroupId, page, 10).subscribe({
      next: (response: any) => {
        this.length = response.studentsCount;
        this.students = response.students;
        this.page=page;
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
    });
  }

  handlePageNumber(pageChange:number): void {
    this.loadStudents(pageChange);
  }
  createGroupForm(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "60%";
    dialogConfig.data = {
      groupId:this.selectedGroupId,
      onConfirmation: () => {
        this.loadStudents(this.page);
     }
    };
   
    this.dialog.open(GroupFormComponent,dialogConfig);
  }
  createForm(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "60%";
    dialogConfig.data = {
      groupId:this.selectedGroupId,
      onConfirmation: () => {
        this.loadStudents(this.page);
     }
    };
   
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

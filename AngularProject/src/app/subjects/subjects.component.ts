import { Component, OnInit } from '@angular/core';
import { SubjectService } from '../services/SubjectService';
import { Subject } from '../interfaces/subject';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { SubjectFormComponent } from '../subject-form/subject-form.component';

@Component({
  selector: 'app-subjects',
  templateUrl: './subjects.component.html',
  styleUrls: ['./subjects.component.scss']
})
export class SubjectsComponent implements OnInit{
  constructor(private subjectsService:SubjectService, public dialog:MatDialog){

  }

  addSubject(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "60%";
    dialogConfig.data = {
      onConfirmation: () => {
        this.getSubjects();
     }
    };
    this.dialog.open(SubjectFormComponent,dialogConfig);
  }

  displayedColumns: string[] = ['subject','description','id'];
  subjects:Array<Subject>=[];

  deleteSubject(id:number){
    if(confirm("Are you sure to delete ")) {
      this.subjectsService.deleteSubject(id).subscribe(() => {
        console.log("success");
        this.getSubjects();
      });
    }
  }

  getSubjects(){
    this.subjectsService.getSubjects().subscribe({
      next: (response: Subject[]) => {
        this.subjects = response;
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
    });
  }

  ngOnInit(){
    this.getSubjects();
  
  }
}

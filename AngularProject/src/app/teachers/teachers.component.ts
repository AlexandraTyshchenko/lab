import { Component, OnInit } from '@angular/core';
import { Teacher } from '../interfaces/teacher';
import { TeacherService } from '../services/TeacherService';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { TeacherFormComponent } from '../teacher-form/teacher-form.component';
import { AsignSubjectToTeacherFormComponent } from '../asign-subject-to-teacher-form/asign-subject-to-teacher-form.component';
import { RemoveSubjectComponent } from '../remove-subject/remove-subject.component';

@Component({
  selector: 'app-teachers',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.scss'],
})
export class TeachersComponent implements OnInit {
  teachers: Array<Teacher> = [];
  displayedColumns: string[] = ['teacher', 'shortinfo', 'subjects', 'id'];

  constructor(private teacherService: TeacherService, public dialog: MatDialog) {}

  addTeacher() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '60%';
    dialogConfig.data = {
      onConfirmation: () => {
        this.getTeachers();
      },
    };
    this.dialog.open(TeacherFormComponent, dialogConfig);
  }

  deleteStudent(id: number) {
    if (confirm('Are you sure to delete ')) {
      this.teacherService.deleteTeachers(id).subscribe(() => {
        this.getTeachers();
      });
    }
  }

  removeSubject(teacherID: number) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '60%';
    dialogConfig.data = {
      teacherId: teacherID,
      onConfirmation: () => {
        this.getTeachers();
      },
    };
    this.dialog.open(RemoveSubjectComponent, dialogConfig);
  }

  asignSubjectToTeacher(id: number) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '60%';
    dialogConfig.data = {
      teacherId: id,
      onConfirmation: () => {
        this.getTeachers();
      },
    };
    this.dialog.open(AsignSubjectToTeacherFormComponent, dialogConfig);
  }

  getTeachers() {
    this.teacherService.getTeachers().subscribe({
      next: (response: Teacher[]) => {
        this.teachers = response;
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      },
    });
  }

  ngOnInit() {
    this.getTeachers();
  }
}

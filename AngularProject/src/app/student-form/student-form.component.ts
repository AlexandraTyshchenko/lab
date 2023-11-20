import { Component, Inject } from '@angular/core';
import { Group } from '../interfaces/group';
import { DialogRef } from '@angular/cdk/dialog';
import { StudentService } from '../services/StudentService';
import { Router } from '@angular/router';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.scss'],
})
export class StudentFormComponent {
  groups: Group[] = [];
  currentGroup = 'select group';
  groupId = -1;
  
  studentForm: FormGroup;

  handleGroup(selectedGroup: Group) {
    this.groupId = selectedGroup.id;
  }

  closeForm() {
    this.dialogRef.close();
  }

  onSubmit() {
    // Check if the form is valid before submitting
    if (this.studentForm.valid) {
      const { firstName, lastName, email } = this.studentForm.value;
      this.studentService.addStudent(firstName, lastName, this.groupId, email).subscribe({
        next: () => {
          this.closeForm();
          this.data.onConfirmation(); 
        },
        error: (error) => console.log(error),
      });
    } else {
      console.log('Form is not valid. Please check the fields.');
    }
  }

  constructor(
    private dialogRef: DialogRef,
    private studentService: StudentService,
    private router: Router,
    @Inject(MAT_DIALOG_DATA) private data: any,
    private fb: FormBuilder
  ) {
    this.groupId = data.groupId;


    this.studentForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
    });
  }
}

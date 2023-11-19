import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BasicItem } from '../basic-item';
import { Student } from '../student';
import { StudentService } from '../services/StudentService';
import { GroupService } from '../services/GroupService';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss'],
})
export class StudentsComponent implements OnInit {

  groups: BasicItem[] = [];
  currentGroup: string = "select group";
  length=0;//input for pagination component
  students:Student[]=[];
  selectedItemId=0;
  constructor(private http: HttpClient,
    private studentService: StudentService,
    private groupService:GroupService) {}

  handleGroup(selectedItem: BasicItem): void {
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
  ngOnInit() {
    this.groupService.GetGroups().subscribe({
      next: (response: any) => {
        this.groups = response.map((group: any) => ({
          id: group.id,
          itemName: group.name
        }));
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
    });
  }
}  

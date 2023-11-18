import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss']
})
export class StudentsComponent implements OnInit {
  groups: any[] = [];
  currentGroup: string = "select group";

  length:number=0;
  constructor(private http: HttpClient) {}

  ngOnInit() {
     this.http.get('https://localhost:7292/api/Group').subscribe(
      (response: any) => {
        this.groups=response;
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
     ); 
     this.http.get('https://localhost:7292/api/Students?groupId=1&page=1&pageSize=10').subscribe(
      (response: any) => {
        this.length=response.studentsCount;
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
     ); 
  }
}

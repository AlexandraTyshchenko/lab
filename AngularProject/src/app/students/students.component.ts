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
  }
}

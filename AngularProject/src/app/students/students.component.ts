import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BasicItem } from '../basic-item';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss']
})
export class StudentsComponent implements OnInit {
  groups: BasicItem[] = [];
  currentGroup: string = "select group";
  groupId:number=0;
  length:number=0;
  constructor(private http: HttpClient) {}
  handleChildValue(selectedItem: BasicItem): void {
    this.groupId = selectedItem.id;
  }
  ngOnInit() {
     this.http.get('https://localhost:7292/api/Group').subscribe(
      (response: any) => {
        this.groups = response.map((group: any) => ({
          id: group.id,
          itemName: group.name
        }));          
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
     ); 
     this.http.get(`https://localhost:7292/api/Students?groupId=${this.groupId}&page=1&pageSize=10`).subscribe(
      (response: any) => {
        this.length=response.studentsCount;
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
     ); 
  }
}

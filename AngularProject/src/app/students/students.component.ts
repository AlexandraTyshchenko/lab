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
  length:number=0;//input for dropdownlist component
  constructor(private http: HttpClient) {}
  handleChildValue(selectedItem: BasicItem): void {
    this.http.get(`https://localhost:7292/api/Students?groupId=${selectedItem.id}&page=1&pageSize=10`).subscribe(
      (response: any) => {
        this.length=response.studentsCount;
        console.log(response.students);
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
     ); 
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
     
  }
}

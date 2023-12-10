import { Component, OnInit } from '@angular/core';
import { Group } from '../interfaces/group';
import { GroupService } from '../services/GroupService';
import { ScheduleService } from '../services/ScheduleService';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.scss'],
})
export class ScheduleComponent implements OnInit {
    groups:Array<Group>=[];
    currentGroup: string = "select group";
    constructor( private groupService:GroupService,private scheduleService:ScheduleService){}
    schedule:any;

    handleGroup(group:Group){
      this.scheduleService.getSchedule(group.id).subscribe({
        next: (response:any) => {
         this.schedule=response;
         console.log(this.schedule);
        },
        error: (error) => {
          console.error('Error fetching data:', error);
        }
      });
    }

    ngOnInit(): void {
      this.groupService.GetGroups().subscribe({
        next: (response:Array<Group>) => {
         this.groups=response;
        },
        error: (error) => {
          console.error('Error fetching data:', error);
        }
      });
    }
}

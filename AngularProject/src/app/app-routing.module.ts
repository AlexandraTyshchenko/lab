import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';
import { StudentsComponent } from './students/students.component';
import { ScheduleComponent } from './schedule/schedule.component';
import {TeachersComponent } from './teachers/teachers.component';
import { HomeComponent } from './home/home.component';
import { SubjectsComponent } from './subjects/subjects.component';

const routes: Routes = [
   {path: "", component:HomeComponent},
   {path: 'students', component: StudentsComponent},
   {path:'schedule',component:ScheduleComponent},
   {path:'teachers', component:TeachersComponent},
   {path:'subjects', component:SubjectsComponent},
   { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
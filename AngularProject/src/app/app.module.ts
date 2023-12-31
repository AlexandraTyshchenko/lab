import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { NotFoundComponent } from './not-found/not-found.component';
import { StudentsComponent } from './students/students.component';

import { ScheduleComponent } from './schedule/schedule.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DropDownListComponent } from './components/drop-down-list/drop-down-list.component';
import { HttpClientModule }   from '@angular/common/http';
import { MatPaginatorModule } from '@angular/material/paginator'
import { MatTableModule } from '@angular/material/table';
import { PaginatorComponent } from './components/paginator/paginator.component';
import { StudentFormComponent } from './student-form/student-form.component';
import {MatDialogModule} from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSidenavModule } from '@angular/material/sidenav';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatListModule} from '@angular/material/list';
import {MatSelectModule} from '@angular/material/select';
import { HomeComponent } from './home/home.component';
import { GroupFormComponent } from './group-form/group-form.component';
import { TeachersComponent } from './teachers/teachers.component';
import { SubjectsComponent } from './subjects/subjects.component';
import { SubjectFormComponent } from './subject-form/subject-form.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { TeacherFormComponent } from './teacher-form/teacher-form.component';
import { AsignSubjectToTeacherFormComponent } from './asign-subject-to-teacher-form/asign-subject-to-teacher-form.component';
import { RemoveSubjectComponent } from './remove-subject/remove-subject.component';
import { ScheduleItemComponent } from './schedule-item/schedule-item.component';
import { LessonComponent } from './lesson/lesson.component';


@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent,
    StudentsComponent,
    TeachersComponent,
    ScheduleComponent,
    DropDownListComponent,
    PaginatorComponent,
    StudentFormComponent,
    GroupFormComponent,
    SubjectsComponent,
    SubjectFormComponent,
    TeacherFormComponent,
    AsignSubjectToTeacherFormComponent,
    RemoveSubjectComponent,
    ScheduleItemComponent,
    LessonComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatPaginatorModule,
    MatTableModule,
    HomeComponent,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatTooltipModule,

  ],
  providers: [],
  bootstrap: [AppComponent]

})
export class AppModule { }

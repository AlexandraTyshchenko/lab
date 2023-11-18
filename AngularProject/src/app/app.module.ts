import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { NotFoundComponent } from './not-found/not-found.component';
import { StudentsComponent } from './students/students.component';
import { SideBarComponent } from './side-bar/side-bar.component';
import { SubjectsComponent } from './subjects/subjects.component';
import { ScheduleComponent } from './schedule/schedule.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DropDownListComponent } from './components/drop-down-list/drop-down-list.component';
import { HttpClientModule }   from '@angular/common/http';
import { MatPaginatorModule } from '@angular/material/paginator'
import { MatTableModule } from '@angular/material/table';
import { PaginatorComponent } from './paginator/paginator.component';
@NgModule({
  declarations: [
    AppComponent,
    SideBarComponent,
    NotFoundComponent,
    StudentsComponent,
    SubjectsComponent,
    ScheduleComponent,
    DropDownListComponent,
    PaginatorComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatPaginatorModule,
    MatTableModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

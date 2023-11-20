import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { NotFoundComponent } from './not-found/not-found.component';
import { StudentsComponent } from './students/students.component';
import { SubjectsComponent } from './subjects/subjects.component';
import { ScheduleComponent } from './schedule/schedule.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DropDownListComponent } from './components/drop-down-list/drop-down-list.component';
import { HttpClientModule }   from '@angular/common/http';
import { MatPaginatorModule } from '@angular/material/paginator'
import { MatTableModule } from '@angular/material/table';
import { PaginatorComponent } from './components/paginator/paginator.component';
import { TestComponent } from './test/test.component';
import { StudentFormComponent } from './student-form/student-form.component';
import {MatDialogModule} from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { MatSidenavModule } from '@angular/material/sidenav';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatListModule} from '@angular/material/list';
import {MatSelectModule} from '@angular/material/select';

@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent,
    StudentsComponent,
    SubjectsComponent,
    ScheduleComponent,
    DropDownListComponent,
    PaginatorComponent,
    StudentFormComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatPaginatorModule,
    MatTableModule,
    TestComponent,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    MatSelectModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]

})
export class AppModule { }

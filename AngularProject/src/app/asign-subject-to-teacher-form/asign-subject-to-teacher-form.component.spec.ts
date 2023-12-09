import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AsignSubjectToTeacherFormComponent } from './asign-subject-to-teacher-form.component';

describe('AsignSubjectToTeacherFormComponent', () => {
  let component: AsignSubjectToTeacherFormComponent;
  let fixture: ComponentFixture<AsignSubjectToTeacherFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AsignSubjectToTeacherFormComponent]
    });
    fixture = TestBed.createComponent(AsignSubjectToTeacherFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

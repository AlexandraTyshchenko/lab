import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoveSubjectComponent } from './remove-subject.component';

describe('RemoveSubjectComponent', () => {
  let component: RemoveSubjectComponent;
  let fixture: ComponentFixture<RemoveSubjectComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RemoveSubjectComponent]
    });
    fixture = TestBed.createComponent(RemoveSubjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

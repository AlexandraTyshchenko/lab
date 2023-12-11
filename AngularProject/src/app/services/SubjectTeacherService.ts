import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { API_BASE_URL } from "src/config";

import { Observable } from 'rxjs';
import { TeacherSubjects } from "../interfaces/teacherSubjects";
import { SubjectTeacher } from "../interfaces/subjectTeacher";
@Injectable({
    providedIn: 'root',
  })

export class SubjectTeacherService {
    constructor(private http: HttpClient) {}
 
    AsignSubject(teacherId:number, subjectId:number):Observable<any> {
        const formData = new FormData();
        formData.append('teacherid',teacherId.toString());
        formData.append('subjectid', subjectId.toString());
        return this.http.post(`${API_BASE_URL}/api/Subjects/AsignSubjectToTeacher`, formData);
    }

    getTeacherWithSubjects(id:number): Observable<TeacherSubjects> {
        return this.http.get<TeacherSubjects>(`${API_BASE_URL}/api/Teacher/id?id=${id}`);
    }
    deleteSubject(teacherId: number, subjectId: number): Observable<any> {
        const params = new HttpParams()
          .set('teacherId', teacherId.toString())
          .set('subjectId', subjectId.toString());
        const url = `${API_BASE_URL}/api/Teacher/teacherSubject`;
        return this.http.delete(url, { params });
    }

    getSubjectTeachers():Observable<SubjectTeacher>{
        return this.http.get<SubjectTeacher>(`${API_BASE_URL}/api/SubjectTeacher`);
    }
}
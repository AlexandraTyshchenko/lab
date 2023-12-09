import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { API_BASE_URL } from "src/config";

import { Observable } from 'rxjs';
import { Subject } from "../interfaces/subject";
@Injectable({
    providedIn: 'root',
  })

export class SubjectService {
    constructor(private http: HttpClient) {}
    getSubjects(): Observable<Subject[]> {
        return this.http.get<Subject[]>(`${API_BASE_URL}/api/Subjects`);
      }

    addSubject(name:string,description:string):Observable<any> {
        const formData = new FormData();
        formData.append('name', name);
        formData.append('description', description);
        return this.http.post(`${API_BASE_URL}/api/Subjects`, formData);
    }

    deleteSubject(id:number){
        return this.http.delete(`${API_BASE_URL}/api/Subjects?subjectId=${id}`);
    }

}
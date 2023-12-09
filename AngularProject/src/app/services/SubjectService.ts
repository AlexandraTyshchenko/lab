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
}
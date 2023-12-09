import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { API_BASE_URL } from "src/config";
import { Teacher } from "../interfaces/teacher";
import { Observable } from 'rxjs';
@Injectable({
    providedIn: 'root',
  })

export class TeacherService {
    constructor(private http: HttpClient) {}
    getTeachers(): Observable<Teacher[]> {
        return this.http.get<Teacher[]>(`${API_BASE_URL}/api/Teacher`);
      }
}
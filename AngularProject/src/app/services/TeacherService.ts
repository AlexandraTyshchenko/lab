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

    addTeacher(name:string,shortInfo:string):Observable<any> {
        const formData = new FormData();
        formData.append('name', name);
        formData.append('shortinfo', shortInfo);
        return this.http.post(`${API_BASE_URL}/api/Teacher`, formData);
    }

    
}
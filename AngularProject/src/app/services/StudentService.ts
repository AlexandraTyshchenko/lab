import { HttpClient } from "@angular/common/http";
import { Student } from "../classes/student";
import { Observable } from 'rxjs';
import { Injectable } from "@angular/core";
import { API_BASE_URL } from "src/config";

@Injectable({
    providedIn: 'root',
})
export class StudentService {

    constructor(private http: HttpClient) {}

    getStudents(groupId: number, page: number, pageSize: number): Observable<Student[]> {
        return this.http.get<Student[]>(`${API_BASE_URL}/api/Students?groupId=${groupId}&page=${page}&pageSize=${pageSize}`)
    }

}

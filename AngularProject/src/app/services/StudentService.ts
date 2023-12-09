import { HttpClient} from "@angular/common/http";
import { Student } from "../interfaces/student";
import { Observable } from 'rxjs';
import { Injectable } from "@angular/core";
import { API_BASE_URL } from "src/config";

@Injectable({
  providedIn: 'root',
})
export class StudentService {

  constructor(private http: HttpClient) {}

  getStudents(groupId: number, page: number, pageSize: number): Observable<Student[]> {
    return this.http.get<Student[]>(`${API_BASE_URL}/api/Students?groupId=${groupId}&page=${page}&pageSize=${pageSize}`);
  }

  addStudent(firstName: string, lastName: string, groupId: number, email: string) {
    const formData = new FormData();
    formData.append('firstName', firstName);
    formData.append('lastName', lastName);
    formData.append('groupId', groupId.toString());
    formData.append('email', email);

  return this.http.post(`${API_BASE_URL}/api/Students/AddStudents`, formData);
      
  }

  deleteStudent(id:number){
    console.log(id);
    return this.http.delete(`${API_BASE_URL}/api/Students/DeleteStudent?id=${id}`);

  }
}

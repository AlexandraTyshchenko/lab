import { HttpClient} from "@angular/common/http";
import { Student } from "../interfaces/student";
import { Observable } from 'rxjs';
import { Injectable } from "@angular/core";
import { API_BASE_URL } from "src/config";

@Injectable({
  providedIn: 'root',
})
export class ScheduleService {

  constructor(private http: HttpClient) {}

  getSchedule(groupId: number): Observable<any> {
    return this.http.get<any>(`${API_BASE_URL}/api/Schedule?groupId=${groupId}`);
  }

}

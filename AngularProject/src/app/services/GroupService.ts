import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";
import { API_BASE_URL } from "src/config";
import { Group } from "../classes/group";

@Injectable({
  providedIn: 'root',
}) 
export class GroupService {
  
  constructor(private http: HttpClient) {}

  GetGroups(): Observable<Group[]> {
    return this.http.get<Group[]>(`${API_BASE_URL}/api/Group`);
  }

}

import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";
import { API_BASE_URL } from "src/config";
import { Group } from "../interfaces/group";

@Injectable({
  providedIn: 'root',
}) 
export class GroupService {
  
  constructor(private http: HttpClient) {}

  GetGroups(): Observable<Group[]> {
    return this.http.get<Group[]>(`${API_BASE_URL}/api/Group`);
  }

  addGroup(groupName:string, groupCourse:number, groupCurator: string):Observable<any>{
      const formData = new FormData();
      formData.append('groupName', groupName);
      formData.append('groupCourse', groupCourse.toString());
      formData.append('groupCurator', groupCurator);
  
    return this.http.post(`${API_BASE_URL}/api/Group`, formData);
  }
}

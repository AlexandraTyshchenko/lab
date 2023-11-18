import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";
import { API_BASE_URL } from "src/config";
@Injectable({
    providedIn: 'root',
}) 
export class GroupService{
    constructor(private http: HttpClient) {}
    GetGroups():Observable<any>{
      return  this.http.get(`${API_BASE_URL}/api/Group`)
    }

}